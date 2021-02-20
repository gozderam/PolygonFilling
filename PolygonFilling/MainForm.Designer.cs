namespace PolygonFilling
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuLabel = new System.Windows.Forms.Label();
            this.objectColorGroupBox = new System.Windows.Forms.GroupBox();
            this.pickObjectColorButton = new System.Windows.Forms.Button();
            this.pickedObjectColorPictureBox = new System.Windows.Forms.PictureBox();
            this.constantObjectColorRB = new System.Windows.Forms.RadioButton();
            this.fromTextureObjectColorRB = new System.Windows.Forms.RadioButton();
            this.normalVectorGroupBox = new System.Windows.Forms.GroupBox();
            this.fromTextureNomalVectorRB = new System.Windows.Forms.RadioButton();
            this.defaultNormalVectorRB = new System.Windows.Forms.RadioButton();
            this.lightPointGroupBox = new System.Windows.Forms.GroupBox();
            this.defaultLightVectorRB = new System.Windows.Forms.RadioButton();
            this.fromSpiralLightVectorRB = new System.Windows.Forms.RadioButton();
            this.fillColorPrecisionGroupBox = new System.Windows.Forms.GroupBox();
            this.interpolatedFillColorRB = new System.Windows.Forms.RadioButton();
            this.preciseFillColorRB = new System.Windows.Forms.RadioButton();
            this.lambertModelFactorGroupBox = new System.Windows.Forms.GroupBox();
            this.lambertModelFactorTextBox = new System.Windows.Forms.TextBox();
            this.lambertModelFactorTB = new System.Windows.Forms.TrackBar();
            this.reflectionFactorGroupBox = new System.Windows.Forms.GroupBox();
            this.reflectionFactorTextBox = new System.Windows.Forms.TextBox();
            this.reflectionFactorTB = new System.Windows.Forms.TrackBar();
            this.refletionLevelGroupBox = new System.Windows.Forms.GroupBox();
            this.reflectionLevelTextBox = new System.Windows.Forms.TextBox();
            this.reflectionLevelTB = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lightColorGroupBox = new System.Windows.Forms.GroupBox();
            this.pickedLightColorPictureBox = new System.Windows.Forms.PictureBox();
            this.pickLightColorButton = new System.Windows.Forms.Button();
            this.textureGroupBox = new System.Windows.Forms.GroupBox();
            this.textureComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.gridGB = new System.Windows.Forms.GroupBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.nLabel = new System.Windows.Forms.Label();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.gridVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.objectColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedObjectColorPictureBox)).BeginInit();
            this.normalVectorGroupBox.SuspendLayout();
            this.lightPointGroupBox.SuspendLayout();
            this.fillColorPrecisionGroupBox.SuspendLayout();
            this.lambertModelFactorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lambertModelFactorTB)).BeginInit();
            this.reflectionFactorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionFactorTB)).BeginInit();
            this.refletionLevelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionLevelTB)).BeginInit();
            this.lightColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedLightColorPictureBox)).BeginInit();
            this.textureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gridGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuLabel
            // 
            this.menuLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuLabel.AutoSize = true;
            this.menuLabel.Location = new System.Drawing.Point(1278, 9);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(43, 17);
            this.menuLabel.TabIndex = 1;
            this.menuLabel.Text = "Menu";
            // 
            // objectColorGroupBox
            // 
            this.objectColorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.objectColorGroupBox.Controls.Add(this.pickObjectColorButton);
            this.objectColorGroupBox.Controls.Add(this.pickedObjectColorPictureBox);
            this.objectColorGroupBox.Controls.Add(this.constantObjectColorRB);
            this.objectColorGroupBox.Controls.Add(this.fromTextureObjectColorRB);
            this.objectColorGroupBox.Location = new System.Drawing.Point(1158, 123);
            this.objectColorGroupBox.Name = "objectColorGroupBox";
            this.objectColorGroupBox.Size = new System.Drawing.Size(268, 139);
            this.objectColorGroupBox.TabIndex = 2;
            this.objectColorGroupBox.TabStop = false;
            this.objectColorGroupBox.Text = "Object Color";
            // 
            // pickObjectColorButton
            // 
            this.pickObjectColorButton.Location = new System.Drawing.Point(39, 63);
            this.pickObjectColorButton.Name = "pickObjectColorButton";
            this.pickObjectColorButton.Size = new System.Drawing.Size(145, 26);
            this.pickObjectColorButton.TabIndex = 3;
            this.pickObjectColorButton.Text = "Pick color";
            this.pickObjectColorButton.UseVisualStyleBackColor = true;
            this.pickObjectColorButton.Click += new System.EventHandler(this.pickObjectColorButton_Click);
            // 
            // pickedObjectColorPictureBox
            // 
            this.pickedObjectColorPictureBox.BackColor = System.Drawing.Color.White;
            this.pickedObjectColorPictureBox.Location = new System.Drawing.Point(204, 63);
            this.pickedObjectColorPictureBox.Name = "pickedObjectColorPictureBox";
            this.pickedObjectColorPictureBox.Size = new System.Drawing.Size(28, 26);
            this.pickedObjectColorPictureBox.TabIndex = 2;
            this.pickedObjectColorPictureBox.TabStop = false;
            // 
            // constantObjectColorRB
            // 
            this.constantObjectColorRB.AutoSize = true;
            this.constantObjectColorRB.Checked = true;
            this.constantObjectColorRB.Location = new System.Drawing.Point(17, 36);
            this.constantObjectColorRB.Name = "constantObjectColorRB";
            this.constantObjectColorRB.Size = new System.Drawing.Size(85, 21);
            this.constantObjectColorRB.TabIndex = 0;
            this.constantObjectColorRB.TabStop = true;
            this.constantObjectColorRB.Text = "Constant";
            this.constantObjectColorRB.UseVisualStyleBackColor = true;
            this.constantObjectColorRB.CheckedChanged += new System.EventHandler(this.constantObjectColorRB_CheckedChanged);
            // 
            // fromTextureObjectColorRB
            // 
            this.fromTextureObjectColorRB.AutoSize = true;
            this.fromTextureObjectColorRB.Location = new System.Drawing.Point(17, 103);
            this.fromTextureObjectColorRB.Name = "fromTextureObjectColorRB";
            this.fromTextureObjectColorRB.Size = new System.Drawing.Size(108, 21);
            this.fromTextureObjectColorRB.TabIndex = 1;
            this.fromTextureObjectColorRB.Text = "From texture";
            this.fromTextureObjectColorRB.UseVisualStyleBackColor = true;
            this.fromTextureObjectColorRB.CheckedChanged += new System.EventHandler(this.fromTextureObjectColorRB_CheckedChanged);
            // 
            // normalVectorGroupBox
            // 
            this.normalVectorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.normalVectorGroupBox.Controls.Add(this.fromTextureNomalVectorRB);
            this.normalVectorGroupBox.Controls.Add(this.defaultNormalVectorRB);
            this.normalVectorGroupBox.Location = new System.Drawing.Point(1158, 355);
            this.normalVectorGroupBox.Name = "normalVectorGroupBox";
            this.normalVectorGroupBox.Size = new System.Drawing.Size(131, 96);
            this.normalVectorGroupBox.TabIndex = 3;
            this.normalVectorGroupBox.TabStop = false;
            this.normalVectorGroupBox.Text = "Normal Vector";
            // 
            // fromTextureNomalVectorRB
            // 
            this.fromTextureNomalVectorRB.AutoSize = true;
            this.fromTextureNomalVectorRB.Location = new System.Drawing.Point(17, 59);
            this.fromTextureNomalVectorRB.Name = "fromTextureNomalVectorRB";
            this.fromTextureNomalVectorRB.Size = new System.Drawing.Size(108, 21);
            this.fromTextureNomalVectorRB.TabIndex = 3;
            this.fromTextureNomalVectorRB.Text = "From texture";
            this.fromTextureNomalVectorRB.UseVisualStyleBackColor = true;
            this.fromTextureNomalVectorRB.CheckedChanged += new System.EventHandler(this.fromTextureNomalVectorRB_CheckedChanged);
            // 
            // defaultNormalVectorRB
            // 
            this.defaultNormalVectorRB.AutoSize = true;
            this.defaultNormalVectorRB.Checked = true;
            this.defaultNormalVectorRB.Location = new System.Drawing.Point(18, 32);
            this.defaultNormalVectorRB.Name = "defaultNormalVectorRB";
            this.defaultNormalVectorRB.Size = new System.Drawing.Size(74, 21);
            this.defaultNormalVectorRB.TabIndex = 2;
            this.defaultNormalVectorRB.TabStop = true;
            this.defaultNormalVectorRB.Text = "Default";
            this.defaultNormalVectorRB.UseVisualStyleBackColor = true;
            this.defaultNormalVectorRB.CheckedChanged += new System.EventHandler(this.defaultNormalVectorRB_CheckedChanged);
            // 
            // lightPointGroupBox
            // 
            this.lightPointGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lightPointGroupBox.Controls.Add(this.defaultLightVectorRB);
            this.lightPointGroupBox.Controls.Add(this.fromSpiralLightVectorRB);
            this.lightPointGroupBox.Location = new System.Drawing.Point(1295, 355);
            this.lightPointGroupBox.Name = "lightPointGroupBox";
            this.lightPointGroupBox.Size = new System.Drawing.Size(131, 96);
            this.lightPointGroupBox.TabIndex = 4;
            this.lightPointGroupBox.TabStop = false;
            this.lightPointGroupBox.Text = "Light Point";
            // 
            // defaultLightVectorRB
            // 
            this.defaultLightVectorRB.AutoSize = true;
            this.defaultLightVectorRB.Checked = true;
            this.defaultLightVectorRB.Location = new System.Drawing.Point(19, 33);
            this.defaultLightVectorRB.Name = "defaultLightVectorRB";
            this.defaultLightVectorRB.Size = new System.Drawing.Size(74, 21);
            this.defaultLightVectorRB.TabIndex = 4;
            this.defaultLightVectorRB.TabStop = true;
            this.defaultLightVectorRB.Text = "Default";
            this.defaultLightVectorRB.UseVisualStyleBackColor = true;
            this.defaultLightVectorRB.CheckedChanged += new System.EventHandler(this.defaultLightVectorRB_CheckedChanged);
            // 
            // fromSpiralLightVectorRB
            // 
            this.fromSpiralLightVectorRB.AutoSize = true;
            this.fromSpiralLightVectorRB.Location = new System.Drawing.Point(17, 60);
            this.fromSpiralLightVectorRB.Name = "fromSpiralLightVectorRB";
            this.fromSpiralLightVectorRB.Size = new System.Drawing.Size(99, 21);
            this.fromSpiralLightVectorRB.TabIndex = 5;
            this.fromSpiralLightVectorRB.Text = "From spiral";
            this.fromSpiralLightVectorRB.UseVisualStyleBackColor = true;
            this.fromSpiralLightVectorRB.CheckedChanged += new System.EventHandler(this.fromSpiralLightVectorRB_CheckedChanged);
            // 
            // fillColorPrecisionGroupBox
            // 
            this.fillColorPrecisionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillColorPrecisionGroupBox.Controls.Add(this.interpolatedFillColorRB);
            this.fillColorPrecisionGroupBox.Controls.Add(this.preciseFillColorRB);
            this.fillColorPrecisionGroupBox.Location = new System.Drawing.Point(1158, 457);
            this.fillColorPrecisionGroupBox.Name = "fillColorPrecisionGroupBox";
            this.fillColorPrecisionGroupBox.Size = new System.Drawing.Size(268, 70);
            this.fillColorPrecisionGroupBox.TabIndex = 4;
            this.fillColorPrecisionGroupBox.TabStop = false;
            this.fillColorPrecisionGroupBox.Text = "Fill Color Precision";
            // 
            // interpolatedFillColorRB
            // 
            this.interpolatedFillColorRB.AutoSize = true;
            this.interpolatedFillColorRB.Location = new System.Drawing.Point(154, 33);
            this.interpolatedFillColorRB.Name = "interpolatedFillColorRB";
            this.interpolatedFillColorRB.Size = new System.Drawing.Size(104, 21);
            this.interpolatedFillColorRB.TabIndex = 7;
            this.interpolatedFillColorRB.Text = "Interpolated";
            this.interpolatedFillColorRB.UseVisualStyleBackColor = true;
            this.interpolatedFillColorRB.CheckedChanged += new System.EventHandler(this.interpolatedFillColorRB_CheckedChanged);
            // 
            // preciseFillColorRB
            // 
            this.preciseFillColorRB.AutoSize = true;
            this.preciseFillColorRB.Checked = true;
            this.preciseFillColorRB.Location = new System.Drawing.Point(18, 33);
            this.preciseFillColorRB.Name = "preciseFillColorRB";
            this.preciseFillColorRB.Size = new System.Drawing.Size(76, 21);
            this.preciseFillColorRB.TabIndex = 6;
            this.preciseFillColorRB.TabStop = true;
            this.preciseFillColorRB.Text = "Precise";
            this.preciseFillColorRB.UseVisualStyleBackColor = true;
            this.preciseFillColorRB.CheckedChanged += new System.EventHandler(this.preciseFillColorRB_CheckedChanged);
            // 
            // lambertModelFactorGroupBox
            // 
            this.lambertModelFactorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lambertModelFactorGroupBox.Controls.Add(this.lambertModelFactorTextBox);
            this.lambertModelFactorGroupBox.Controls.Add(this.lambertModelFactorTB);
            this.lambertModelFactorGroupBox.Location = new System.Drawing.Point(1158, 533);
            this.lambertModelFactorGroupBox.Name = "lambertModelFactorGroupBox";
            this.lambertModelFactorGroupBox.Size = new System.Drawing.Size(268, 98);
            this.lambertModelFactorGroupBox.TabIndex = 5;
            this.lambertModelFactorGroupBox.TabStop = false;
            this.lambertModelFactorGroupBox.Text = "Lambert Model Factor";
            // 
            // lambertModelFactorTextBox
            // 
            this.lambertModelFactorTextBox.Enabled = false;
            this.lambertModelFactorTextBox.Location = new System.Drawing.Point(188, 37);
            this.lambertModelFactorTextBox.Name = "lambertModelFactorTextBox";
            this.lambertModelFactorTextBox.Size = new System.Drawing.Size(44, 22);
            this.lambertModelFactorTextBox.TabIndex = 1;
            // 
            // lambertModelFactorTB
            // 
            this.lambertModelFactorTB.Location = new System.Drawing.Point(17, 36);
            this.lambertModelFactorTB.Maximum = 100;
            this.lambertModelFactorTB.Name = "lambertModelFactorTB";
            this.lambertModelFactorTB.Size = new System.Drawing.Size(158, 56);
            this.lambertModelFactorTB.TabIndex = 0;
            this.lambertModelFactorTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lambertModelFactorTB.Value = 100;
            this.lambertModelFactorTB.ValueChanged += new System.EventHandler(this.lambertModelFactorTB_ValueChanged);
            // 
            // reflectionFactorGroupBox
            // 
            this.reflectionFactorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reflectionFactorGroupBox.Controls.Add(this.reflectionFactorTextBox);
            this.reflectionFactorGroupBox.Controls.Add(this.reflectionFactorTB);
            this.reflectionFactorGroupBox.Location = new System.Drawing.Point(1158, 637);
            this.reflectionFactorGroupBox.Name = "reflectionFactorGroupBox";
            this.reflectionFactorGroupBox.Size = new System.Drawing.Size(268, 101);
            this.reflectionFactorGroupBox.TabIndex = 6;
            this.reflectionFactorGroupBox.TabStop = false;
            this.reflectionFactorGroupBox.Text = "Reflection Factor";
            // 
            // reflectionFactorTextBox
            // 
            this.reflectionFactorTextBox.Enabled = false;
            this.reflectionFactorTextBox.Location = new System.Drawing.Point(188, 36);
            this.reflectionFactorTextBox.Name = "reflectionFactorTextBox";
            this.reflectionFactorTextBox.Size = new System.Drawing.Size(44, 22);
            this.reflectionFactorTextBox.TabIndex = 2;
            // 
            // reflectionFactorTB
            // 
            this.reflectionFactorTB.Location = new System.Drawing.Point(17, 36);
            this.reflectionFactorTB.Maximum = 100;
            this.reflectionFactorTB.Name = "reflectionFactorTB";
            this.reflectionFactorTB.Size = new System.Drawing.Size(156, 56);
            this.reflectionFactorTB.TabIndex = 0;
            this.reflectionFactorTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.reflectionFactorTB.ValueChanged += new System.EventHandler(this.reflectionFactorTB_ValueChanged);
            // 
            // refletionLevelGroupBox
            // 
            this.refletionLevelGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refletionLevelGroupBox.Controls.Add(this.reflectionLevelTextBox);
            this.refletionLevelGroupBox.Controls.Add(this.reflectionLevelTB);
            this.refletionLevelGroupBox.Location = new System.Drawing.Point(1158, 744);
            this.refletionLevelGroupBox.Name = "refletionLevelGroupBox";
            this.refletionLevelGroupBox.Size = new System.Drawing.Size(268, 101);
            this.refletionLevelGroupBox.TabIndex = 7;
            this.refletionLevelGroupBox.TabStop = false;
            this.refletionLevelGroupBox.Text = "Reflection Level";
            // 
            // reflectionLevelTextBox
            // 
            this.reflectionLevelTextBox.Enabled = false;
            this.reflectionLevelTextBox.Location = new System.Drawing.Point(188, 36);
            this.reflectionLevelTextBox.Name = "reflectionLevelTextBox";
            this.reflectionLevelTextBox.Size = new System.Drawing.Size(44, 22);
            this.reflectionLevelTextBox.TabIndex = 3;
            // 
            // reflectionLevelTB
            // 
            this.reflectionLevelTB.Location = new System.Drawing.Point(17, 36);
            this.reflectionLevelTB.Maximum = 100;
            this.reflectionLevelTB.Minimum = 1;
            this.reflectionLevelTB.Name = "reflectionLevelTB";
            this.reflectionLevelTB.Size = new System.Drawing.Size(158, 56);
            this.reflectionLevelTB.TabIndex = 0;
            this.reflectionLevelTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.reflectionLevelTB.Value = 1;
            this.reflectionLevelTB.ValueChanged += new System.EventHandler(this.reflectionLevelTB_ValueChanged);
            // 
            // lightColorGroupBox
            // 
            this.lightColorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lightColorGroupBox.Controls.Add(this.pickedLightColorPictureBox);
            this.lightColorGroupBox.Controls.Add(this.pickLightColorButton);
            this.lightColorGroupBox.Location = new System.Drawing.Point(1158, 268);
            this.lightColorGroupBox.Name = "lightColorGroupBox";
            this.lightColorGroupBox.Size = new System.Drawing.Size(268, 81);
            this.lightColorGroupBox.TabIndex = 4;
            this.lightColorGroupBox.TabStop = false;
            this.lightColorGroupBox.Text = "Light Color";
            // 
            // pickedLightColorPictureBox
            // 
            this.pickedLightColorPictureBox.BackColor = System.Drawing.Color.White;
            this.pickedLightColorPictureBox.Location = new System.Drawing.Point(204, 35);
            this.pickedLightColorPictureBox.Name = "pickedLightColorPictureBox";
            this.pickedLightColorPictureBox.Size = new System.Drawing.Size(28, 26);
            this.pickedLightColorPictureBox.TabIndex = 4;
            this.pickedLightColorPictureBox.TabStop = false;
            // 
            // pickLightColorButton
            // 
            this.pickLightColorButton.Location = new System.Drawing.Point(39, 35);
            this.pickLightColorButton.Name = "pickLightColorButton";
            this.pickLightColorButton.Size = new System.Drawing.Size(145, 26);
            this.pickLightColorButton.TabIndex = 4;
            this.pickLightColorButton.Text = "Pick color";
            this.pickLightColorButton.UseVisualStyleBackColor = true;
            this.pickLightColorButton.Click += new System.EventHandler(this.pickLightColorButton_Click);
            // 
            // textureGroupBox
            // 
            this.textureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textureGroupBox.Controls.Add(this.textureComboBox);
            this.textureGroupBox.Location = new System.Drawing.Point(1158, 851);
            this.textureGroupBox.Name = "textureGroupBox";
            this.textureGroupBox.Size = new System.Drawing.Size(268, 82);
            this.textureGroupBox.TabIndex = 8;
            this.textureGroupBox.TabStop = false;
            this.textureGroupBox.Text = "Texture";
            // 
            // textureComboBox
            // 
            this.textureComboBox.FormattingEnabled = true;
            this.textureComboBox.Location = new System.Drawing.Point(17, 35);
            this.textureComboBox.Name = "textureComboBox";
            this.textureComboBox.Size = new System.Drawing.Size(235, 24);
            this.textureComboBox.TabIndex = 0;
            this.textureComboBox.SelectedIndexChanged += new System.EventHandler(this.textureComboBox_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1139, 926);
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // gridGB
            // 
            this.gridGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGB.Controls.Add(this.mLabel);
            this.gridGB.Controls.Add(this.nLabel);
            this.gridGB.Controls.Add(this.mTextBox);
            this.gridGB.Controls.Add(this.nTextBox);
            this.gridGB.Controls.Add(this.gridVisibleCheckBox);
            this.gridGB.Location = new System.Drawing.Point(1158, 29);
            this.gridGB.Name = "gridGB";
            this.gridGB.Size = new System.Drawing.Size(268, 88);
            this.gridGB.TabIndex = 10;
            this.gridGB.TabStop = false;
            this.gridGB.Text = "Grid";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mLabel.Location = new System.Drawing.Point(92, 39);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(25, 18);
            this.mLabel.TabIndex = 4;
            this.mLabel.Text = "M:";
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nLabel.Location = new System.Drawing.Point(15, 39);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(23, 18);
            this.nLabel.TabIndex = 3;
            this.nLabel.Text = "N:";
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(123, 35);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(28, 22);
            this.mTextBox.TabIndex = 2;
            this.mTextBox.Text = "0";
            this.mTextBox.TextChanged += new System.EventHandler(this.mTextBox_TextChanged);
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(44, 36);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(28, 22);
            this.nTextBox.TabIndex = 1;
            this.nTextBox.Text = "0";
            this.nTextBox.TextChanged += new System.EventHandler(this.nTextBox_TextChanged);
            // 
            // gridVisibleCheckBox
            // 
            this.gridVisibleCheckBox.AutoSize = true;
            this.gridVisibleCheckBox.Checked = true;
            this.gridVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridVisibleCheckBox.Location = new System.Drawing.Point(189, 37);
            this.gridVisibleCheckBox.Name = "gridVisibleCheckBox";
            this.gridVisibleCheckBox.Size = new System.Drawing.Size(69, 21);
            this.gridVisibleCheckBox.TabIndex = 0;
            this.gridVisibleCheckBox.Text = "visible";
            this.gridVisibleCheckBox.UseVisualStyleBackColor = true;
            this.gridVisibleCheckBox.CheckedChanged += new System.EventHandler(this.gridVisibleCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 945);
            this.Controls.Add(this.gridGB);
            this.Controls.Add(this.textureGroupBox);
            this.Controls.Add(this.lightColorGroupBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.refletionLevelGroupBox);
            this.Controls.Add(this.reflectionFactorGroupBox);
            this.Controls.Add(this.lambertModelFactorGroupBox);
            this.Controls.Add(this.fillColorPrecisionGroupBox);
            this.Controls.Add(this.lightPointGroupBox);
            this.Controls.Add(this.normalVectorGroupBox);
            this.Controls.Add(this.objectColorGroupBox);
            this.Controls.Add(this.menuLabel);
            this.Name = "MainForm";
            this.Text = "Polygon Filling by Michał Gozdera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.objectColorGroupBox.ResumeLayout(false);
            this.objectColorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedObjectColorPictureBox)).EndInit();
            this.normalVectorGroupBox.ResumeLayout(false);
            this.normalVectorGroupBox.PerformLayout();
            this.lightPointGroupBox.ResumeLayout(false);
            this.lightPointGroupBox.PerformLayout();
            this.fillColorPrecisionGroupBox.ResumeLayout(false);
            this.fillColorPrecisionGroupBox.PerformLayout();
            this.lambertModelFactorGroupBox.ResumeLayout(false);
            this.lambertModelFactorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lambertModelFactorTB)).EndInit();
            this.reflectionFactorGroupBox.ResumeLayout(false);
            this.reflectionFactorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionFactorTB)).EndInit();
            this.refletionLevelGroupBox.ResumeLayout(false);
            this.refletionLevelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionLevelTB)).EndInit();
            this.lightColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pickedLightColorPictureBox)).EndInit();
            this.textureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gridGB.ResumeLayout(false);
            this.gridGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.GroupBox objectColorGroupBox;
        private System.Windows.Forms.RadioButton fromTextureObjectColorRB;
        private System.Windows.Forms.RadioButton constantObjectColorRB;
        private System.Windows.Forms.GroupBox normalVectorGroupBox;
        private System.Windows.Forms.RadioButton fromTextureNomalVectorRB;
        private System.Windows.Forms.RadioButton defaultNormalVectorRB;
        private System.Windows.Forms.GroupBox lightPointGroupBox;
        private System.Windows.Forms.RadioButton fromSpiralLightVectorRB;
        private System.Windows.Forms.RadioButton defaultLightVectorRB;
        private System.Windows.Forms.GroupBox fillColorPrecisionGroupBox;
        private System.Windows.Forms.RadioButton interpolatedFillColorRB;
        private System.Windows.Forms.RadioButton preciseFillColorRB;
        private System.Windows.Forms.GroupBox lambertModelFactorGroupBox;
        private System.Windows.Forms.TrackBar lambertModelFactorTB;
        private System.Windows.Forms.GroupBox reflectionFactorGroupBox;
        private System.Windows.Forms.TrackBar reflectionFactorTB;
        private System.Windows.Forms.GroupBox refletionLevelGroupBox;
        private System.Windows.Forms.TrackBar reflectionLevelTB;
        private System.Windows.Forms.TextBox lambertModelFactorTextBox;
        private System.Windows.Forms.TextBox reflectionFactorTextBox;
        private System.Windows.Forms.TextBox reflectionLevelTextBox;
        private System.Windows.Forms.Button pickObjectColorButton;
        private System.Windows.Forms.PictureBox pickedObjectColorPictureBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox lightColorGroupBox;
        private System.Windows.Forms.PictureBox pickedLightColorPictureBox;
        private System.Windows.Forms.Button pickLightColorButton;
        private System.Windows.Forms.GroupBox textureGroupBox;
        private System.Windows.Forms.ComboBox textureComboBox;
        private System.Windows.Forms.GroupBox gridGB;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.CheckBox gridVisibleCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

