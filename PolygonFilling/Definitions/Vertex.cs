using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonFilling.Definitions
{
    public class Vertex
    {
        public double X { get; private set; }
        public double Y { get; private set;}
        
        public bool IsBorderVertex { get; }
        public Vertex(double x, double y, bool isBorderVertice)
        {
            X = x;
            Y = y;
            IsBorderVertex = isBorderVertice;
        }

        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }

        public bool IsVertexInHitArea(double x, double y)
        {
            int R = 3;
            return new Rectangle((int)(X - R), (int)(Y - R), (int)(2 * R), (int)(2 * R)).Contains((int)x, (int)y);
        }

        public void Move(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
