namespace SharePoint_Discovery_App
{
    partial class frm_Data_List
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
            this.cmd_Get_Fields = new System.Windows.Forms.Button();
            this.cmd_Get_Views = new System.Windows.Forms.Button();
            this.cmd_Open_List = new System.Windows.Forms.Button();
            this.lbl_Row_Count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmd_Get_Fields
            // 
            this.cmd_Get_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Fields.Location = new System.Drawing.Point(224, 394);
            this.cmd_Get_Fields.Name = "cmd_Get_Fields";
            this.cmd_Get_Fields.Size = new System.Drawing.Size(100, 44);
            this.cmd_Get_Fields.TabIndex = 24;
            this.cmd_Get_Fields.Text = "Get Fields";
            this.cmd_Get_Fields.UseVisualStyleBackColor = true;
            this.cmd_Get_Fields.Click += new System.EventHandler(this.cmd_Get_Fields_Click);
            // 
            // cmd_Get_Views
            // 
            this.cmd_Get_Views.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Views.Location = new System.Drawing.Point(118, 394);
            this.cmd_Get_Views.Name = "cmd_Get_Views";
            this.cmd_Get_Views.Size = new System.Drawing.Size(100, 44);
            this.cmd_Get_Views.TabIndex = 23;
            this.cmd_Get_Views.Text = "Get Views";
            this.cmd_Get_Views.UseVisualStyleBackColor = true;
            this.cmd_Get_Views.Click += new System.EventHandler(this.cmd_Get_Views_Click);
            // 
            // cmd_Open_List
            // 
            this.cmd_Open_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Open_List.Location = new System.Drawing.Point(330, 394);
            this.cmd_Open_List.Name = "cmd_Open_List";
            this.cmd_Open_List.Size = new System.Drawing.Size(100, 44);
            this.cmd_Open_List.TabIndex = 25;
            this.cmd_Open_List.Text = "Open List";
            this.cmd_Open_List.UseVisualStyleBackColor = true;
            this.cmd_Open_List.Click += new System.EventHandler(this.cmd_Open_List_Click);
            // 
            // lbl_Row_Count
            // 
            this.lbl_Row_Count.AutoSize = true;
            this.lbl_Row_Count.Location = new System.Drawing.Point(13, 58);
            this.lbl_Row_Count.Name = "lbl_Row_Count";
            this.lbl_Row_Count.Size = new System.Drawing.Size(0, 13);
            this.lbl_Row_Count.TabIndex = 26;
            // 
            // frm_Data_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.lbl_Row_Count);
            this.Controls.Add(this.cmd_Open_List);
            this.Controls.Add(this.cmd_Get_Fields);
            this.Controls.Add(this.cmd_Get_Views);
            this.Name = "frm_Data_List";
            this.Load += new System.EventHandler(this.frm_Data_List_Load);
            this.Controls.SetChildIndex(this.lbl_Header, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Views, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Fields, 0);
            this.Controls.SetChildIndex(this.cmd_Open_List, 0);
            this.Controls.SetChildIndex(this.lbl_Row_Count, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Fields;
        private System.Windows.Forms.Button cmd_Get_Views;
        private System.Windows.Forms.Button cmd_Open_List;
        private System.Windows.Forms.Label lbl_Row_Count;
    }
}
