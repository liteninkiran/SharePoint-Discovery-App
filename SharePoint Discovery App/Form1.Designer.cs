namespace SharePoint_Discovery_App
{
    partial class Form1
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
            this.txt_Site = new System.Windows.Forms.TextBox();
            this.lbl_Site = new System.Windows.Forms.Label();
            this.dgv_List = new System.Windows.Forms.DataGridView();
            this.cmd_Clear = new System.Windows.Forms.Button();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.chk_Load_Views = new System.Windows.Forms.CheckBox();
            this.chk_Load_Fields = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_Get_Lists
            // 
            this.cmd_Get_Lists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Lists.Location = new System.Drawing.Point(41, 388);
            this.cmd_Get_Lists.Name = "cmd_Get_Lists";
            this.cmd_Get_Lists.Size = new System.Drawing.Size(123, 25);
            this.cmd_Get_Lists.TabIndex = 0;
            this.cmd_Get_Lists.Text = "Get Lists";
            this.cmd_Get_Lists.UseVisualStyleBackColor = true;
            this.cmd_Get_Lists.Click += new System.EventHandler(this.cmd_Get_Lists_Click);
            // 
            // txt_Site
            // 
            this.txt_Site.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Site.Location = new System.Drawing.Point(97, 23);
            this.txt_Site.Name = "txt_Site";
            this.txt_Site.Size = new System.Drawing.Size(365, 20);
            this.txt_Site.TabIndex = 1;
            // 
            // lbl_Site
            // 
            this.lbl_Site.AutoSize = true;
            this.lbl_Site.Location = new System.Drawing.Point(38, 26);
            this.lbl_Site.Name = "lbl_Site";
            this.lbl_Site.Size = new System.Drawing.Size(50, 13);
            this.lbl_Site.TabIndex = 2;
            this.lbl_Site.Text = "Site URL";
            // 
            // dgv_List
            // 
            this.dgv_List.AllowUserToAddRows = false;
            this.dgv_List.AllowUserToDeleteRows = false;
            this.dgv_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Location = new System.Drawing.Point(41, 141);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.ReadOnly = true;
            this.dgv_List.Size = new System.Drawing.Size(421, 228);
            this.dgv_List.TabIndex = 3;
            // 
            // cmd_Clear
            // 
            this.cmd_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Clear.Location = new System.Drawing.Point(170, 388);
            this.cmd_Clear.Name = "cmd_Clear";
            this.cmd_Clear.Size = new System.Drawing.Size(123, 25);
            this.cmd_Clear.TabIndex = 4;
            this.cmd_Clear.Text = "Clear Grid";
            this.cmd_Clear.UseVisualStyleBackColor = true;
            this.cmd_Clear.Click += new System.EventHandler(this.cmd_Clear_Click);
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(38, 52);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(55, 13);
            this.lbl_Username.TabIndex = 6;
            this.lbl_Username.Text = "Username";
            // 
            // txt_Username
            // 
            this.txt_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Username.Location = new System.Drawing.Point(97, 49);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(365, 20);
            this.txt_Username.TabIndex = 5;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(38, 78);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 8;
            this.lbl_Password.Text = "Password";
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.Location = new System.Drawing.Point(97, 75);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(365, 20);
            this.txt_Password.TabIndex = 7;
            // 
            // cmd_Close
            // 
            this.cmd_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_Close.Location = new System.Drawing.Point(363, 388);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(99, 25);
            this.cmd_Close.TabIndex = 9;
            this.cmd_Close.Text = "Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // chk_Load_Views
            // 
            this.chk_Load_Views.AutoSize = true;
            this.chk_Load_Views.Location = new System.Drawing.Point(41, 118);
            this.chk_Load_Views.Name = "chk_Load_Views";
            this.chk_Load_Views.Size = new System.Drawing.Size(81, 17);
            this.chk_Load_Views.TabIndex = 10;
            this.chk_Load_Views.Text = "Load Views";
            this.chk_Load_Views.UseVisualStyleBackColor = true;
            // 
            // chk_Load_Fields
            // 
            this.chk_Load_Fields.AutoSize = true;
            this.chk_Load_Fields.Location = new System.Drawing.Point(128, 118);
            this.chk_Load_Fields.Name = "chk_Load_Fields";
            this.chk_Load_Fields.Size = new System.Drawing.Size(80, 17);
            this.chk_Load_Fields.TabIndex = 11;
            this.chk_Load_Fields.Text = "Load Fields";
            this.chk_Load_Fields.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 437);
            this.Controls.Add(this.chk_Load_Fields);
            this.Controls.Add(this.chk_Load_Views);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.cmd_Clear);
            this.Controls.Add(this.dgv_List);
            this.Controls.Add(this.lbl_Site);
            this.Controls.Add(this.txt_Site);
            this.Controls.Add(this.cmd_Get_Lists);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Lists;
        private System.Windows.Forms.TextBox txt_Site;
        private System.Windows.Forms.Label lbl_Site;
        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button cmd_Clear;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button cmd_Close;
        private System.Windows.Forms.CheckBox chk_Load_Views;
        private System.Windows.Forms.CheckBox chk_Load_Fields;
    }
}

