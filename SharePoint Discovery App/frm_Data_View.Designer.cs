namespace SharePoint_Discovery_App
{
    partial class frm_Data_View
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
            this.cmd_Copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd_Copy
            // 
            this.cmd_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Copy.Location = new System.Drawing.Point(118, 394);
            this.cmd_Copy.Name = "cmd_Copy";
            this.cmd_Copy.Size = new System.Drawing.Size(107, 44);
            this.cmd_Copy.TabIndex = 23;
            this.cmd_Copy.Text = "Copy Query XML";
            this.cmd_Copy.UseVisualStyleBackColor = true;
            this.cmd_Copy.Click += new System.EventHandler(this.cmd_Copy_Click);
            // 
            // frm_Data_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.cmd_Copy);
            this.Name = "frm_Data_View";
            this.Load += new System.EventHandler(this.frm_Data_View_Load);
            this.Controls.SetChildIndex(this.lbl_Header, 0);
            this.Controls.SetChildIndex(this.cmd_Copy, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_Copy;
    }
}
