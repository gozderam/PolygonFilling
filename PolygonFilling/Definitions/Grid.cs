using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonFilling.Definitions
{
    public class Grid
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        public int N { get; }
        /// <summary>
        /// Number of columns.
        /// </summary>
        public int M { get; }
        public double Left { get; }
        public double Top { get; }
        public double Dx { get; }
        public double Dy { get; }
        public Vertex[,] Vertices { get; set; }
        public (double x, double y) Center
        {
            get
            {
                double x = Left + ((double)M * Dx) / 2;
                double y = Top + ((double)N * Dy) / 2;
                return (x, y);
            }  
        }
        public double Width
        {
            get
            {
                return Dx* M;
            }
        }
        public double Height
        {
            get
            {
                return Dy * N;
            }
        }

        public Grid(int n, int m, double left, double top, double dx, double dy)
        {
            N = n;
            M = m;
            Left = left;
            Top = top;
            Dx = dx;
            Dy = dy;

            Vertices = new Vertex[N + 1, M + 1];
            for(int i =0; i< Vertices.GetLength(0); i++)
            {
                for(int j =0; j< Vertices.GetLength(1); j++)
                {
                    Vertices[i, j] = new Vertex(Left + j * Dx, Top + i * Dy, 
                        i==0 || i == Vertices.GetLength(0)-1 || j==0 || j == Vertices.GetLength(1)-1);
                }
            }
        }

        public List<Polygon> GetPolygons()
        {
            var ret = new List<Polygon>();
            for (int i = 0; i < Vertices.GetLength(0)-1; i++)
            {
                for (int j = 0; j < Vertices.GetLength(1)-1; j++)
                {
                    ret.Add(new Polygon(Vertices[i, j], Vertices[i + 1, j], Vertices[i, j + 1]));
                    ret.Add(new Polygon(Vertices[i, j+1], Vertices[i + 1, j+1], Vertices[i+1, j ]));
                }
            }
            return ret;
        }

        
    }
}
