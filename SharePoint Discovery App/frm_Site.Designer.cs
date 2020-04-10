namespace SharePoint_Discovery_App
{
    partial class frm_Site
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
            this.dgv_Site = new System.Windows.Forms.DataGridView();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.cmd_Get_Lists = new System.Windows.Forms.Button();
            this.chk_Load_Fields = new System.Windows.Forms.CheckBox();
            this.chk_Load_Views = new System.Windows.Forms.CheckBox();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.cmd_Excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Site)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Site
            // 
            this.dgv_Site.AllowUserToAddRows = false;
            this.dgv_Site.AllowUserToDeleteRows = false;
            this.dgv_Site.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Site.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Site.Location = new System.Drawing.Point(12, 88);
            this.dgv_Site.MultiSelect = false;
            this.dgv_Site.Name = "dgv_Site";
            this.dgv_Site.ReadOnly = true;
            this.dgv_Site.Size = new System.Drawing.Size(591, 231);
            this.dgv_Site.TabIndex = 1;
            // 
            // cmd_Close
            // 
            this.cmd_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_Close.Location = new System.Drawing.Point(503, 350);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(100, 30);
            this.cmd_Close.TabIndex = 0;
            this.cmd_Close.Text = "Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // cmd_Get_Lists
            // 
            this.cmd_Get_Lists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Lists.Location = new System.Drawing.Point(12, 350);
            this.cmd_Get_Lists.Name = "cmd_Get_Lists";
            this.cmd_Get_Lists.Size = new System.Drawing.Size(100, 30);
            this.cmd_Get_Lists.TabIndex = 5;
            this.cmd_Get_Lists.Text = "Get Lists";
            this.cmd_Get_Lists.UseVisualStyleBackColor = true;
            this.cmd_Get_Lists.Click += new System.EventHandler(this.cmd_Get_Lists_Click);
            // 
            // chk_Load_Fields
            // 
            this.chk_Load_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_Load_Fields.AutoSize = true;
            this.chk_Load_Fields.Location = new System.Drawing.Point(99, 325);
            this.chk_Load_Fields.Name = "chk_Load_Fields";
            this.chk_Load_Fields.Size = new System.Drawing.Size(80, 17);
            this.chk_Load_Fields.TabIndex = 13;
            this.chk_Load_Fields.Text = "Load Fields";
            this.chk_Load_Fields.UseVisualStyleBackColor = true;
            // 
            // chk_Load_Views
            // 
            this.chk_Load_Views.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_Load_Views.AutoSize = true;
            this.chk_Load_Views.Location = new System.Drawing.Point(12, 325);
            this.chk_Load_Views.Name = "chk_Load_Views";
            this.chk_Load_Views.Size = new System.Drawing.Size(81, 17);
            this.chk_Load_Views.TabIndex = 12;
            this.chk_Load_Views.Text = "Load Views";
            this.chk_Load_Views.UseVisualStyleBackColor = true;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(12, 24);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(591, 46);
            this.lbl_Header.TabIndex = 14;
            this.lbl_Header.Text = "Sites && Sub-Sites";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmd_Excel
            // 
            this.cmd_Excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Excel.Location = new System.Drawing.Point(118, 350);
            this.cmd_Excel.Name = "cmd_Excel";
            this.cmd_Excel.Size = new System.Drawing.Size(100, 30);
            this.cmd_Excel.TabIndex = 15;
            this.cmd_Excel.Text = "Excel";
            this.cmd_Excel.UseVisualStyleBackColor = true;
            this.cmd_Excel.Click += new System.EventHandler(this.cmd_Excel_Click);
            // 
            // frm_Site
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 414);
            this.Controls.Add(this.cmd_Excel);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.chk_Load_Fields);
            this.Controls.Add(this.chk_Load_Views);
            this.Controls.Add(this.cmd_Get_Lists);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.dgv_Site);
            this.Name = "frm_Site";
            this.Text = "Sites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Site_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Site)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmd_Close;
        public System.Windows.Forms.DataGridView dgv_Site;
        private System.Windows.Forms.Button cmd_Get_Lists;
        private System.Windows.Forms.CheckBox chk_Load_Fields;
        private System.Windows.Forms.CheckBox chk_Load_Views;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Button cmd_Excel;
    }
}