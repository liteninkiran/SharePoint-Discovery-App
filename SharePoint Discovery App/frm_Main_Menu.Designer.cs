﻿namespace SharePoint_Discovery_App
{
    partial class frm_Main_Menu
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
            this.lbl_Password = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lbl_Site = new System.Windows.Forms.Label();
            this.txt_Site = new System.Windows.Forms.TextBox();
            this.cmd_Get_Sites = new System.Windows.Forms.Button();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.lbl_Credentials = new System.Windows.Forms.Label();
            this.chk_Recursive = new System.Windows.Forms.CheckBox();
            this.lbl_Limit = new System.Windows.Forms.Label();
            this.tip_Recursive = new System.Windows.Forms.ToolTip(this.components);
            this.tip_Limit = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Test_List = new System.Windows.Forms.Button();
            this.nud_Limit = new System.Windows.Forms.NumericUpDown();
            this.lbl_Site_Count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Limit)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(13, 264);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 7;
            this.lbl_Password.Text = "Password";
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.Location = new System.Drawing.Point(72, 261);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(498, 20);
            this.txt_Password.TabIndex = 3;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(13, 238);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(55, 13);
            this.lbl_Username.TabIndex = 6;
            this.lbl_Username.Text = "Username";
            // 
            // txt_Username
            // 
            this.txt_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Username.Location = new System.Drawing.Point(72, 235);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(498, 20);
            this.txt_Username.TabIndex = 2;
            // 
            // lbl_Site
            // 
            this.lbl_Site.AutoSize = true;
            this.lbl_Site.Location = new System.Drawing.Point(13, 212);
            this.lbl_Site.Name = "lbl_Site";
            this.lbl_Site.Size = new System.Drawing.Size(50, 13);
            this.lbl_Site.TabIndex = 5;
            this.lbl_Site.Text = "Site URL";
            // 
            // txt_Site
            // 
            this.txt_Site.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Site.Location = new System.Drawing.Point(72, 209);
            this.txt_Site.Name = "txt_Site";
            this.txt_Site.Size = new System.Drawing.Size(498, 20);
            this.txt_Site.TabIndex = 1;
            // 
            // cmd_Get_Sites
            // 
            this.cmd_Get_Sites.Location = new System.Drawing.Point(72, 321);
            this.cmd_Get_Sites.Name = "cmd_Get_Sites";
            this.cmd_Get_Sites.Size = new System.Drawing.Size(100, 50);
            this.cmd_Get_Sites.TabIndex = 4;
            this.cmd_Get_Sites.Text = "Get Sites";
            this.cmd_Get_Sites.UseVisualStyleBackColor = true;
            this.cmd_Get_Sites.Click += new System.EventHandler(this.cmd_Get_Sites_Click);
            // 
            // cmd_Close
            // 
            this.cmd_Close.Location = new System.Drawing.Point(470, 377);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(100, 50);
            this.cmd_Close.TabIndex = 0;
            this.cmd_Close.Text = "Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(17, 22);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(553, 46);
            this.lbl_Header.TabIndex = 8;
            this.lbl_Header.Text = "SharePoint Discovery App";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Credentials
            // 
            this.lbl_Credentials.AutoSize = true;
            this.lbl_Credentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Credentials.Location = new System.Drawing.Point(12, 132);
            this.lbl_Credentials.Name = "lbl_Credentials";
            this.lbl_Credentials.Size = new System.Drawing.Size(337, 29);
            this.lbl_Credentials.TabIndex = 9;
            this.lbl_Credentials.Text = "Please Enter Your Credentials";
            // 
            // chk_Recursive
            // 
            this.chk_Recursive.AutoSize = true;
            this.chk_Recursive.Checked = true;
            this.chk_Recursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Recursive.Location = new System.Drawing.Point(178, 350);
            this.chk_Recursive.Name = "chk_Recursive";
            this.chk_Recursive.Size = new System.Drawing.Size(113, 17);
            this.chk_Recursive.TabIndex = 10;
            this.chk_Recursive.Text = "Search recursively";
            this.chk_Recursive.UseVisualStyleBackColor = true;
            // 
            // lbl_Limit
            // 
            this.lbl_Limit.AutoSize = true;
            this.lbl_Limit.Location = new System.Drawing.Point(225, 323);
            this.lbl_Limit.Name = "lbl_Limit";
            this.lbl_Limit.Size = new System.Drawing.Size(53, 13);
            this.lbl_Limit.TabIndex = 12;
            this.lbl_Limit.Text = "Row Limit";
            this.lbl_Limit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Test_List
            // 
            this.btn_Test_List.Location = new System.Drawing.Point(72, 377);
            this.btn_Test_List.Name = "btn_Test_List";
            this.btn_Test_List.Size = new System.Drawing.Size(100, 50);
            this.btn_Test_List.TabIndex = 13;
            this.btn_Test_List.Text = "Open List";
            this.btn_Test_List.UseVisualStyleBackColor = true;
            this.btn_Test_List.Click += new System.EventHandler(this.btn_Test_List_Click);
            // 
            // nud_Limit
            // 
            this.nud_Limit.Location = new System.Drawing.Point(178, 321);
            this.nud_Limit.Name = "nud_Limit";
            this.nud_Limit.Size = new System.Drawing.Size(41, 20);
            this.nud_Limit.TabIndex = 14;
            // 
            // lbl_Site_Count
            // 
            this.lbl_Site_Count.AutoSize = true;
            this.lbl_Site_Count.Location = new System.Drawing.Point(327, 323);
            this.lbl_Site_Count.Name = "lbl_Site_Count";
            this.lbl_Site_Count.Size = new System.Drawing.Size(0, 13);
            this.lbl_Site_Count.TabIndex = 15;
            // 
            // frm_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 440);
            this.Controls.Add(this.lbl_Site_Count);
            this.Controls.Add(this.nud_Limit);
            this.Controls.Add(this.btn_Test_List);
            this.Controls.Add(this.lbl_Limit);
            this.Controls.Add(this.chk_Recursive);
            this.Controls.Add(this.lbl_Credentials);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.cmd_Get_Sites);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.lbl_Site);
            this.Controls.Add(this.txt_Site);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frm_Main_Menu";
            this.Text = "SharePoint Discovery App";
            this.Load += new System.EventHandler(this.frm_Main_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Limit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label lbl_Site;
        private System.Windows.Forms.TextBox txt_Site;
        private System.Windows.Forms.Button cmd_Get_Sites;
        private System.Windows.Forms.Button cmd_Close;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Label lbl_Credentials;
        private System.Windows.Forms.CheckBox chk_Recursive;
        private System.Windows.Forms.Label lbl_Limit;
        private System.Windows.Forms.ToolTip tip_Recursive;
        private System.Windows.Forms.ToolTip tip_Limit;
        private System.Windows.Forms.Button btn_Test_List;
        private System.Windows.Forms.NumericUpDown nud_Limit;
        private System.Windows.Forms.Label lbl_Site_Count;
    }
}