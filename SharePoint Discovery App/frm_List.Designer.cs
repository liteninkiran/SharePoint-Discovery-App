namespace SharePoint_Discovery_App
{
    partial class frm_List
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
            this.cmd_Get_Views = new System.Windows.Forms.Button();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.dgv_List = new System.Windows.Forms.DataGridView();
            this.cmd_Get_Fields = new System.Windows.Forms.Button();
            this.lbl_Header = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_Get_Views
            // 
            this.cmd_Get_Views.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Views.Location = new System.Drawing.Point(12, 210);
            this.cmd_Get_Views.Name = "cmd_Get_Views";
            this.cmd_Get_Views.Size = new System.Drawing.Size(100, 30);
            this.cmd_Get_Views.TabIndex = 8;
            this.cmd_Get_Views.Text = "Get Views";
            this.cmd_Get_Views.UseVisualStyleBackColor = true;
            this.cmd_Get_Views.Click += new System.EventHandler(this.cmd_Get_Lists_Click);
            // 
            // cmd_Close
            // 
            this.cmd_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_Close.Location = new System.Drawing.Point(431, 210);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(100, 30);
            this.cmd_Close.TabIndex = 6;
            this.cmd_Close.Text = "Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // dgv_List
            // 
            this.dgv_List.AllowUserToAddRows = false;
            this.dgv_List.AllowUserToDeleteRows = false;
            this.dgv_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Location = new System.Drawing.Point(12, 88);
            this.dgv_List.MultiSelect = false;
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.ReadOnly = true;
            this.dgv_List.Size = new System.Drawing.Size(519, 108);
            this.dgv_List.TabIndex = 7;
            // 
            // cmd_Get_Fields
            // 
            this.cmd_Get_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Fields.Location = new System.Drawing.Point(118, 210);
            this.cmd_Get_Fields.Name = "cmd_Get_Fields";
            this.cmd_Get_Fields.Size = new System.Drawing.Size(100, 30);
            this.cmd_Get_Fields.TabIndex = 9;
            this.cmd_Get_Fields.Text = "Get Fields";
            this.cmd_Get_Fields.UseVisualStyleBackColor = true;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(12, 24);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(519, 46);
            this.lbl_Header.TabIndex = 15;
            this.lbl_Header.Text = "Lists";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 277);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.cmd_Get_Fields);
            this.Controls.Add(this.cmd_Get_Views);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.dgv_List);
            this.Name = "frm_List";
            this.Text = "Lists";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Views;
        private System.Windows.Forms.Button cmd_Close;
        public System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button cmd_Get_Fields;
        private System.Windows.Forms.Label lbl_Header;
    }
}