namespace PRTHandler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbox_Path = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_progress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nxPath = new System.Windows.Forms.TextBox();
            this.btn_browseNX = new System.Windows.Forms.Button();
            this.lb_path = new System.Windows.Forms.Label();
            this.cbox_function = new System.Windows.Forms.ComboBox();
            this.btn_execute = new System.Windows.Forms.Button();
            this.btn_addPrt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_maxPaperSize = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_browserPath = new System.Windows.Forms.Button();
            this.btn_clearPath = new System.Windows.Forms.Button();
            this.btn_removePrt = new System.Windows.Forms.Button();
            this.ColumnPrtFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrtFileName,
            this.ColumnResult});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(544, 318);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // cbox_Path
            // 
            this.cbox_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbox_Path.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbox_Path.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Path.FormattingEnabled = true;
            this.cbox_Path.Location = new System.Drawing.Point(218, 33);
            this.cbox_Path.Name = "cbox_Path";
            this.cbox_Path.Size = new System.Drawing.Size(257, 20);
            this.cbox_Path.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 437);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(483, 15);
            this.progressBar1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(542, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = ".";
            this.toolStripStatusLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // lb_progress
            // 
            this.lb_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_progress.AutoSize = true;
            this.lb_progress.Location = new System.Drawing.Point(521, 439);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(29, 12);
            this.lb_progress.TabIndex = 7;
            this.lb_progress.Text = "idle";
            this.lb_progress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "UGII_BASE_DIR";
            // 
            // tb_nxPath
            // 
            this.tb_nxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_nxPath.Location = new System.Drawing.Point(101, 6);
            this.tb_nxPath.Name = "tb_nxPath";
            this.tb_nxPath.Size = new System.Drawing.Size(374, 21);
            this.tb_nxPath.TabIndex = 9;
            // 
            // btn_browseNX
            // 
            this.btn_browseNX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browseNX.Location = new System.Drawing.Point(481, 6);
            this.btn_browseNX.Name = "btn_browseNX";
            this.btn_browseNX.Size = new System.Drawing.Size(75, 23);
            this.btn_browseNX.TabIndex = 10;
            this.btn_browseNX.Text = "Browser";
            this.btn_browseNX.UseVisualStyleBackColor = true;
            this.btn_browseNX.Click += new System.EventHandler(this.btn_browseNX_Click);
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Location = new System.Drawing.Point(134, 36);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(47, 12);
            this.lb_path.TabIndex = 5;
            this.lb_path.Text = "Printer";
            // 
            // cbox_function
            // 
            this.cbox_function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_function.FormattingEnabled = true;
            this.cbox_function.Items.AddRange(new object[] {
            "print",
            "dwg"});
            this.cbox_function.Location = new System.Drawing.Point(72, 33);
            this.cbox_function.Name = "cbox_function";
            this.cbox_function.Size = new System.Drawing.Size(56, 20);
            this.cbox_function.TabIndex = 12;
            this.cbox_function.SelectedIndexChanged += new System.EventHandler(this.cbox_function_SelectedIndexChanged);
            // 
            // btn_execute
            // 
            this.btn_execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_execute.Location = new System.Drawing.Point(481, 408);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(75, 23);
            this.btn_execute.TabIndex = 11;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // btn_addPrt
            // 
            this.btn_addPrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addPrt.Location = new System.Drawing.Point(342, 408);
            this.btn_addPrt.Name = "btn_addPrt";
            this.btn_addPrt.Size = new System.Drawing.Size(23, 23);
            this.btn_addPrt.TabIndex = 3;
            this.btn_addPrt.Text = "+";
            this.btn_addPrt.UseVisualStyleBackColor = true;
            this.btn_addPrt.Click += new System.EventHandler(this.btn_addPrt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Function";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cbox_maxPaperSize);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 39);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // cbox_maxPaperSize
            // 
            this.cbox_maxPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_maxPaperSize.FormattingEnabled = true;
            this.cbox_maxPaperSize.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.cbox_maxPaperSize.Location = new System.Drawing.Point(109, 14);
            this.cbox_maxPaperSize.Name = "cbox_maxPaperSize";
            this.cbox_maxPaperSize.Size = new System.Drawing.Size(60, 20);
            this.cbox_maxPaperSize.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "Max paper size A";
            // 
            // btn_browserPath
            // 
            this.btn_browserPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browserPath.Location = new System.Drawing.Point(481, 33);
            this.btn_browserPath.Name = "btn_browserPath";
            this.btn_browserPath.Size = new System.Drawing.Size(75, 23);
            this.btn_browserPath.TabIndex = 15;
            this.btn_browserPath.Text = "Browser";
            this.btn_browserPath.UseVisualStyleBackColor = true;
            this.btn_browserPath.Click += new System.EventHandler(this.btn_browserPath_Click);
            // 
            // btn_clearPath
            // 
            this.btn_clearPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clearPath.Location = new System.Drawing.Point(400, 408);
            this.btn_clearPath.Name = "btn_clearPath";
            this.btn_clearPath.Size = new System.Drawing.Size(75, 23);
            this.btn_clearPath.TabIndex = 16;
            this.btn_clearPath.Text = "Clear";
            this.btn_clearPath.UseVisualStyleBackColor = true;
            this.btn_clearPath.Click += new System.EventHandler(this.btn_clearPath_Click);
            // 
            // btn_removePrt
            // 
            this.btn_removePrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removePrt.Location = new System.Drawing.Point(371, 408);
            this.btn_removePrt.Name = "btn_removePrt";
            this.btn_removePrt.Size = new System.Drawing.Size(23, 23);
            this.btn_removePrt.TabIndex = 17;
            this.btn_removePrt.Text = "-";
            this.btn_removePrt.UseVisualStyleBackColor = true;
            this.btn_removePrt.Click += new System.EventHandler(this.btn_removePrt_Click);
            // 
            // ColumnPrtFileName
            // 
            this.ColumnPrtFileName.FillWeight = 50F;
            this.ColumnPrtFileName.HeaderText = "Prt file name";
            this.ColumnPrtFileName.Name = "ColumnPrtFileName";
            this.ColumnPrtFileName.ReadOnly = true;
            // 
            // ColumnResult
            // 
            this.ColumnResult.FillWeight = 20F;
            this.ColumnResult.HeaderText = "Result";
            this.ColumnResult.Name = "ColumnResult";
            this.ColumnResult.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 479);
            this.Controls.Add(this.btn_removePrt);
            this.Controls.Add(this.btn_clearPath);
            this.Controls.Add(this.btn_browserPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbox_function);
            this.Controls.Add(this.btn_execute);
            this.Controls.Add(this.btn_browseNX);
            this.Controls.Add(this.tb_nxPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_progress);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lb_path);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_addPrt);
            this.Controls.Add(this.cbox_Path);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Paper waster";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbox_Path;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label lb_progress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nxPath;
        private System.Windows.Forms.Button btn_browseNX;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.ComboBox cbox_function;
        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.Button btn_addPrt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbox_maxPaperSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_browserPath;
        private System.Windows.Forms.Button btn_clearPath;
        private System.Windows.Forms.Button btn_removePrt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrtFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResult;
    }
}