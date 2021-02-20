using PolygonFilling.Definitions;
using PolygonFilling.Modules;
using PolygonFilling.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonFilling
{
    public partial class MainForm : Form
    {
        private AggregationModule aggregationModule;
        private Dictionary<string, Bitmap> textures = new Dictionary<string, Bitmap>();

        public MainForm()
        {
            InitializeComponent();

            // default sizes
            nTextBox.Text = DEFAULT_OPTIONS.defaultGridN.ToString();
            mTextBox.Text = DEFAULT_OPTIONS.defaultGridM.ToString();

            // initialize aggergation Module
            aggregationModule = new AggregationModule(ReadOptionsFormUI(), pictureBox);
            // initial grid
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            // factor textboxes
            reflectionFactorTextBox.Text = ((double)reflectionFactorTB.Value / 100).ToString();
            lambertModelFactorTextBox.Text = ((double)lambertModelFactorTB.Value / 100).ToString();
            reflectionLevelTextBox.Text = reflectionLevelTB.Value.ToString();



            // load textures 
            foreach (DictionaryEntry res in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                if (res.Value is Bitmap b)
                {
                    if(b.PixelFormat != PixelFormat.Format32bppArgb)
                    {
                        // convert to Format32bppArgb
                        Bitmap clone = new Bitmap(b.Width, b.Height,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        using (Graphics gr = Graphics.FromImage(clone))
                        {
                            gr.DrawImage(b, new Rectangle(0, 0, clone.Width, clone.Height));
                        }
                        textures.Add($"{res.Key}", clone);

                    }
                    else
                        textures.Add($"{res.Key}", b);
                }
            }
            textureComboBox.DataSource = textures.Keys.ToList();
        }

        #region TrackBars
        private void lambertModelFactorTB_ValueChanged(object sender, EventArgs e)
        {
            lambertModelFactorTextBox.Text = ((double)lambertModelFactorTB.Value / 100).ToString();
            aggregationModule.Fill(ReadOptionsFormUI());
        }
        private void reflectionFactorTB_ValueChanged(object sender, EventArgs e)
        {
            reflectionFactorTextBox.Text = ((double)reflectionFactorTB.Value / 100).ToString();
            aggregationModule.Fill(ReadOptionsFormUI());
        }
        private void reflectionLevelTB_ValueChanged(object sender, EventArgs e)
        {
            reflectionLevelTextBox.Text = reflectionLevelTB.Value.ToString();
            aggregationModule.Fill(ReadOptionsFormUI());
        }
        #endregion

        #region Mouse
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            aggregationModule.StartVertexMoving(e.X, e.Y);
            aggregationModule.StopAnimation();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            aggregationModule.MoveVertex(e.X, e.Y);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            aggregationModule.FinishVertexMoving();
            aggregationModule.StartAnimation();
        }
        #endregion

        #region Buttons 
        private void pickObjectColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pickedObjectColorPictureBox.BackColor = colorDialog.Color;
                aggregationModule.Fill(ReadOptionsFormUI());
            }
        }
        private void pickLightColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pickedLightColorPictureBox.BackColor = colorDialog.Color;
                aggregationModule.Fill(ReadOptionsFormUI());
            }
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }
        #endregion

        #region private methods
        private FillOptions ReadOptionsFormUI()
        {
            return new FillOptions
            {
                // options 
                ObjectColorOption = constantObjectColorRB.Checked ? ObjectColorOpt.Constant : ObjectColorOpt.FromTexture,
                NormalVectorOption = defaultNormalVectorRB.Checked ? NormalVectorOpt.Default : NormalVectorOpt.FromTexture,
                LightVectorOption = defaultLightVectorRB.Checked ? LightVectorOpt.Default : LightVectorOpt.FromPointOnSpiral,
                FillColorPrecisionOption = preciseFillColorRB.Checked ? FillColorPrecisionOpt.Precise : FillColorPrecisionOpt.Interpolated,

                // params
                ObjectColor = constantObjectColorRB.Checked ? (Color?)pickedObjectColorPictureBox.BackColor : null,
                LightColor = pickedLightColorPictureBox.BackColor,
                LambertModelFactor = (double)lambertModelFactorTB.Value / 100,
                ReflectionFactor = (double)reflectionFactorTB.Value / 100,
                ReflectionLevel = reflectionLevelTB.Value,
                Texture = (fromTextureNomalVectorRB.Checked || fromTextureObjectColorRB.Checked) ? textures[(string)textureComboBox.SelectedItem] : null,

                IsGridVisibible = gridVisibleCheckBox.Checked,
                GridN = GetGridN(),
                GridM = GetGridM(),
            };
        }

        private int GetGridN()
        {
            if (int.TryParse(nTextBox.Text, out int ret))
            { 
                if(ret < CONSTS.gridMinN)
                    return CONSTS.gridMinN;
                if (ret > CONSTS.gridMaxN)
                    return CONSTS.gridMaxN;
                return ret;
            }

            return DEFAULT_OPTIONS.defaultGridN;
        }

        private int GetGridM()
        {
            if (int.TryParse(mTextBox.Text, out int ret))
            {
                if (ret < CONSTS.gridMinM)
                    return CONSTS.gridMinM;
                if (ret > CONSTS.gridMaxM)
                    return CONSTS.gridMaxM;
                return ret;
            }

            return DEFAULT_OPTIONS.defaultGridM;
        }
        #endregion

        #region Radio buttons
        private void constantObjectColorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void fromTextureObjectColorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void defaultNormalVectorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void fromTextureNomalVectorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void defaultLightVectorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void fromSpiralLightVectorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void preciseFillColorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void interpolatedFillColorRB_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        private void textureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }

        #endregion

        #region grid size textboxes & grid visibility checkbox
        private void nTextBox_TextChanged(object sender, EventArgs e)
        {
            if(nTextBox.Text != "")
                nTextBox.Text = GetGridN().ToString();
            if(aggregationModule != null)
                aggregationModule.Fill(ReadOptionsFormUI());
        }
        private void mTextBox_TextChanged(object sender, EventArgs e)
        {
            if (mTextBox.Text != "")
                mTextBox.Text = GetGridM().ToString();
            if(aggregationModule != null)
                aggregationModule.Fill(ReadOptionsFormUI());
        }
        #endregion

        private void gridVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            aggregationModule.Fill(ReadOptionsFormUI());
        }
    }
}
