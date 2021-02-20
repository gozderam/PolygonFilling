using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonFilling.Definitions
{
    public class Vector
    {
        public double X;
        public double Y;
        public double Z;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length
        {
            get => Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector GetNormalised()
        {
            double len = Math.Sqrt(X * X + Y * Y + Z * Z);
            return new Vector(X / len, Y / len, Z / len);
        }

        public static Vector operator *(double s, Vector v)
        {
            return new Vector(s * v.X, s * v.Y, s * v.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static double DotProduct(Vector v1, Vector v2)
        {
            double ret = 0;
            ret += (v1.X * v2.X);
            ret += (v1.Y * v2.Y);
            ret += (v1.Z * v2.Z);
            return ret;
        }

        public static double Cos(Vector v1, Vector v2)
        {
            return DotProduct(v1, v2);
        }

       

    }
}
