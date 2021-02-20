using PolygonFilling.Definitions;
using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonFilling.Modules
{
    public class AggregationModule
    {
        private DrawingModule drawingModule;
        private Grid grid;
        private FillOptions fillGridOptions;
        private MovingVertexState movingVertexState;
        private AnimatingSpiralPointState animatingSpiralPointState;
        private Timer lightAnimationTimer;

        public AggregationModule(FillOptions fillGridOptions, PictureBox drawBox)
        {
            this.fillGridOptions = fillGridOptions;
            grid = new Grid(this.fillGridOptions.GridN, this.fillGridOptions.GridM, CONSTS.gridLeft, CONSTS.gridTop,
                CONSTS.gridWidth/this.fillGridOptions.GridM, CONSTS.gridHeight/this.fillGridOptions.GridN);
            drawingModule = new DrawingModule(drawBox);
            movingVertexState = new MovingVertexState(null);
            animatingSpiralPointState = new AnimatingSpiralPointState(Math.Max(grid.Height, grid.Width)/2, grid.Center);
            lightAnimationTimer = new Timer();
            lightAnimationTimer.Interval = 30;
            lightAnimationTimer.Tick += (object sender, EventArgs e) =>
            {
                AnimationHandler();
            };
        }

        public void Fill(FillOptions options)
        {
            fillGridOptions = options;

            //clear old grid
            drawingModule.ClearGridBorders(grid);
            drawingModule.ClearGridFilling(grid);

            grid = new Grid(this.fillGridOptions.GridN, this.fillGridOptions.GridM, CONSTS.gridLeft, CONSTS.gridTop,
               CONSTS.gridWidth / this.fillGridOptions.GridM, CONSTS.gridHeight / this.fillGridOptions.GridN);

            fillGridOptions.GridLeft = grid.Left;
            fillGridOptions.GridTop = grid.Top;
            if(options.LightVectorOption == LightVectorOpt.FromPointOnSpiral)
            {
                this.fillGridOptions.LightVectorOption = LightVectorOpt.FromPointOnSpiral;
                this.fillGridOptions.LightPoint = new Vector(animatingSpiralPointState.X, animatingSpiralPointState.Y, animatingSpiralPointState.Z);
                StartAnimation();
            }
            else
            {
                StopAnimation();
                drawingModule.ClearGridBorders(grid);
                drawingModule.ClearGridFilling(grid);
                Redraw();
            }
           
        }

        public void StartAnimation()
        {
            if(fillGridOptions.LightVectorOption == LightVectorOpt.FromPointOnSpiral)
            {
                lightAnimationTimer.Start();
            }
        }

        public void StopAnimation()
        {
            lightAnimationTimer.Stop();
        }

        #region vertice moving
        public bool StartVertexMoving(double x, double y)
        {
            var v = GetVertexFromHit(x, y);
            // block border vertices from moving
            if (v == null || v.IsBorderVertex)
                return false;
            movingVertexState.selectedVertex = v;
            return true;
        }

        public bool MoveVertex(double x, double y)
        {
            if (!movingVertexState.IsDuringMovement)
                return false;

            drawingModule.BeginDrawingTransaction();
            // clear old position
            drawingModule.ClearGridBorders(grid);
            drawingModule.ClearGridFilling(grid);

            // update positions
            if(!(x<=grid.Left || x>=grid.Left + grid.Width || y<=grid.Top || y>=grid.Top + grid.Height))
                movingVertexState.selectedVertex.Move(x, y);

            // draw with updated positions
            Redraw();
            drawingModule.FinishDrawingTransaction();
            return true;
        }

        public bool FinishVertexMoving()
        {
            if (!movingVertexState.IsDuringMovement)
                return false;

            movingVertexState.Clear();
            return true;
        }
        #endregion

        #region hit detecting
        public Vertex GetVertexFromHit(double x, double y)
        {
            for (int i = 0; i < grid.Vertices.GetLength(0); i++)
            {
                for (int j = 0; j < grid.Vertices.GetLength(1); j++)
                {
                    if (grid.Vertices[i, j].IsVertexInHitArea(x, y))
                        return grid.Vertices[i, j];
                }
            }     
            return null;
        }
        #endregion

        #region private methods
        private void Redraw()
        {
            //drawingModule.ClearGridBorders(grid);
            //drawingModule.ClearGridFilling(grid);
            bool isInvokedInsideTransaction = drawingModule.IsDuringTransaction;
            if (!isInvokedInsideTransaction)
                drawingModule.BeginDrawingTransaction();

            drawingModule.FillGrid(grid, fillGridOptions);
            if(fillGridOptions.IsGridVisibible)
                drawingModule.DrawGridBorders(grid);

            if (!isInvokedInsideTransaction)
                drawingModule.FinishDrawingTransaction();
        }

        private void AnimationHandler()
        {
            drawingModule.BeginDrawingTransaction();
            drawingModule.ClearLightPoint(animatingSpiralPointState.X, animatingSpiralPointState.Y, 4);
            animatingSpiralPointState.UpdateState();
            this.fillGridOptions.LightPoint = new Vector(animatingSpiralPointState.X, animatingSpiralPointState.Y, animatingSpiralPointState.Z);
            drawingModule.ClearGridBorders(grid);
            drawingModule.ClearGridFilling(grid);
            drawingModule.DrawLightPoint(animatingSpiralPointState.X, animatingSpiralPointState.Y, 4);
            Redraw();
            drawingModule.DrawLightPoint(animatingSpiralPointState.X, animatingSpiralPointState.Y, 4);
            drawingModule.FinishDrawingTransaction();
        }

        #endregion
    }
}
