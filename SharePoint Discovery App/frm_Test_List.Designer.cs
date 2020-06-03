namespace SharePoint_Discovery_App
{
    partial class frm_Test_List
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
            this.dgv_List = new System.Windows.Forms.DataGridView();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.cmd_Open_List = new System.Windows.Forms.Button();
            this.lbl_Url = new System.Windows.Forms.Label();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.lbl_Guid = new System.Windows.Forms.Label();
            this.txt_Guid = new System.Windows.Forms.TextBox();
            this.lbl_Row_Limit = new System.Windows.Forms.Label();
            this.nud_Row_Limit = new System.Windows.Forms.NumericUpDown();
            this.cmd_Excel = new System.Windows.Forms.Button();
            this.lbl_Summary = new System.Windows.Forms.Label();
            this.tlp_Search_Fields = new System.Windows.Forms.TableLayoutPanel();
            this.cmd_Versions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Row_Limit)).BeginInit();
            this.tlp_Search_Fields.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_List
            // 
            this.dgv_List.AllowUserToAddRows = false;
            this.dgv_List.AllowUserToDeleteRows = false;
            this.dgv_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Location = new System.Drawing.Point(12, 51);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.Size = new System.Drawing.Size(650, 300);
            this.dgv_List.TabIndex = 0;
            // 
            // cmd_Close
            // 
            this.cmd_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_Close.Location = new System.Drawing.Point(562, 394);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(100, 44);
            this.cmd_Close.TabIndex = 17;
            this.cmd_Close.Text = "Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // cmd_Open_List
            // 
            this.cmd_Open_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Open_List.Location = new System.Drawing.Point(118, 394);
            this.cmd_Open_List.Name = "cmd_Open_List";
            this.cmd_Open_List.Size = new System.Drawing.Size(100, 44);
            this.cmd_Open_List.TabIndex = 18;
            this.cmd_Open_List.Text = "Open List";
            this.cmd_Open_List.UseVisualStyleBackColor = true;
            this.cmd_Open_List.Click += new System.EventHandler(this.cmd_Open_List_Click);
            // 
            // lbl_Url
            // 
            this.lbl_Url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Url.AutoSize = true;
            this.lbl_Url.Location = new System.Drawing.Point(3, 12);
            this.lbl_Url.Name = "lbl_Url";
            this.lbl_Url.Size = new System.Drawing.Size(50, 13);
            this.lbl_Url.TabIndex = 22;
            this.lbl_Url.Text = "Site URL";
            // 
            // txt_Url
            // 
            this.txt_Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Url.Location = new System.Drawing.Point(3, 28);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(152, 20);
            this.txt_Url.TabIndex = 20;
            // 
            // lbl_Guid
            // 
            this.lbl_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Guid.AutoSize = true;
            this.lbl_Guid.Location = new System.Drawing.Point(161, 12);
            this.lbl_Guid.Name = "lbl_Guid";
            this.lbl_Guid.Size = new System.Drawing.Size(53, 13);
            this.lbl_Guid.TabIndex = 21;
            this.lbl_Guid.Text = "List GUID";
            // 
            // txt_Guid
            // 
            this.txt_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Guid.Location = new System.Drawing.Point(161, 28);
            this.txt_Guid.Name = "txt_Guid";
            this.txt_Guid.Size = new System.Drawing.Size(62, 20);
            this.txt_Guid.TabIndex = 19;
            // 
            // lbl_Row_Limit
            // 
            this.lbl_Row_Limit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Row_Limit.AutoSize = true;
            this.lbl_Row_Limit.Location = new System.Drawing.Point(530, 27);
            this.lbl_Row_Limit.Name = "lbl_Row_Limit";
            this.lbl_Row_Limit.Size = new System.Drawing.Size(53, 13);
            this.lbl_Row_Limit.TabIndex = 23;
            this.lbl_Row_Limit.Text = "Row Limit";
            // 
            // nud_Row_Limit
            // 
            this.nud_Row_Limit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Row_Limit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Row_Limit.Location = new System.Drawing.Point(589, 25);
            this.nud_Row_Limit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_Row_Limit.Name = "nud_Row_Limit";
            this.nud_Row_Limit.Size = new System.Drawing.Size(73, 20);
            this.nud_Row_Limit.TabIndex = 25;
            this.nud_Row_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Row_Limit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmd_Excel
            // 
            this.cmd_Excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Excel.Location = new System.Drawing.Point(12, 394);
            this.cmd_Excel.Name = "cmd_Excel";
            this.cmd_Excel.Size = new System.Drawing.Size(100, 44);
            this.cmd_Excel.TabIndex = 26;
            this.cmd_Excel.Text = "Excel";
            this.cmd_Excel.UseVisualStyleBackColor = true;
            this.cmd_Excel.Click += new System.EventHandler(this.cmd_Excel_Click);
            // 
            // lbl_Summary
            // 
            this.lbl_Summary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Summary.AutoSize = true;
            this.lbl_Summary.Location = new System.Drawing.Point(12, 366);
            this.lbl_Summary.Name = "lbl_Summary";
            this.lbl_Summary.Size = new System.Drawing.Size(0, 13);
            this.lbl_Summary.TabIndex = 27;
            // 
            // tlp_Search_Fields
            // 
            this.tlp_Search_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp_Search_Fields.ColumnCount = 2;
            this.tlp_Search_Fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp_Search_Fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_Search_Fields.Controls.Add(this.txt_Url, 0, 1);
            this.tlp_Search_Fields.Controls.Add(this.lbl_Guid, 1, 0);
            this.tlp_Search_Fields.Controls.Add(this.txt_Guid, 1, 1);
            this.tlp_Search_Fields.Controls.Add(this.lbl_Url, 0, 0);
            this.tlp_Search_Fields.Location = new System.Drawing.Point(330, 387);
            this.tlp_Search_Fields.Name = "tlp_Search_Fields";
            this.tlp_Search_Fields.RowCount = 2;
            this.tlp_Search_Fields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Search_Fields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Search_Fields.Size = new System.Drawing.Size(226, 51);
            this.tlp_Search_Fields.TabIndex = 28;
            // 
            // cmd_Versions
            // 
            this.cmd_Versions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Versions.Enabled = false;
            this.cmd_Versions.Location = new System.Drawing.Point(224, 394);
            this.cmd_Versions.Name = "cmd_Versions";
            this.cmd_Versions.Size = new System.Drawing.Size(100, 44);
            this.cmd_Versions.TabIndex = 29;
            this.cmd_Versions.Text = "Previous Versions";
            this.cmd_Versions.UseVisualStyleBackColor = true;
            this.cmd_Versions.Click += new System.EventHandler(this.cmd_Versions_Click);
            // 
            // frm_Test_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
            this.Controls.Add(this.cmd_Versions);
            this.Controls.Add(this.tlp_Search_Fields);
            this.Controls.Add(this.lbl_Summary);
            this.Controls.Add(this.cmd_Excel);
            this.Controls.Add(this.nud_Row_Limit);
            this.Controls.Add(this.lbl_Row_Limit);
            this.Controls.Add(this.cmd_Open_List);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.dgv_List);
            this.Name = "frm_Test_List";
            this.Text = "List Data";
            this.Load += new System.EventHandler(this.frm_Test_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Row_Limit)).EndInit();
            this.tlp_Search_Fields.ResumeLayout(false);
            this.tlp_Search_Fields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button cmd_Close;
        private System.Windows.Forms.Button cmd_Open_List;
        private System.Windows.Forms.Label lbl_Url;
        private System.Windows.Forms.Label lbl_Guid;
        private System.Windows.Forms.Label lbl_Row_Limit;
        private System.Windows.Forms.NumericUpDown nud_Row_Limit;
        public System.Windows.Forms.TextBox txt_Url;
        public System.Windows.Forms.TextBox txt_Guid;
        private System.Windows.Forms.Button cmd_Excel;
        private System.Windows.Forms.Label lbl_Summary;
        private System.Windows.Forms.TableLayoutPanel tlp_Search_Fields;
        private System.Windows.Forms.Button cmd_Versions;
    }
}