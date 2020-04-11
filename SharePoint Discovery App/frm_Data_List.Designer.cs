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
            // 
            // frm_Data_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.cmd_Get_Fields);
            this.Controls.Add(this.cmd_Get_Views);
            this.Name = "frm_Data_List";
            this.Controls.SetChildIndex(this.lbl_Header, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Views, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Fields, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Fields;
        private System.Windows.Forms.Button cmd_Get_Views;
    }
}
