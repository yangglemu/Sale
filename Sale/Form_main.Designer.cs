namespace Sale
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_zqfs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_je = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_syy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_huiyuan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_je = new System.Windows.Forms.TextBox();
            this.textBox_js = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tm = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_tm,
            this.Column_pm,
            this.Column_sj,
            this.Column_zqfs,
            this.Column_sl,
            this.Column1_je,
            this.Column_syy});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.RowHeadersWidth = 60;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowTemplate.Height = 35;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1008, 458);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.TabStop = false;
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // Column_tm
            // 
            this.Column_tm.DividerWidth = 1;
            this.Column_tm.HeaderText = "条码";
            this.Column_tm.Name = "Column_tm";
            this.Column_tm.ReadOnly = true;
            this.Column_tm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_tm.Width = 180;
            // 
            // Column_pm
            // 
            this.Column_pm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_pm.DividerWidth = 1;
            this.Column_pm.HeaderText = "品名";
            this.Column_pm.Name = "Column_pm";
            this.Column_pm.ReadOnly = true;
            this.Column_pm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_sj
            // 
            this.Column_sj.DividerWidth = 1;
            this.Column_sj.HeaderText = "价格";
            this.Column_sj.Name = "Column_sj";
            this.Column_sj.ReadOnly = true;
            this.Column_sj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_sj.Width = 130;
            // 
            // Column_zqfs
            // 
            this.Column_zqfs.DividerWidth = 1;
            this.Column_zqfs.HeaderText = "折扣";
            this.Column_zqfs.Name = "Column_zqfs";
            this.Column_zqfs.ReadOnly = true;
            this.Column_zqfs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_zqfs.Width = 130;
            // 
            // Column_sl
            // 
            this.Column_sl.DividerWidth = 1;
            this.Column_sl.HeaderText = "数量";
            this.Column_sl.Name = "Column_sl";
            this.Column_sl.ReadOnly = true;
            this.Column_sl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_sl.Width = 120;
            // 
            // Column1_je
            // 
            this.Column1_je.DividerWidth = 1;
            this.Column1_je.HeaderText = "金额";
            this.Column1_je.Name = "Column1_je";
            this.Column1_je.ReadOnly = true;
            this.Column1_je.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1_je.Width = 140;
            // 
            // Column_syy
            // 
            this.Column_syy.HeaderText = "收银员";
            this.Column_syy.Name = "Column_syy";
            this.Column_syy.ReadOnly = true;
            this.Column_syy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_syy.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_huiyuan,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_huiyuan
            // 
            this.statusLabel_huiyuan.AutoSize = false;
            this.statusLabel_huiyuan.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.statusLabel_huiyuan.Name = "statusLabel_huiyuan";
            this.statusLabel_huiyuan.Size = new System.Drawing.Size(400, 17);
            this.statusLabel_huiyuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(400, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 15, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(158, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_je);
            this.groupBox1.Controls.Add(this.textBox_js);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_tm);
            this.groupBox1.Location = new System.Drawing.Point(12, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 130);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(524, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(935, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "元";
            // 
            // textBox_je
            // 
            this.textBox_je.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_je.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_je.ForeColor = System.Drawing.Color.Red;
            this.textBox_je.Location = new System.Drawing.Point(669, 29);
            this.textBox_je.Name = "textBox_je";
            this.textBox_je.ReadOnly = true;
            this.textBox_je.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_je.Size = new System.Drawing.Size(260, 81);
            this.textBox_je.TabIndex = 14;
            this.textBox_je.TabStop = false;
            this.textBox_je.Text = "0.00";
            this.textBox_je.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_js
            // 
            this.textBox_js.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_js.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_js.ForeColor = System.Drawing.Color.Red;
            this.textBox_js.Location = new System.Drawing.Point(425, 43);
            this.textBox_js.Name = "textBox_js";
            this.textBox_js.ReadOnly = true;
            this.textBox_js.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_js.Size = new System.Drawing.Size(96, 54);
            this.textBox_js.TabIndex = 13;
            this.textBox_js.TabStop = false;
            this.textBox_js.Text = "0";
            this.textBox_js.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(594, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "总金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(349, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "总件数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "条码：";
            // 
            // textBox_tm
            // 
            this.textBox_tm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_tm.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_tm.Location = new System.Drawing.Point(80, 50);
            this.textBox_tm.Name = "textBox_tm";
            this.textBox_tm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_tm.Size = new System.Drawing.Size(214, 39);
            this.textBox_tm.TabIndex = 1;
            this.textBox_tm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_tm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_tm_KeyDown);
            this.textBox_tm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_tm_KeyPress);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 642);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_main_FormClosed);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.Shown += new System.EventHandler(this.Form_main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_je;
        private System.Windows.Forms.TextBox textBox_js;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tm;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_huiyuan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_zqfs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_je;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_syy;
    }
}

