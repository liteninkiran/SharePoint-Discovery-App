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
            this.components = new System.ComponentModel.Container();
            this.cmd_Get_Lists = new System.Windows.Forms.Button();
            this.chk_Load_Fields = new System.Windows.Forms.CheckBox();
            this.chk_Load_Views = new System.Windows.Forms.CheckBox();
            this.tip_Load_Views = new System.Windows.Forms.ToolTip(this.components);
            this.tip_Load_Fields = new System.Windows.Forms.ToolTip(this.components);
            this.txt_Guid = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Guid = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.cmd_Get_Views = new System.Windows.Forms.Button();
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
            this.chk_Load_Fields.AutoSize = true;
            this.chk_Load_Fields.Location = new System.Drawing.Point(99, 54);
            this.chk_Load_Fields.Name = "chk_Load_Fields";
            this.chk_Load_Fields.Size = new System.Drawing.Size(80, 17);
            this.chk_Load_Fields.TabIndex = 25;
            this.chk_Load_Fields.Text = "Load Fields";
            this.chk_Load_Fields.UseVisualStyleBackColor = true;
            // 
            // chk_Load_Views
            // 
            this.chk_Load_Views.AutoSize = true;
            this.chk_Load_Views.Location = new System.Drawing.Point(12, 54);
            this.chk_Load_Views.Name = "chk_Load_Views";
            this.chk_Load_Views.Size = new System.Drawing.Size(81, 17);
            this.chk_Load_Views.TabIndex = 24;
            this.chk_Load_Views.Text = "Load Views";
            this.chk_Load_Views.UseVisualStyleBackColor = true;
            // 
            // txt_Guid
            // 
            this.txt_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Guid.Location = new System.Drawing.Point(387, 394);
            this.txt_Guid.Name = "txt_Guid";
            this.txt_Guid.Size = new System.Drawing.Size(62, 20);
            this.txt_Guid.TabIndex = 26;
            this.txt_Guid.TextChanged += new System.EventHandler(this.txt_Guid_TextChanged);
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Location = new System.Drawing.Point(387, 418);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(62, 20);
            this.txt_Name.TabIndex = 27;
            this.txt_Name.TextChanged += new System.EventHandler(this.txt_Name_TextChanged);
            // 
            // lbl_Guid
            // 
            this.lbl_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Guid.AutoSize = true;
            this.lbl_Guid.Location = new System.Drawing.Point(347, 397);
            this.lbl_Guid.Name = "lbl_Guid";
            this.lbl_Guid.Size = new System.Drawing.Size(34, 13);
            this.lbl_Guid.TabIndex = 28;
            this.lbl_Guid.Text = "GUID";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(346, 422);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 29;
            this.lbl_Name.Text = "Name";
            // 
            // cmd_Get_Views
            // 
            this.cmd_Get_Views.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Views.Enabled = false;
            this.cmd_Get_Views.Location = new System.Drawing.Point(224, 394);
            this.cmd_Get_Views.Name = "cmd_Get_Views";
            this.cmd_Get_Views.Size = new System.Drawing.Size(100, 44);
            this.cmd_Get_Views.TabIndex = 30;
            this.cmd_Get_Views.Text = "Get Views";
            this.cmd_Get_Views.UseVisualStyleBackColor = true;
            this.cmd_Get_Views.Click += new System.EventHandler(this.cmd_Get_Views_Click);
            // 
            // frm_Data_Site
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.cmd_Get_Views);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Guid);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Guid);
            this.Controls.Add(this.chk_Load_Fields);
            this.Controls.Add(this.chk_Load_Views);
            this.Controls.Add(this.cmd_Get_Lists);
            this.Name = "frm_Data_Site";
            this.Load += new System.EventHandler(this.frm_Data_Site_Load);
            this.Controls.SetChildIndex(this.lbl_Header, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Lists, 0);
            this.Controls.SetChildIndex(this.chk_Load_Views, 0);
            this.Controls.SetChildIndex(this.chk_Load_Fields, 0);
            this.Controls.SetChildIndex(this.txt_Guid, 0);
            this.Controls.SetChildIndex(this.txt_Name, 0);
            this.Controls.SetChildIndex(this.lbl_Guid, 0);
            this.Controls.SetChildIndex(this.lbl_Name, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Views, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Lists;
        private System.Windows.Forms.CheckBox chk_Load_Fields;
        private System.Windows.Forms.CheckBox chk_Load_Views;
        private System.Windows.Forms.ToolTip tip_Load_Views;
        private System.Windows.Forms.ToolTip tip_Load_Fields;
        private System.Windows.Forms.TextBox txt_Guid;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Guid;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button cmd_Get_Views;
    }
}
