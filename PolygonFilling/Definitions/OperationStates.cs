using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PolygonFilling.Definitions
{
    public struct MovingVertexState
    {
        public Vertex selectedVertex;

        public MovingVertexState(Vertex currentlyMovingVertice)
        {
            this.selectedVertex = currentlyMovingVertice;
        }

        public bool IsDuringMovement
        {
            get
            {
                return selectedVertex != null;
            }
        }

        public void Clear()
        {
            selectedVertex = null;
        }
    }

    public struct AnimatingSpiralPointState
    {
        public double MaxRadius 
        { 
            get => rMax;
        }
        public (double x, double y) Center { get; }
        public double X 
        { 
            get => Center.x + r * Math.Cos(angle);
        }

        public double Y
        {
            get => Center.y + r * Math.Sin(angle);
        }
        public double Z
        {
            get => z;
        }
        
        // angle
        private double angle;
        private double angleStep;

        //z
        private double z;
        private double zStep;
        private readonly double zMax;
        private const double zMin = 0;

        // r
        private double r;
        private double rStep;
        private readonly double rMax;
        private const double rMin = 0;

        public AnimatingSpiralPointState(double maxRadius, (double x, double y) center)
        {
            Center = center;

            angle = 0;
            angleStep = 0.5;

            r = rMin;
            rStep = 5;
            rMax = maxRadius;

            z = zMin;
            zStep = 10;
            zMax = 2* maxRadius + zMin;
        }

        public void UpdateState()
        {
            angle += angleStep;
            if (angle >= 2 * Math.PI)
                angle = 0;

            z += zStep;
            if(z>=zMax || z<=zMin )
                zStep = -zStep;

            r += rStep;
            if(r>=rMax | r<=rMin)
                rStep = -rStep;
        }   
    }
}
