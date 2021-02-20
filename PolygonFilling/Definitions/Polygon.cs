using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonFilling.Definitions
{
    public class Polygon
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();

        public Polygon(List<Vertex> vertices)
        {
            this.Vertices = vertices;
        }

        public Polygon(params Vertex[] vertices)
        {
            this.Vertices = vertices.ToList();
        }
    }
}
