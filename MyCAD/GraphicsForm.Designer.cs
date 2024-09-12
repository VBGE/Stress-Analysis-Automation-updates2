namespace MyCAD
{
    partial class GraphicsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsForm));
            this.popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.ribbon = new System.Windows.Forms.Ribbon();
            this.drawTab = new System.Windows.Forms.RibbonTab();
            this.drawPanel = new System.Windows.Forms.RibbonPanel();
            this.line_Btn = new System.Windows.Forms.RibbonButton();
            this.move_btn = new System.Windows.Forms.RibbonButton();
            this.unselect_axis_btn = new System.Windows.Forms.RibbonButton();
            this.draw_x_btn = new System.Windows.Forms.RibbonButton();
            this.draw_y_btn = new System.Windows.Forms.RibbonButton();
            this.draw_z_btn = new System.Windows.Forms.RibbonButton();
            this.deleteLine_btn = new System.Windows.Forms.RibbonButton();
            this.clear_btn = new System.Windows.Forms.RibbonButton();
            this.calculateTab = new System.Windows.Forms.RibbonTab();
            this.calculatePanel = new System.Windows.Forms.RibbonPanel();
            this.setMaterial_btn = new System.Windows.Forms.RibbonButton();
            this.setInputValues_btn = new System.Windows.Forms.RibbonButton();
            this.Calculate_btn = new System.Windows.Forms.RibbonButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.coordinate_ToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.line_length = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Drawing_XZ_View = new System.Windows.Forms.PictureBox();
            this.Drawing_ZY_View = new System.Windows.Forms.PictureBox();
            this.Drawing_XY_View = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cz_print = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.iyy_print = new System.Windows.Forms.Label();
            this.ixx_print = new System.Windows.Forms.Label();
            this.cy_print = new System.Windows.Forms.Label();
            this.cx_print = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.izz_print = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.jwx_print = new System.Windows.Forms.Label();
            this.jwy_print = new System.Windows.Forms.Label();
            this.jwz_print = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.z1_print = new System.Windows.Forms.Label();
            this.z2_print = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Drawing = new System.Windows.Forms.PictureBox();
            this.deleteBtn = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.popup.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing_XZ_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing_ZY_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing_XY_View)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing)).BeginInit();
            this.SuspendLayout();
            // 
            // popup
            // 
            this.popup.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.drawXToolStripMenuItem,
            this.drawYToolStripMenuItem,
            this.drawZToolStripMenuItem});
            this.popup.Name = "menuStrip";
            this.popup.Size = new System.Drawing.Size(191, 188);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(190, 46);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // drawXToolStripMenuItem
            // 
            this.drawXToolStripMenuItem.Name = "drawXToolStripMenuItem";
            this.drawXToolStripMenuItem.Size = new System.Drawing.Size(190, 46);
            this.drawXToolStripMenuItem.Text = "Draw X";
            this.drawXToolStripMenuItem.Click += new System.EventHandler(this.drawXToolStripMenuItem_Click);
            // 
            // drawYToolStripMenuItem
            // 
            this.drawYToolStripMenuItem.Name = "drawYToolStripMenuItem";
            this.drawYToolStripMenuItem.Size = new System.Drawing.Size(190, 46);
            this.drawYToolStripMenuItem.Text = "Draw Y";
            this.drawYToolStripMenuItem.Click += new System.EventHandler(this.drawYToolStripMenuItem_Click);
            // 
            // drawZToolStripMenuItem
            // 
            this.drawZToolStripMenuItem.Name = "drawZToolStripMenuItem";
            this.drawZToolStripMenuItem.Size = new System.Drawing.Size(190, 46);
            this.drawZToolStripMenuItem.Text = "Draw Z";
            this.drawZToolStripMenuItem.Click += new System.EventHandler(this.drawZToolStripMenuItem_Click);
            // 
            // pointBtn
            // 
            this.pointBtn.Location = new System.Drawing.Point(0, 0);
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.Size = new System.Drawing.Size(75, 23);
            this.pointBtn.TabIndex = 12;
            // 
            // lineBtn
            // 
            this.lineBtn.Location = new System.Drawing.Point(0, 0);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(75, 23);
            this.lineBtn.TabIndex = 11;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(0, 0);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 10;
            // 
            // ribbon
            // 
            this.ribbon.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribbon.CaptionBarVisible = false;
            this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(1);
            this.ribbon.Minimized = false;
            this.ribbon.Name = "ribbon";
            // 
            // 
            // 
            this.ribbon.OrbDropDown.BorderRoundness = 8;
            this.ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon.OrbDropDown.Name = "";
            this.ribbon.OrbDropDown.TabIndex = 0;
            this.ribbon.PanelCaptionHeight = 10;
            this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon.Size = new System.Drawing.Size(2040, 140);
            this.ribbon.TabIndex = 6;
            this.ribbon.Tabs.Add(this.drawTab);
            this.ribbon.Tabs.Add(this.calculateTab);
            this.ribbon.Text = "ribbon1";
            // 
            // drawTab
            // 
            this.drawTab.Name = "drawTab";
            this.drawTab.Panels.Add(this.drawPanel);
            this.drawTab.Text = "Drawing";
            // 
            // drawPanel
            // 
            this.drawPanel.ButtonMoreEnabled = false;
            this.drawPanel.ButtonMoreVisible = false;
            this.drawPanel.Items.Add(this.line_Btn);
            this.drawPanel.Items.Add(this.move_btn);
            this.drawPanel.Items.Add(this.unselect_axis_btn);
            this.drawPanel.Items.Add(this.draw_x_btn);
            this.drawPanel.Items.Add(this.draw_y_btn);
            this.drawPanel.Items.Add(this.draw_z_btn);
            this.drawPanel.Items.Add(this.deleteLine_btn);
            this.drawPanel.Items.Add(this.clear_btn);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Text = "";
            // 
            // line_Btn
            // 
            this.line_Btn.Image = global::MyCAD.Properties.Resources.Line_R;
            this.line_Btn.LargeImage = global::MyCAD.Properties.Resources.Line_R;
            this.line_Btn.Name = "line_Btn";
            this.line_Btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("line_Btn.SmallImage")));
            this.line_Btn.Text = "Draw line";
            this.line_Btn.ToolTip = "Draw a line on canvas.";
            this.line_Btn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // move_btn
            // 
            this.move_btn.Enabled = false;
            this.move_btn.Image = ((System.Drawing.Image)(resources.GetObject("move_btn.Image")));
            this.move_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("move_btn.LargeImage")));
            this.move_btn.Name = "move_btn";
            this.move_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("move_btn.SmallImage")));
            this.move_btn.Text = "Move";
            this.move_btn.ToolTip = "To continue drawing but from other point in the space.";
            this.move_btn.Click += new System.EventHandler(this.MoveBtn_Click);
            // 
            // unselect_axis_btn
            // 
            this.unselect_axis_btn.Image = ((System.Drawing.Image)(resources.GetObject("unselect_axis_btn.Image")));
            this.unselect_axis_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("unselect_axis_btn.LargeImage")));
            this.unselect_axis_btn.Name = "unselect_axis_btn";
            this.unselect_axis_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("unselect_axis_btn.SmallImage")));
            this.unselect_axis_btn.Text = "Unselect axis";
            this.unselect_axis_btn.ToolTip = "Equivalent to right clicking on canvas -> Cancel.";
            this.unselect_axis_btn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // draw_x_btn
            // 
            this.draw_x_btn.Image = ((System.Drawing.Image)(resources.GetObject("draw_x_btn.Image")));
            this.draw_x_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("draw_x_btn.LargeImage")));
            this.draw_x_btn.Name = "draw_x_btn";
            this.draw_x_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("draw_x_btn.SmallImage")));
            this.draw_x_btn.Text = "Select \'x\' axis";
            this.draw_x_btn.ToolTip = "Equivalent to right clicking on canvas -> Draw X.";
            this.draw_x_btn.Click += new System.EventHandler(this.drawXToolStripMenuItem_Click);
            // 
            // draw_y_btn
            // 
            this.draw_y_btn.Image = ((System.Drawing.Image)(resources.GetObject("draw_y_btn.Image")));
            this.draw_y_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("draw_y_btn.LargeImage")));
            this.draw_y_btn.Name = "draw_y_btn";
            this.draw_y_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("draw_y_btn.SmallImage")));
            this.draw_y_btn.Text = "Select \'y\' axis";
            this.draw_y_btn.ToolTip = "Equivalent to right clicking on canvas -> Draw Y.";
            this.draw_y_btn.Click += new System.EventHandler(this.drawYToolStripMenuItem_Click);
            // 
            // draw_z_btn
            // 
            this.draw_z_btn.Image = ((System.Drawing.Image)(resources.GetObject("draw_z_btn.Image")));
            this.draw_z_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("draw_z_btn.LargeImage")));
            this.draw_z_btn.Name = "draw_z_btn";
            this.draw_z_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("draw_z_btn.SmallImage")));
            this.draw_z_btn.Text = "Select \'z\' axis";
            this.draw_z_btn.ToolTip = "Equivalent to right clicking on canvas -> Draw Z.";
            this.draw_z_btn.Click += new System.EventHandler(this.drawZToolStripMenuItem_Click);
            // 
            // deleteLine_btn
            // 
            this.deleteLine_btn.Image = ((System.Drawing.Image)(resources.GetObject("deleteLine_btn.Image")));
            this.deleteLine_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("deleteLine_btn.LargeImage")));
            this.deleteLine_btn.Name = "deleteLine_btn";
            this.deleteLine_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("deleteLine_btn.SmallImage")));
            this.deleteLine_btn.Text = "Delete line(s)";
            this.deleteLine_btn.ToolTip = "Deletes selected lines.";
            this.deleteLine_btn.Click += new System.EventHandler(this.deleteLine_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Image = ((System.Drawing.Image)(resources.GetObject("clear_btn.Image")));
            this.clear_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("clear_btn.LargeImage")));
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("clear_btn.SmallImage")));
            this.clear_btn.Text = "Clear all";
            this.clear_btn.ToolTip = "Clear all in canvases.";
            this.clear_btn.Click += new System.EventHandler(this.Clear_btn_click);
            // 
            // calculateTab
            // 
            this.calculateTab.Name = "calculateTab";
            this.calculateTab.Panels.Add(this.calculatePanel);
            this.calculateTab.Text = "Calculate";
            // 
            // calculatePanel
            // 
            this.calculatePanel.ButtonMoreVisible = false;
            this.calculatePanel.Items.Add(this.setMaterial_btn);
            this.calculatePanel.Items.Add(this.setInputValues_btn);
            this.calculatePanel.Items.Add(this.Calculate_btn);
            this.calculatePanel.Name = "calculatePanel";
            this.calculatePanel.Text = "";
            // 
            // setMaterial_btn
            // 
            this.setMaterial_btn.Enabled = false;
            this.setMaterial_btn.Image = ((System.Drawing.Image)(resources.GetObject("setMaterial_btn.Image")));
            this.setMaterial_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("setMaterial_btn.LargeImage")));
            this.setMaterial_btn.Name = "setMaterial_btn";
            this.setMaterial_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("setMaterial_btn.SmallImage")));
            this.setMaterial_btn.Text = "Set material";
            this.setMaterial_btn.Visible = false;
            this.setMaterial_btn.Click += new System.EventHandler(this.SetMaterial_btn);
            // 
            // setInputValues_btn
            // 
            this.setInputValues_btn.Enabled = false;
            this.setInputValues_btn.Image = ((System.Drawing.Image)(resources.GetObject("setInputValues_btn.Image")));
            this.setInputValues_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("setInputValues_btn.LargeImage")));
            this.setInputValues_btn.Name = "setInputValues_btn";
            this.setInputValues_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("setInputValues_btn.SmallImage")));
            this.setInputValues_btn.Text = "Input values";
            this.setInputValues_btn.Click += new System.EventHandler(this.SetInputValues_btn_Click);
            // 
            // Calculate_btn
            // 
            this.Calculate_btn.Image = ((System.Drawing.Image)(resources.GetObject("Calculate_btn.Image")));
            this.Calculate_btn.LargeImage = ((System.Drawing.Image)(resources.GetObject("Calculate_btn.LargeImage")));
            this.Calculate_btn.Name = "Calculate_btn";
            this.Calculate_btn.SmallImage = ((System.Drawing.Image)(resources.GetObject("Calculate_btn.SmallImage")));
            this.Calculate_btn.Text = "Calculate";
            this.Calculate_btn.Visible = false;
            this.Calculate_btn.Click += new System.EventHandler(this.Calculate_btn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinate_ToolStrip,
            this.line_length});
            this.statusStrip.Location = new System.Drawing.Point(0, 1286);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(2040, 58);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // coordinate_ToolStrip
            // 
            this.coordinate_ToolStrip.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.coordinate_ToolStrip.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.coordinate_ToolStrip.Name = "coordinate_ToolStrip";
            this.coordinate_ToolStrip.Size = new System.Drawing.Size(660, 53);
            this.coordinate_ToolStrip.Text = "Cursor coordinates: 0.000, 0.000, 0.000";
            // 
            // line_length
            // 
            this.line_length.Name = "line_length";
            this.line_length.Size = new System.Drawing.Size(332, 53);
            this.line_length.Text = "Length of line: 0.00";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1014, 49);
            this.label1.TabIndex = 16;
            this.label1.Text = "Isometric View - Drawing Canvas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1533, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1);
            this.label2.Size = new System.Drawing.Size(504, 51);
            this.label2.TabIndex = 17;
            this.label2.Text = "XY View";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1531, 573);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(1);
            this.label3.Size = new System.Drawing.Size(508, 51);
            this.label3.TabIndex = 18;
            this.label3.Text = "XZ View";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1023, 574);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(504, 49);
            this.label4.TabIndex = 19;
            this.label4.Text = "YZ View";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Drawing_XZ_View, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Drawing_ZY_View, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Drawing_XY_View, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2040, 1146);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // Drawing_XZ_View
            // 
            this.Drawing_XZ_View.BackColor = System.Drawing.SystemColors.Window;
            this.Drawing_XZ_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Drawing_XZ_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawing_XZ_View.Image = ((System.Drawing.Image)(resources.GetObject("Drawing_XZ_View.Image")));
            this.Drawing_XZ_View.Location = new System.Drawing.Point(1533, 628);
            this.Drawing_XZ_View.Name = "Drawing_XZ_View";
            this.Drawing_XZ_View.Padding = new System.Windows.Forms.Padding(1);
            this.Drawing_XZ_View.Size = new System.Drawing.Size(504, 515);
            this.Drawing_XZ_View.TabIndex = 14;
            this.Drawing_XZ_View.TabStop = false;
            this.Drawing_XZ_View.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_XZ_View_Paint);
            this.Drawing_XZ_View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawing_MouseMove);
            // 
            // Drawing_ZY_View
            // 
            this.Drawing_ZY_View.BackColor = System.Drawing.SystemColors.Window;
            this.Drawing_ZY_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Drawing_ZY_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawing_ZY_View.Image = ((System.Drawing.Image)(resources.GetObject("Drawing_ZY_View.Image")));
            this.Drawing_ZY_View.Location = new System.Drawing.Point(1023, 628);
            this.Drawing_ZY_View.Name = "Drawing_ZY_View";
            this.Drawing_ZY_View.Padding = new System.Windows.Forms.Padding(1);
            this.Drawing_ZY_View.Size = new System.Drawing.Size(504, 515);
            this.Drawing_ZY_View.TabIndex = 15;
            this.Drawing_ZY_View.TabStop = false;
            this.Drawing_ZY_View.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_ZY_View_Paint);
            this.Drawing_ZY_View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawing_MouseMove);
            // 
            // Drawing_XY_View
            // 
            this.Drawing_XY_View.BackColor = System.Drawing.SystemColors.Window;
            this.Drawing_XY_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Drawing_XY_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawing_XY_View.Image = ((System.Drawing.Image)(resources.GetObject("Drawing_XY_View.Image")));
            this.Drawing_XY_View.Location = new System.Drawing.Point(1533, 54);
            this.Drawing_XY_View.Name = "Drawing_XY_View";
            this.Drawing_XY_View.Padding = new System.Windows.Forms.Padding(1);
            this.Drawing_XY_View.Size = new System.Drawing.Size(504, 515);
            this.Drawing_XY_View.TabIndex = 13;
            this.Drawing_XY_View.TabStop = false;
            this.Drawing_XY_View.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_XY_View_Paint);
            this.Drawing_XY_View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawing_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cz_print, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.iyy_print, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.ixx_print, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cy_print, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cx_print, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.izz_print, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.jwx_print, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.jwy_print, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.jwz_print, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.z1_print, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.z2_print, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1023, 54);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(504, 515);
            this.tableLayoutPanel2.TabIndex = 20;
            this.tableLayoutPanel2.Visible = false;
            // 
            // cz_print
            // 
            this.cz_print.AutoSize = true;
            this.cz_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cz_print.Location = new System.Drawing.Point(255, 136);
            this.cz_print.Name = "cz_print";
            this.cz_print.Size = new System.Drawing.Size(68, 46);
            this.cz_print.TabIndex = 21;
            this.cz_print.Text = "0.0";
            this.cz_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 46);
            this.label15.TabIndex = 22;
            this.label15.Text = "Cz (in):";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 46);
            this.label14.TabIndex = 18;
            this.label14.Text = "Izz (in):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iyy_print
            // 
            this.iyy_print.AutoSize = true;
            this.iyy_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iyy_print.Location = new System.Drawing.Point(255, 230);
            this.iyy_print.Name = "iyy_print";
            this.iyy_print.Size = new System.Drawing.Size(68, 46);
            this.iyy_print.TabIndex = 17;
            this.iyy_print.Text = "0.0";
            this.iyy_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ixx_print
            // 
            this.ixx_print.AutoSize = true;
            this.ixx_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ixx_print.Location = new System.Drawing.Point(255, 183);
            this.ixx_print.Name = "ixx_print";
            this.ixx_print.Size = new System.Drawing.Size(68, 46);
            this.ixx_print.TabIndex = 16;
            this.ixx_print.Text = "0.0";
            this.ixx_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cy_print
            // 
            this.cy_print.AutoSize = true;
            this.cy_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cy_print.Location = new System.Drawing.Point(255, 89);
            this.cy_print.Name = "cy_print";
            this.cy_print.Size = new System.Drawing.Size(68, 46);
            this.cy_print.TabIndex = 15;
            this.cy_print.Text = "0.0";
            this.cy_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cx_print
            // 
            this.cx_print.AutoSize = true;
            this.cx_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cx_print.Location = new System.Drawing.Point(255, 42);
            this.cx_print.Name = "cx_print";
            this.cx_print.Size = new System.Drawing.Size(68, 46);
            this.cx_print.TabIndex = 14;
            this.cx_print.Text = "0.0";
            this.cx_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 46);
            this.label10.TabIndex = 6;
            this.label10.Text = "Cx (in):";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 46);
            this.label11.TabIndex = 7;
            this.label11.Text = "Cy (in):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 46);
            this.label12.TabIndex = 8;
            this.label12.Text = "Ixx (in):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 46);
            this.label13.TabIndex = 9;
            this.label13.Text = "Iyy (in):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // izz_print
            // 
            this.izz_print.AutoSize = true;
            this.izz_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.izz_print.Location = new System.Drawing.Point(255, 277);
            this.izz_print.Name = "izz_print";
            this.izz_print.Size = new System.Drawing.Size(68, 46);
            this.izz_print.TabIndex = 19;
            this.izz_print.Text = "0.0";
            this.izz_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 46);
            this.label5.TabIndex = 23;
            this.label5.Text = "Jwx:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 46);
            this.label6.TabIndex = 24;
            this.label6.Text = "Jwy:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 418);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 46);
            this.label7.TabIndex = 25;
            this.label7.Text = "Jwz:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // jwx_print
            // 
            this.jwx_print.AutoSize = true;
            this.jwx_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jwx_print.Location = new System.Drawing.Point(255, 324);
            this.jwx_print.Name = "jwx_print";
            this.jwx_print.Size = new System.Drawing.Size(68, 46);
            this.jwx_print.TabIndex = 26;
            this.jwx_print.Text = "0.0";
            this.jwx_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jwx_print.Visible = false;
            // 
            // jwy_print
            // 
            this.jwy_print.AutoSize = true;
            this.jwy_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jwy_print.Location = new System.Drawing.Point(255, 371);
            this.jwy_print.Name = "jwy_print";
            this.jwy_print.Size = new System.Drawing.Size(68, 46);
            this.jwy_print.TabIndex = 27;
            this.jwy_print.Text = "0.0";
            this.jwy_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jwy_print.Visible = false;
            // 
            // jwz_print
            // 
            this.jwz_print.AutoSize = true;
            this.jwz_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jwz_print.Location = new System.Drawing.Point(255, 418);
            this.jwz_print.Name = "jwz_print";
            this.jwz_print.Size = new System.Drawing.Size(68, 46);
            this.jwz_print.TabIndex = 28;
            this.jwz_print.Text = "0.0";
            this.jwz_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jwz_print.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 46);
            this.label8.TabIndex = 29;
            this.label8.Text = "Z1:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 46);
            this.label9.TabIndex = 30;
            this.label9.Text = "Z2:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Visible = false;
            // 
            // z1_print
            // 
            this.z1_print.AutoSize = true;
            this.z1_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1_print.Location = new System.Drawing.Point(255, 465);
            this.z1_print.Name = "z1_print";
            this.z1_print.Size = new System.Drawing.Size(68, 46);
            this.z1_print.TabIndex = 31;
            this.z1_print.Text = "0.0";
            this.z1_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.z1_print.Visible = false;
            // 
            // z2_print
            // 
            this.z2_print.AutoSize = true;
            this.z2_print.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2_print.Location = new System.Drawing.Point(255, 512);
            this.z2_print.Name = "z2_print";
            this.z2_print.Size = new System.Drawing.Size(68, 46);
            this.z2_print.TabIndex = 32;
            this.z2_print.Text = "0.0";
            this.z2_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.z2_print.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label16, 2);
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Calibri", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(496, 40);
            this.label16.TabIndex = 33;
            this.label16.Text = "Reference";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Drawing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(1014, 1089);
            this.panel1.TabIndex = 21;
            // 
            // Drawing
            // 
            this.Drawing.BackColor = System.Drawing.SystemColors.Window;
            this.Drawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Drawing.ContextMenuStrip = this.popup;
            this.Drawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawing.Image = ((System.Drawing.Image)(resources.GetObject("Drawing.Image")));
            this.Drawing.Location = new System.Drawing.Point(0, 0);
            this.Drawing.Name = "Drawing";
            this.Drawing.Padding = new System.Windows.Forms.Padding(1);
            this.Drawing.Size = new System.Drawing.Size(1014, 1089);
            this.Drawing.TabIndex = 0;
            this.Drawing.TabStop = false;
            this.Drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingCanvas_Paint);
            this.Drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawing_MouseDown);
            this.Drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawing_MouseMove);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("deleteBtn.LargeImage")));
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("deleteBtn.SmallImage")));
            this.deleteBtn.Text = "Delete";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Delete";
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2040, 1344);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.lineBtn);
            this.Controls.Add(this.pointBtn);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(2072, 1432);
            this.Name = "GraphicsForm";
            this.Text = "Form1";
            this.popup.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing_XZ_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing_ZY_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drawing_XY_View)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Drawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Drawing;
        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.ContextMenuStrip popup;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Ribbon ribbon;
        private System.Windows.Forms.RibbonTab drawTab;
        private System.Windows.Forms.RibbonPanel drawPanel;
        private System.Windows.Forms.RibbonButton line_Btn;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel coordinate_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem drawXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawZToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel line_length;
        private System.Windows.Forms.PictureBox Drawing_XY_View;
        private System.Windows.Forms.PictureBox Drawing_XZ_View;
        private System.Windows.Forms.PictureBox Drawing_ZY_View;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RibbonButton unselect_axis_btn;
        private System.Windows.Forms.RibbonButton draw_x_btn;
        private System.Windows.Forms.RibbonButton draw_y_btn;
        private System.Windows.Forms.RibbonButton draw_z_btn;
        private System.Windows.Forms.RibbonButton clear_btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label iyy_print;
        private System.Windows.Forms.Label ixx_print;
        private System.Windows.Forms.Label cy_print;
        private System.Windows.Forms.Label cx_print;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label izz_print;
        private System.Windows.Forms.Label cz_print;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label jwx_print;
        private System.Windows.Forms.Label jwy_print;
        private System.Windows.Forms.Label jwz_print;
        private System.Windows.Forms.RibbonButton move_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RibbonTab calculateTab;
        private System.Windows.Forms.RibbonPanel calculatePanel;
        private System.Windows.Forms.RibbonButton setMaterial_btn;
        private System.Windows.Forms.RibbonButton setInputValues_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label z1_print;
        private System.Windows.Forms.Label z2_print;
        private System.Windows.Forms.RibbonButton deleteLine_btn;
        private System.Windows.Forms.RibbonButton deleteBtn;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RibbonButton Calculate_btn;
    }
}

