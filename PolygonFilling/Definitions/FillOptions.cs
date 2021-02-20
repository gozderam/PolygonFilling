using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonFilling.Definitions
{
    public class FillOptions
    {
        /// /////////////////////////
        // options
        /// /////////////////////////

        public ObjectColorOpt ObjectColorOption { get; set; }
        public NormalVectorOpt NormalVectorOption { get; set; }
        public LightVectorOpt LightVectorOption { get; set; }
        public FillColorPrecisionOpt FillColorPrecisionOption { get; set; }


        /// /////////////////////////
        // params
        /// /////////////////////////
        public double LambertModelFactor { get; set; }
        public double ReflectionFactor { get; set; }
        public int ReflectionLevel { get; set; }
        public Color LightColor { get; set; }
        /// <summary>
        /// Valid only if <see cref="ObjectColorOption"/> equals <see cref="ObjectColorOpt.Constant"/>. Otherwise null.
        /// </summary>
        public Color? ObjectColor { get; set; }
        /// <summary>
        /// Valid only if any opiton equals <see cref="NormalVectorOpt.FromTexture"/> or <see cref="ObjectColorOpt.FromTexture"/> or <see cref="FromTexture"/>. Otherwise null.
        /// </summary>
        public Bitmap Texture { get; set; }
        /// <summary>
        /// Valid only if <see cref="LightVectorOpt"/> equals <see cref="LightVectorOpt.FromPointOnSpiral"/>. Otherwise null.
        /// </summary>
        public Vector LightPoint {get; set;}
        public double GridTop { get; set; }
        public double GridLeft { get; set; }
        public bool IsGridVisibible { get; set; }

        private int gridN = DEFAULT_OPTIONS.defaultGridN;
        public int GridN
        {
            get
            {
                return gridN;
            }
            set
            {
                if (value > CONSTS.gridMaxN)
                    gridN = CONSTS.gridMaxN;
                if (value < CONSTS.gridMinN)
                    gridN = CONSTS.gridMinN;
                else
                    gridN = value;
            }
        }
        private int gridM = DEFAULT_OPTIONS.defaultGridM;
        public int GridM
        {
            get
            {
                return gridM;
            }
            set
            {
                if (value > CONSTS.gridMaxM)
                    gridM = CONSTS.gridMaxM;
                if (value < CONSTS.gridMinM)
                    gridM = CONSTS.gridMinM;
                else
                    gridM = value;
            }
        }

    }

    public enum ObjectColorOpt
    {
        Constant,
        FromTexture,
    }

    public enum NormalVectorOpt
    {
        Default,
        FromTexture,
    }

    public enum LightVectorOpt
    {
        Default,
        FromPointOnSpiral,
    }

    public enum FillColorPrecisionOpt
    {
        Precise,
        Interpolated,
    }

    public static class DEFAULT_OPTIONS
    {
        public static Vector defaultNormalVector = new Vector(0, 0, 1);
        public static Vector defaultLightVector = new Vector(0, 0, 1);
        public static int defaultGridN = 6;
        public static int defaultGridM = 6;
    }
        

}
