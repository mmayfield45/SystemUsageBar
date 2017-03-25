namespace SystemUsageBar
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.gbBoxStyle = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkFlatBackground = new System.Windows.Forms.CheckBox();
            this.checkFlatBorder = new System.Windows.Forms.CheckBox();
            this.btnBoxColour = new System.Windows.Forms.Button();
            this.btnBorderColour = new System.Windows.Forms.Button();
            this.cbButHoverColor = new System.Windows.Forms.CheckBox();
            this.btnButHoverColor = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.cbAlwaysShowCpu = new System.Windows.Forms.CheckBox();
            this.btnRamGraphColor = new System.Windows.Forms.Button();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.lblRamGraphColor = new System.Windows.Forms.Label();
            this.btnCpuGraphColour = new System.Windows.Forms.Button();
            this.lblCpuGraphColour = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.blbTextColor = new System.Windows.Forms.Label();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.comboElementStyle = new System.Windows.Forms.ComboBox();
            this.tpCPU = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbCpuEnabled = new System.Windows.Forms.CheckBox();
            this.tbRAM = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cbExpandOnHover = new System.Windows.Forms.CheckBox();
            this.cbRamEnabled = new System.Windows.Forms.CheckBox();
            this.tpMediaInfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbMediaInfoEnabled = new System.Windows.Forms.CheckBox();
            this.cbTrackSongLengths = new System.Windows.Forms.CheckBox();
            this.btnTrackingColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProgressColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbBoxStyle.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.tabs.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpCPU.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbRAM.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tpMediaInfo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(256, 8);
            this.btnOk.MinimumSize = new System.Drawing.Size(75, 24);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Close";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbBoxStyle
            // 
            this.gbBoxStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBoxStyle.Controls.Add(this.tableLayoutPanel3);
            this.gbBoxStyle.Location = new System.Drawing.Point(6, 88);
            this.gbBoxStyle.Name = "gbBoxStyle";
            this.gbBoxStyle.Size = new System.Drawing.Size(308, 74);
            this.gbBoxStyle.TabIndex = 2;
            this.gbBoxStyle.TabStop = false;
            this.gbBoxStyle.Text = "Flat style options";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.checkFlatBackground, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkFlatBorder, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBoxColour, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnBorderColour, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(132, 52);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // checkFlatBackground
            // 
            this.checkFlatBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkFlatBackground.AutoSize = true;
            this.checkFlatBackground.Location = new System.Drawing.Point(3, 30);
            this.checkFlatBackground.Name = "checkFlatBackground";
            this.checkFlatBackground.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkFlatBackground.Size = new System.Drawing.Size(90, 17);
            this.checkFlatBackground.TabIndex = 5;
            this.checkFlatBackground.Text = "Background:";
            this.checkFlatBackground.UseVisualStyleBackColor = true;
            this.checkFlatBackground.CheckedChanged += new System.EventHandler(this.checkFlatBackground_CheckedChanged);
            // 
            // checkFlatBorder
            // 
            this.checkFlatBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkFlatBorder.AutoSize = true;
            this.checkFlatBorder.Location = new System.Drawing.Point(3, 4);
            this.checkFlatBorder.Name = "checkFlatBorder";
            this.checkFlatBorder.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkFlatBorder.Size = new System.Drawing.Size(63, 17);
            this.checkFlatBorder.TabIndex = 4;
            this.checkFlatBorder.Text = "Border:";
            this.checkFlatBorder.UseVisualStyleBackColor = true;
            this.checkFlatBorder.CheckedChanged += new System.EventHandler(this.checkFlatBorder_CheckedChanged);
            // 
            // btnBoxColour
            // 
            this.btnBoxColour.BackColor = System.Drawing.Color.Black;
            this.btnBoxColour.Location = new System.Drawing.Point(99, 29);
            this.btnBoxColour.Name = "btnBoxColour";
            this.btnBoxColour.Size = new System.Drawing.Size(30, 20);
            this.btnBoxColour.TabIndex = 1;
            this.btnBoxColour.UseVisualStyleBackColor = false;
            this.btnBoxColour.Click += new System.EventHandler(this.btnBoxColour_Click);
            // 
            // btnBorderColour
            // 
            this.btnBorderColour.BackColor = System.Drawing.Color.Black;
            this.btnBorderColour.Location = new System.Drawing.Point(99, 3);
            this.btnBorderColour.Name = "btnBorderColour";
            this.btnBorderColour.Size = new System.Drawing.Size(30, 20);
            this.btnBorderColour.TabIndex = 0;
            this.btnBorderColour.UseVisualStyleBackColor = false;
            this.btnBorderColour.Click += new System.EventHandler(this.btnBorderColour_Click);
            // 
            // cbButHoverColor
            // 
            this.cbButHoverColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbButHoverColor.AutoSize = true;
            this.cbButHoverColor.Location = new System.Drawing.Point(3, 30);
            this.cbButHoverColor.Name = "cbButHoverColor";
            this.cbButHoverColor.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbButHoverColor.Size = new System.Drawing.Size(89, 17);
            this.cbButHoverColor.TabIndex = 15;
            this.cbButHoverColor.Text = "Fill on hover:";
            this.cbButHoverColor.UseVisualStyleBackColor = true;
            this.cbButHoverColor.CheckedChanged += new System.EventHandler(this.cbButHoverColor_CheckedChanged);
            // 
            // btnButHoverColor
            // 
            this.btnButHoverColor.BackColor = System.Drawing.Color.Black;
            this.btnButHoverColor.Location = new System.Drawing.Point(98, 29);
            this.btnButHoverColor.Name = "btnButHoverColor";
            this.btnButHoverColor.Size = new System.Drawing.Size(30, 20);
            this.btnButHoverColor.TabIndex = 13;
            this.btnButHoverColor.UseVisualStyleBackColor = false;
            this.btnButHoverColor.Click += new System.EventHandler(this.btnButHoverColor_Click);
            // 
            // lblSize
            // 
            this.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 55);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 11;
            this.lblSize.Text = "Size:";
            // 
            // cbAlwaysShowCpu
            // 
            this.cbAlwaysShowCpu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAlwaysShowCpu.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cbAlwaysShowCpu, 2);
            this.cbAlwaysShowCpu.Location = new System.Drawing.Point(3, 78);
            this.cbAlwaysShowCpu.Name = "cbAlwaysShowCpu";
            this.cbAlwaysShowCpu.Size = new System.Drawing.Size(114, 17);
            this.cbAlwaysShowCpu.TabIndex = 12;
            this.cbAlwaysShowCpu.Text = "Always Show CPU";
            this.cbAlwaysShowCpu.UseVisualStyleBackColor = true;
            this.cbAlwaysShowCpu.CheckedChanged += new System.EventHandler(this.cbAlwaysShowCpu_CheckedChanged);
            // 
            // btnRamGraphColor
            // 
            this.btnRamGraphColor.BackColor = System.Drawing.Color.Black;
            this.btnRamGraphColor.Location = new System.Drawing.Point(83, 26);
            this.btnRamGraphColor.Name = "btnRamGraphColor";
            this.btnRamGraphColor.Size = new System.Drawing.Size(30, 20);
            this.btnRamGraphColor.TabIndex = 8;
            this.btnRamGraphColor.UseVisualStyleBackColor = false;
            this.btnRamGraphColor.Click += new System.EventHandler(this.btnRamGraphColor_Click);
            // 
            // nudSize
            // 
            this.nudSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudSize.Location = new System.Drawing.Point(83, 52);
            this.nudSize.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(65, 20);
            this.nudSize.TabIndex = 10;
            this.nudSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblRamGraphColor
            // 
            this.lblRamGraphColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRamGraphColor.AutoSize = true;
            this.lblRamGraphColor.Location = new System.Drawing.Point(3, 29);
            this.lblRamGraphColor.Name = "lblRamGraphColor";
            this.lblRamGraphColor.Size = new System.Drawing.Size(34, 13);
            this.lblRamGraphColor.TabIndex = 9;
            this.lblRamGraphColor.Text = "Color:";
            // 
            // btnCpuGraphColour
            // 
            this.btnCpuGraphColour.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCpuGraphColour.BackColor = System.Drawing.Color.Black;
            this.btnCpuGraphColour.Location = new System.Drawing.Point(83, 26);
            this.btnCpuGraphColour.Name = "btnCpuGraphColour";
            this.btnCpuGraphColour.Size = new System.Drawing.Size(30, 20);
            this.btnCpuGraphColour.TabIndex = 6;
            this.btnCpuGraphColour.UseVisualStyleBackColor = false;
            this.btnCpuGraphColour.Click += new System.EventHandler(this.btnCpuGraphColour_Click);
            // 
            // lblCpuGraphColour
            // 
            this.lblCpuGraphColour.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCpuGraphColour.AutoSize = true;
            this.lblCpuGraphColour.Location = new System.Drawing.Point(3, 29);
            this.lblCpuGraphColour.Name = "lblCpuGraphColour";
            this.lblCpuGraphColour.Size = new System.Drawing.Size(34, 13);
            this.lblCpuGraphColour.TabIndex = 7;
            this.lblCpuGraphColour.Text = "Color:";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tpGeneral);
            this.tabs.Controls.Add(this.tpCPU);
            this.tabs.Controls.Add(this.tbRAM);
            this.tabs.Controls.Add(this.tpMediaInfo);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(8, 8);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(328, 218);
            this.tabs.TabIndex = 5;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.tableLayoutPanel2);
            this.tpGeneral.Controls.Add(this.gbBoxStyle);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(320, 192);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.blbTextColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTextColor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbButHoverColor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnButHoverColor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboElementStyle, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 79);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Element style:";
            // 
            // blbTextColor
            // 
            this.blbTextColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.blbTextColor.AutoSize = true;
            this.blbTextColor.Location = new System.Drawing.Point(3, 6);
            this.blbTextColor.Name = "blbTextColor";
            this.blbTextColor.Size = new System.Drawing.Size(57, 13);
            this.blbTextColor.TabIndex = 7;
            this.blbTextColor.Text = "Text color:";
            // 
            // btnTextColor
            // 
            this.btnTextColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTextColor.BackColor = System.Drawing.Color.Black;
            this.btnTextColor.Location = new System.Drawing.Point(98, 3);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(30, 20);
            this.btnTextColor.TabIndex = 6;
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // comboElementStyle
            // 
            this.comboElementStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboElementStyle.FormattingEnabled = true;
            this.comboElementStyle.Items.AddRange(new object[] {
            "None",
            "3D",
            "Flat"});
            this.comboElementStyle.Location = new System.Drawing.Point(98, 55);
            this.comboElementStyle.Name = "comboElementStyle";
            this.comboElementStyle.Size = new System.Drawing.Size(61, 21);
            this.comboElementStyle.TabIndex = 16;
            this.comboElementStyle.SelectedIndexChanged += new System.EventHandler(this.comboElementStyle_SelectedIndexChanged);
            // 
            // tpCPU
            // 
            this.tpCPU.Controls.Add(this.tableLayoutPanel1);
            this.tpCPU.Location = new System.Drawing.Point(4, 22);
            this.tpCPU.Name = "tpCPU";
            this.tpCPU.Padding = new System.Windows.Forms.Padding(3);
            this.tpCPU.Size = new System.Drawing.Size(320, 192);
            this.tpCPU.TabIndex = 1;
            this.tpCPU.Text = "CPU";
            this.tpCPU.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbAlwaysShowCpu, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCpuGraphColour, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSize, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCpuGraphColour, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbCpuEnabled, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(151, 98);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // cbCpuEnabled
            // 
            this.cbCpuEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbCpuEnabled.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cbCpuEnabled, 2);
            this.cbCpuEnabled.Location = new System.Drawing.Point(3, 3);
            this.cbCpuEnabled.Name = "cbCpuEnabled";
            this.cbCpuEnabled.Size = new System.Drawing.Size(143, 17);
            this.cbCpuEnabled.TabIndex = 13;
            this.cbCpuEnabled.Text = "Enabled (requires restart)";
            this.cbCpuEnabled.UseVisualStyleBackColor = true;
            this.cbCpuEnabled.CheckedChanged += new System.EventHandler(this.cbCpuEnabled_CheckedChanged);
            // 
            // tbRAM
            // 
            this.tbRAM.Controls.Add(this.tableLayoutPanel5);
            this.tbRAM.Location = new System.Drawing.Point(4, 22);
            this.tbRAM.Name = "tbRAM";
            this.tbRAM.Size = new System.Drawing.Size(320, 192);
            this.tbRAM.TabIndex = 2;
            this.tbRAM.Text = "RAM";
            this.tbRAM.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.cbExpandOnHover, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnRamGraphColor, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblRamGraphColor, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cbRamEnabled, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(149, 72);
            this.tableLayoutPanel5.TabIndex = 17;
            // 
            // cbExpandOnHover
            // 
            this.cbExpandOnHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbExpandOnHover.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.cbExpandOnHover, 2);
            this.cbExpandOnHover.Location = new System.Drawing.Point(3, 52);
            this.cbExpandOnHover.Name = "cbExpandOnHover";
            this.cbExpandOnHover.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbExpandOnHover.Size = new System.Drawing.Size(113, 17);
            this.cbExpandOnHover.TabIndex = 16;
            this.cbExpandOnHover.Text = "Expand on hover:";
            this.cbExpandOnHover.UseVisualStyleBackColor = true;
            this.cbExpandOnHover.CheckedChanged += new System.EventHandler(this.cbExpandOnHover_CheckedChanged);
            // 
            // cbRamEnabled
            // 
            this.cbRamEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbRamEnabled.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.cbRamEnabled, 2);
            this.cbRamEnabled.Location = new System.Drawing.Point(3, 3);
            this.cbRamEnabled.Name = "cbRamEnabled";
            this.cbRamEnabled.Size = new System.Drawing.Size(143, 17);
            this.cbRamEnabled.TabIndex = 18;
            this.cbRamEnabled.Text = "Enabled (requires restart)";
            this.cbRamEnabled.UseVisualStyleBackColor = true;
            this.cbRamEnabled.CheckedChanged += new System.EventHandler(this.cbRamEnabled_CheckedChanged);
            // 
            // tpMediaInfo
            // 
            this.tpMediaInfo.Controls.Add(this.tableLayoutPanel4);
            this.tpMediaInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMediaInfo.Name = "tpMediaInfo";
            this.tpMediaInfo.Size = new System.Drawing.Size(320, 192);
            this.tpMediaInfo.TabIndex = 3;
            this.tpMediaInfo.Text = "Media Info";
            this.tpMediaInfo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.cbMediaInfoEnabled, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbTrackSongLengths, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnTrackingColor, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnProgressColor, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(173, 98);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // cbMediaInfoEnabled
            // 
            this.cbMediaInfoEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbMediaInfoEnabled.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.cbMediaInfoEnabled, 2);
            this.cbMediaInfoEnabled.Location = new System.Drawing.Point(3, 3);
            this.cbMediaInfoEnabled.Name = "cbMediaInfoEnabled";
            this.cbMediaInfoEnabled.Size = new System.Drawing.Size(143, 17);
            this.cbMediaInfoEnabled.TabIndex = 19;
            this.cbMediaInfoEnabled.Text = "Enabled (requires restart)";
            this.cbMediaInfoEnabled.UseVisualStyleBackColor = true;
            this.cbMediaInfoEnabled.CheckedChanged += new System.EventHandler(this.cbMediaInfoEnabled_CheckedChanged);
            // 
            // cbTrackSongLengths
            // 
            this.cbTrackSongLengths.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbTrackSongLengths.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.cbTrackSongLengths, 2);
            this.cbTrackSongLengths.Location = new System.Drawing.Point(3, 52);
            this.cbTrackSongLengths.Name = "cbTrackSongLengths";
            this.cbTrackSongLengths.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbTrackSongLengths.Size = new System.Drawing.Size(167, 17);
            this.cbTrackSongLengths.TabIndex = 15;
            this.cbTrackSongLengths.Text = "Track unknown song lengths";
            this.cbTrackSongLengths.UseVisualStyleBackColor = true;
            this.cbTrackSongLengths.CheckedChanged += new System.EventHandler(this.cbTrackSongLengths_CheckedChanged);
            // 
            // btnTrackingColor
            // 
            this.btnTrackingColor.BackColor = System.Drawing.Color.Black;
            this.btnTrackingColor.Location = new System.Drawing.Point(87, 75);
            this.btnTrackingColor.Name = "btnTrackingColor";
            this.btnTrackingColor.Size = new System.Drawing.Size(30, 20);
            this.btnTrackingColor.TabIndex = 13;
            this.btnTrackingColor.UseVisualStyleBackColor = false;
            this.btnTrackingColor.Click += new System.EventHandler(this.btnTrackingColor_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tracking color:";
            // 
            // btnProgressColor
            // 
            this.btnProgressColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnProgressColor.BackColor = System.Drawing.Color.Black;
            this.btnProgressColor.Location = new System.Drawing.Point(87, 26);
            this.btnProgressColor.Name = "btnProgressColor";
            this.btnProgressColor.Size = new System.Drawing.Size(30, 20);
            this.btnProgressColor.TabIndex = 6;
            this.btnProgressColor.UseVisualStyleBackColor = false;
            this.btnProgressColor.Click += new System.EventHandler(this.btnProgressColor_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Progress color:";
            // 
            // panelButtons
            // 
            this.panelButtons.AutoSize = true;
            this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(0, 234);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelButtons.Size = new System.Drawing.Size(344, 40);
            this.panelButtons.TabIndex = 6;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Window;
            this.panelMain.Controls.Add(this.tabs);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(8);
            this.panelMain.Size = new System.Drawing.Size(344, 234);
            this.panelMain.TabIndex = 7;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 274);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Usage Bar Options";
            this.gbBoxStyle.ResumeLayout(false);
            this.gbBoxStyle.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpCPU.ResumeLayout(false);
            this.tpCPU.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbRAM.ResumeLayout(false);
            this.tbRAM.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tpMediaInfo.ResumeLayout(false);
            this.tpMediaInfo.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gbBoxStyle;
        private System.Windows.Forms.Button btnBorderColour;
        private System.Windows.Forms.CheckBox checkFlatBackground;
        private System.Windows.Forms.CheckBox checkFlatBorder;
        private System.Windows.Forms.Button btnBoxColour;
        private System.Windows.Forms.Button btnCpuGraphColour;
        private System.Windows.Forms.Label lblCpuGraphColour;
        private System.Windows.Forms.Button btnRamGraphColor;
        private System.Windows.Forms.Label lblRamGraphColor;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.CheckBox cbAlwaysShowCpu;
        private System.Windows.Forms.CheckBox cbButHoverColor;
        private System.Windows.Forms.Button btnButHoverColor;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpCPU;
        private System.Windows.Forms.TabPage tbRAM;
        private System.Windows.Forms.TabPage tpMediaInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label blbTextColor;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboElementStyle;
        private System.Windows.Forms.CheckBox cbExpandOnHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProgressColor;
        private System.Windows.Forms.CheckBox cbTrackSongLengths;
        private System.Windows.Forms.Button btnTrackingColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox cbCpuEnabled;
        private System.Windows.Forms.CheckBox cbRamEnabled;
        private System.Windows.Forms.CheckBox cbMediaInfoEnabled;
    }
}

