namespace SharePoint_Discovery_App
{
    partial class frm_Data
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
            this.cmd_Excel = new System.Windows.Forms.Button();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_Excel
            // 
            this.cmd_Excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Excel.Location = new System.Drawing.Point(12, 394);
            this.cmd_Excel.Name = "cmd_Excel";
            this.cmd_Excel.Size = new System.Drawing.Size(100, 44);
            this.cmd_Excel.TabIndex = 22;
            this.cmd_Excel.Text = "Excel";
            this.cmd_Excel.UseVisualStyleBackColor = true;
            this.cmd_Excel.Click += new System.EventHandler(this.cmd_Excel_Click);
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(12, 13);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(564, 46);
            this.lbl_Header.TabIndex = 21;
            this.lbl_Header.Text = "Header";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmd_Close
            // 
            this.cmd_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_Close.Location = new System.Drawing.Point(476, 394);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(100, 44);
            this.cmd_Close.TabIndex = 16;
            this.cmd_Close.Text = "Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Location = new System.Drawing.Point(12, 77);
            this.dgv_Data.MultiSelect = false;
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.ReadOnly = true;
            this.dgv_Data.Size = new System.Drawing.Size(564, 300);
            this.dgv_Data.TabIndex = 17;
            this.dgv_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellContentClick);
            // 
            // frm_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.cmd_Excel);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.dgv_Data);
            this.Name = "frm_Data";
            this.Text = "Form Caption";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Data_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_Excel;
        private System.Windows.Forms.Button cmd_Close;
        public System.Windows.Forms.DataGridView dgv_Data;
        public System.Windows.Forms.Label lbl_Header;
    }
}