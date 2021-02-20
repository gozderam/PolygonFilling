using PolygonFilling.Definitions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;

namespace PolygonFilling
{
    public class AETItem
    {
        public Vertex start;
        public Vertex end;
        public double x;
        public double reciprocalM;

        public AETItem(Vertex s, Vertex e, double x, double rM)
        {
            start = s;
            end = e;
            this.x = x;
            reciprocalM = rM;
        }
    }

    public static class AlgorithmUtils
    {
        public static void FillPolygon(Polygon polygon, FillOptions options, BmpPixelSnoop bitmapWrapper, BmpPixelSnoop textureWrapper)
        {
            #region prepare data for interpolation if needed
            double x1 = 1, y1 = 1;
            double x2 = 1, y2 = 1;
            double x3 = 1, y3 = 1;
            double triangleDenominator = 1;
            Vector normalVector1 = null;
            Vector normalVector2 = null;
            Vector normalVector3 = null;
            Color objectColor1 = Color.FromArgb(1, 1, 1);
            Color objectColor2 = Color.FromArgb(1, 1, 1);
            Color objectColor3 = Color.FromArgb(1, 1, 1);

            if (options.FillColorPrecisionOption == FillColorPrecisionOpt.Interpolated)
            {
                // assume polygon is a traingle
                if (polygon.Vertices.Count != 3)
                    throw new ArgumentException("Interpolated Presices is possible only for triangles!");

                x1 = polygon.Vertices[0].X; y1 = polygon.Vertices[0].Y;
                x2 = polygon.Vertices[1].X; y2 = polygon.Vertices[1].Y;
                x3 = polygon.Vertices[2].X; y3 = polygon.Vertices[2].Y;

                triangleDenominator = (y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3);
                if (triangleDenominator == 0)
                    triangleDenominator = 1;

                normalVector1 = getNormalVectorFromTexture((int)x1, (int)y1, options, textureWrapper);
                normalVector2 = getNormalVectorFromTexture((int)x2, (int)y2, options, textureWrapper);
                normalVector3 = getNormalVectorFromTexture((int)x3, (int)y3, options, textureWrapper);

                objectColor1 = (options.ObjectColorOption == ObjectColorOpt.Constant || options.Texture == null)
                ? (Color)options.ObjectColor
                : textureWrapper.GetPixel((int)(x1 - options.GridLeft), (int)(y1 - options.GridTop));
                objectColor2 = (options.ObjectColorOption == ObjectColorOpt.Constant || options.Texture == null)
                ? (Color)options.ObjectColor
                : textureWrapper.GetPixel((int)(x2 - options.GridLeft), (int)(y2 - options.GridTop));
                objectColor3 = (options.ObjectColorOption == ObjectColorOpt.Constant || options.Texture == null)
                ? (Color)options.ObjectColor
                : textureWrapper.GetPixel((int)(x3 - options.GridLeft), (int)(y3 - options.GridTop));

            }
            #endregion

            var sortedVertices = polygon.Vertices.ConvertAll(v => v);
            sortedVertices.Sort((a, b) =>
            {
                if (a.Y < b.Y)
                    return -1;
                if (a.Y == b.Y)
                    return 0;
                return 1;
            });

            var ind = sortedVertices.ConvertAll(v => polygon.Vertices.IndexOf(v));
            var P = polygon.Vertices;
            double ymin = P[ind[0]].Y;
            double ymax = P[ind[ind.Count - 1]].Y;
            int k = 0; // current vertex index;
            List<AETItem> AET = new List<AETItem>();

            // for each scanline
            for (double y = ymin + 1; y <= ymax + 1; y++)
            {
                while (k < ind.Count && y - 1 == P[ind[k]].Y)
                {
                    // previous vertex
                    int pVertInd = ind[k] - 1 >= 0 ? ind[k] - 1 : P.Count - 1;
                    if (P[pVertInd].Y >= P[ind[k]].Y)
                    {
                        // add to AET
                        double dx = (double)(P[pVertInd].X - P[ind[k]].X);
                        double dy = (double)(P[pVertInd].Y - P[ind[k]].Y);
                        if (dy != 0)
                            AET.Add(new AETItem(P[pVertInd], P[ind[k]], P[ind[k]].X, dx / dy));
                    }
                    else
                    {
                        // remove from AET
                        AET.RemoveAll(i => i.start == P[pVertInd] && i.end == P[ind[k]]);
                    }

                    // next vertex
                    int nVertInd = ind[k] + 1 < P.Count ? ind[k] + 1 : 0;
                    if (P[nVertInd].Y >= P[ind[k]].Y)
                    {
                        // add to AET
                        double dx = (double)(P[ind[k]].X - P[nVertInd].X);
                        double dy = (double)(P[ind[k]].Y - P[nVertInd].Y);
                        if (dy != 0)
                            AET.Add(new AETItem(P[ind[k]], P[nVertInd], P[ind[k]].X, dx / dy));
                    }
                    else
                    {
                        // remove from AET
                        AET.RemoveAll(i => i.start == P[ind[k]] && i.end == P[nVertInd]);
                    }

                    k++;
                }

                // sort by x
                AET.Sort((a, b) =>
                {
                    if (a.x < b.x)
                        return -1;
                    if (a.x == b.x)
                        return 0;
                    return 1;
                });

                // set pixels
                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    for (double x = AET[i].x; x <= AET[i + 1].x; x++)
                    {
                        bitmapWrapper.SetPixel((int)x, (int)y - 1,
                            options.FillColorPrecisionOption == FillColorPrecisionOpt.Precise
                            ? GetPreciseColorForPixel((int)x, (int)y - 1, options, textureWrapper)
                            : GetInterpolatedColorForPixel(
                                (int)x1, (int)y1, (int)x2, (int)y2, (int)x3, (int)y3, triangleDenominator,
                                normalVector1, normalVector2, normalVector3,
                                objectColor1, objectColor2, objectColor3, (int)x, (int)y - 1, options, textureWrapper));
                    }
                }

                // update x
                AET.ForEach(v => v.x += v.reciprocalM);
            }
        }

        private static Color GetPreciseColorForPixel(int x, int y, FillOptions options, BmpPixelSnoop textureWrapper)
        {
 
            Vector N = options.NormalVectorOption == NormalVectorOpt.FromTexture ? getNormalVectorFromTexture(x, y, options, textureWrapper) : DEFAULT_OPTIONS.defaultNormalVector;
            Vector V = new Vector(0, 0, 1);
            var LightPoint = options.LightPoint;
            var L = (options.LightVectorOption == LightVectorOpt.FromPointOnSpiral && LightPoint != null) 
                ? new Vector(LightPoint.X - x, (-1)*(LightPoint.Y - y), LightPoint.Z - 0).GetNormalised() 
                : DEFAULT_OPTIONS.defaultLightVector;
            Vector R = 2 * Vector.DotProduct(N, L) * N - L;

            Color Il = options.LightColor;
            Color Io = (options.ObjectColorOption == ObjectColorOpt.Constant || options.Texture == null)
                ? (Color)options.ObjectColor
                : textureWrapper.GetPixel(x - (int)(options.GridLeft), y - (int)(options.GridTop));
            double kd = options.LambertModelFactor;
            double ks = options.ReflectionFactor;
            int m = options.ReflectionLevel;

            return Color.FromArgb(calculatePart(Il.R, Io.R, kd, ks, N, L, V, R, m),
                calculatePart(Il.G, Io.G, kd, ks, N, L, V, R, m),
                calculatePart(Il.B, Io.B, kd, ks, N, L, V, R, m));
        }


        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <remarks>Only for triangles.</remarks>
        private static Color GetInterpolatedColorForPixel(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double triangleDenominator, // cout once, use for each pixel
            Vector normalVector1, // cout once, use for each pixel
            Vector normalVector2, // cout once, use for each pixel
            Vector normalVector3, // cout once, use for each pixel
            Color objectColor1, // cout once, use for each pixel
            Color objectColor2, // cout once, use for each pixel
            Color objectColor3, // cout once, use for each pixel
            int x, int y, FillOptions options, BmpPixelSnoop textureWrapper)
        {

            // calculate barycentric coordinates
            double W1 = ((y2 - y3) * (x - x3) + (x3 - x2) * (y - y3)) / triangleDenominator;
            double W2 = ((y3 - y1) * (x - x3) + (x1 - x3) * (y - y3)) / triangleDenominator;
            double W3 = 1 - W1 - W2;

            Vector N = options.NormalVectorOption == NormalVectorOpt.FromTexture
                ? W1 * normalVector1 + W2 * normalVector2 + W3 * normalVector3  // inerpolated normal vector 
                : DEFAULT_OPTIONS.defaultNormalVector;

            Vector V = new Vector(0, 0, 1);
            var LightPoint = options.LightPoint;
            var L = (options.LightVectorOption == LightVectorOpt.FromPointOnSpiral && LightPoint != null)
                ? new Vector(LightPoint.X - x, (-1)*(LightPoint.Y - y), LightPoint.Z - 0).GetNormalised()
                : DEFAULT_OPTIONS.defaultLightVector;
            Vector R = 2 * Vector.DotProduct(N, L) * N - L;

            Color Il = options.LightColor;
            Color Io = (options.ObjectColorOption == ObjectColorOpt.Constant || options.Texture == null)
                ? (Color)options.ObjectColor
                : Color.FromArgb(
                    round_To_0_255((int)(W1 * objectColor1.R + W2 * objectColor2.R + W3 * objectColor3.R)),
                    round_To_0_255((int)(W1 * objectColor1.G + W2 * objectColor2.G + W3 * objectColor3.G)),
                    round_To_0_255((int)(W1 * objectColor1.B + W2 * objectColor2.B + W3 * objectColor3.B))); // interpolated object color 

            double kd = options.LambertModelFactor;
            double ks = options.ReflectionFactor;
            int m = options.ReflectionLevel;

            return Color.FromArgb(calculatePart(Il.R, Io.R, kd, ks, N, L, V, R, m),
                calculatePart(Il.G, Io.G, kd, ks, N, L, V, R, m),
                calculatePart(Il.B, Io.B, kd, ks, N, L, V, R, m));

        }

        private static int calculatePart(int IlPart, int IoPart, double kd, double ks, Vector N, Vector L, Vector V, Vector R, int m)
        {
            return scale_From_0_1_To_0_255(kd * scale_Form_0_255_To_0_1(IlPart) * scale_Form_0_255_To_0_1(IoPart) * Vector.Cos(N, L) + ks * scale_Form_0_255_To_0_1(IlPart) * scale_Form_0_255_To_0_1(IoPart) * Math.Pow(Vector.Cos(V, R), m));
        }

        private static double scale_Form_0_255_To_0_1(int c)
        {
            double ret = (double)c / 255;
            if (ret > 1) return 1;
            if (ret < 0) return 0;
            return ret;
        }

        private static int scale_From_0_1_To_0_255(double c)
        {
            int ret = (int)(c * 255);
            if (ret > 255) return 255;
            if (ret < 0) return 0;
            return ret;
        }

        private static int round_To_0_255(double c)
        {
            if (c > 255) return 255;
            if (c < 0) return 0;
            return (int)c;
        }

        private static Vector getNormalVectorFromTexture(int x, int y, FillOptions options, BmpPixelSnoop textureWrapper)
        {
            if (textureWrapper == null)
            {
                return DEFAULT_OPTIONS.defaultNormalVector;
            }
            var vector = textureWrapper.GetPixel(x - (int)(options.GridLeft), y - (int)(options.GridTop));
            return new Vector(scaleToNormalVector(vector.R), scaleToNormalVector(vector.G), scale_Form_0_255_To_0_1(vector.B)).GetNormalised();

            double scaleToNormalVector(int c)
            {
                var ret = ((double)c / 255) * 2 - 1;
                if (ret > 1) return 1;
                if (ret < -1) return -1;
                return ret;
            }
        }
    }
}
