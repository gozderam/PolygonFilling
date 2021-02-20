using PolygonFilling.Definitions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonFilling.Modules
{
    public class DrawingModule
    {
        private Bitmap drawArea;
        private Color backColor;
        private PictureBox drawBox;
        //private BmpPixelSnoop drawAreaWrapper;
        public bool IsDuringTransaction { get; private set; } = false;

        public DrawingModule(PictureBox drawBox)
        {
            this.drawBox = drawBox; 
            this.drawArea = new Bitmap(CONSTS.drawAreaWidth, CONSTS.drawAreaHeight/*, PixelFormat.Format32bppPArgb*/);
           // drawAreaWrapper = new BmpPixelSnoop(this.drawArea);
            drawBox.Image = drawArea;
            backColor = drawBox.BackColor;
        }

        #region drawing transaction
        /// <summary>
        /// Begins the drawing transaction. After the transaction should end, call <see cref="FinishDrawingTransaction"/>.
        /// </summary>
        /// <returns>Is Transaction successfully beggined.</returns>
        /// <remarks>Use Drawing Transaction while invoking subsequent drawing functions that should result one visible result. It increases the performance and prevents from flickering.</remarks>
        /// <remarks></remarks>
        public bool BeginDrawingTransaction()
        {
            if (IsDuringTransaction)
                return false;
            IsDuringTransaction = true;
            return true;
        }

        /// <summary>
        /// Finishes the drawing transaction. Before the transaction should begin, call <see cref="BeginDrawingTransaction"/>.
        /// </summary>
        /// <returns>Is Transaction successfully finished.</returns>
        /// <remarks>Use Drawing Transaction while invoking subsequent drawing functions that should result one visible result. It increases the performance and prevents from flickering.</remarks>
        public bool FinishDrawingTransaction()
        {
            if (!IsDuringTransaction)
                return false;
            IsDuringTransaction = false;
            drawBox.Refresh();
            return true;
        }
        #endregion

        #region drawing
        public void DrawGridBorders(Grid g)
        {
            using (var grapics = Graphics.FromImage(drawArea))
            {
                for (int i = 0; i < g.Vertices.GetLength(0); i++)
                {
                    for (int j = 0; j < g.Vertices.GetLength(1); j++)
                    {
                        //grapics.DrawRectangle(Pens.Black, (float)g.Vertices[i, j].X, (float)g.Vertices[i, j].Y, 1, 1);
                        if(i+1 <g.Vertices.GetLength(0))
                            grapics.DrawLine(Pens.Black, g.Vertices[i, j].ToPointF(), g.Vertices[i + 1, j].ToPointF());
                        if(j+1 < g.Vertices.GetLength(1))
                            grapics.DrawLine(Pens.Black, g.Vertices[i, j].ToPointF(), g.Vertices[i, j+1].ToPointF());
                        if (i -1 >= 0 && j + 1 < g.Vertices.GetLength(1))
                            grapics.DrawLine(Pens.Black, g.Vertices[i, j].ToPointF(), g.Vertices[i - 1, j+1].ToPointF());
                    }
                }
            }
        }

        public  void FillGrid(Grid g, FillOptions options)
        {
            using (var bitmapWrapper = new BmpPixelSnoop(drawArea))
                using (var textureWrapper = options.Texture != null ? new BmpPixelSnoop(options.Texture) : null)
                Parallel.ForEach(g.GetPolygons(), t => AlgorithmUtils.FillPolygon(t, options, bitmapWrapper, textureWrapper));
                     //g.GetPolygons().ForEach(t => AlgorithmUtils.FillPolygon(t, options, bitmapWrapper, textureWrapper));
        }

        public void DrawLightPoint(double x, double y, double r)
        {
            using (var grapics = Graphics.FromImage(drawArea))
            {
                grapics.FillEllipse(Brushes.Red, (int)(x - r), (int)(y - r), 2 * (int)r, 2 * (int)r);
            }
        }
        #endregion

        #region clearing
        public void ClearGridBorders(Grid g)
        {
            using (var grapics = Graphics.FromImage(drawArea))
            {
                using (var  p = new Pen(backColor))
                {
                    for (int i = 0; i < g.Vertices.GetLength(0); i++)
                    {
                        for (int j = 0; j < g.Vertices.GetLength(1); j++)
                        {
                            //grapics.DrawRectangle(p, (float)g.Vertices[i, j].X, (float)g.Vertices[i, j].Y, 1, 1);
                            if (i + 1 < g.Vertices.GetLength(0))
                                grapics.DrawLine(p, g.Vertices[i, j].ToPointF(), g.Vertices[i + 1, j].ToPointF());
                            if (j + 1 < g.Vertices.GetLength(1))
                                grapics.DrawLine(p, g.Vertices[i, j].ToPointF(), g.Vertices[i, j + 1].ToPointF());
                            if (i - 1 >= 0 && j + 1 < g.Vertices.GetLength(1))
                                grapics.DrawLine(p, g.Vertices[i, j].ToPointF(), g.Vertices[i - 1, j + 1].ToPointF());
                        }
                    }
                }
            }
        }

        public void ClearGridFilling(Grid g)
        {
            using (var grapics = Graphics.FromImage(drawArea))
            {    
                //TODO 
                g.GetPolygons().ForEach(t => grapics.FillPolygon(new SolidBrush(backColor), t.Vertices.ConvertAll( v=>v.ToPointF()).ToArray()));
            }
        }

        public void ClearLightPoint(double x, double y, double r)
        {
            using (var grapics = Graphics.FromImage(drawArea))
            {
                using(var b =new SolidBrush(backColor))
                {
                    grapics.FillEllipse(b, (int)(x - r), (int)(y - r), 2 * (int)r, 2 * (int)r);
                }
            }
        }
        #endregion

    }
}
