namespace SharePoint_Discovery_App
{
    partial class frm_Data_Site
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
            this.cmd_Get_Lists = new System.Windows.Forms.Button();
            this.chk_Load_Fields = new System.Windows.Forms.CheckBox();
            this.chk_Load_Views = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmd_Get_Lists
            // 
            this.cmd_Get_Lists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Lists.Location = new System.Drawing.Point(118, 394);
            this.cmd_Get_Lists.Name = "cmd_Get_Lists";
            this.cmd_Get_Lists.Size = new System.Drawing.Size(100, 44);
            this.cmd_Get_Lists.TabIndex = 23;
            this.cmd_Get_Lists.Text = "Get Lists";
            this.cmd_Get_Lists.UseVisualStyleBackColor = true;
            this.cmd_Get_Lists.Click += new System.EventHandler(this.cmd_Get_Lists_Click);
            // 
            // chk_Load_Fields
            // 
            this.chk_Load_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_Load_Fields.AutoSize = true;
            this.chk_Load_Fields.Location = new System.Drawing.Point(224, 420);
            this.chk_Load_Fields.Name = "chk_Load_Fields";
            this.chk_Load_Fields.Size = new System.Drawing.Size(80, 17);
            this.chk_Load_Fields.TabIndex = 25;
            this.chk_Load_Fields.Text = "Load Fields";
            this.chk_Load_Fields.UseVisualStyleBackColor = true;
            // 
            // chk_Load_Views
            // 
            this.chk_Load_Views.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_Load_Views.AutoSize = true;
            this.chk_Load_Views.Location = new System.Drawing.Point(224, 397);
            this.chk_Load_Views.Name = "chk_Load_Views";
            this.chk_Load_Views.Size = new System.Drawing.Size(81, 17);
            this.chk_Load_Views.TabIndex = 24;
            this.chk_Load_Views.Text = "Load Views";
            this.chk_Load_Views.UseVisualStyleBackColor = true;
            // 
            // frm_Data_Site
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.chk_Load_Fields);
            this.Controls.Add(this.chk_Load_Views);
            this.Controls.Add(this.cmd_Get_Lists);
            this.Name = "frm_Data_Site";
            this.Load += new System.EventHandler(this.frm_Data_Site_Load);
            this.Controls.SetChildIndex(this.lbl_Header, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Lists, 0);
            this.Controls.SetChildIndex(this.chk_Load_Views, 0);
            this.Controls.SetChildIndex(this.chk_Load_Fields, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Lists;
        private System.Windows.Forms.CheckBox chk_Load_Fields;
        private System.Windows.Forms.CheckBox chk_Load_Views;
    }
}
