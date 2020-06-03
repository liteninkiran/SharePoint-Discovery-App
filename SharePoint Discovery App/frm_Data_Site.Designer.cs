﻿namespace SharePoint_Discovery_App
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
            this.txt_Guid = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Guid = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.cmd_Get_Views = new System.Windows.Forms.Button();
            this.tip_Search_By_Guid = new System.Windows.Forms.ToolTip(this.components);
            this.tip_Search_By_Name = new System.Windows.Forms.ToolTip(this.components);
            this.nud_Row_Limit = new System.Windows.Forms.NumericUpDown();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.lbl_Row_Limit = new System.Windows.Forms.Label();
            this.lbl_Row_Count = new System.Windows.Forms.Label();
            this.tlp_Search = new System.Windows.Forms.TableLayoutPanel();
            this.cmd_Get_Users = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Row_Limit)).BeginInit();
            this.tlp_Search.SuspendLayout();
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
            // txt_Guid
            // 
            this.txt_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Guid.Location = new System.Drawing.Point(47, 3);
            this.txt_Guid.Name = "txt_Guid";
            this.txt_Guid.Size = new System.Drawing.Size(164, 20);
            this.txt_Guid.TabIndex = 26;
            this.txt_Guid.TextChanged += new System.EventHandler(this.txt_Guid_TextChanged);
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Location = new System.Drawing.Point(264, 3);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(181, 20);
            this.txt_Name.TabIndex = 27;
            this.txt_Name.TextChanged += new System.EventHandler(this.txt_Name_TextChanged);
            // 
            // lbl_Guid
            // 
            this.lbl_Guid.AutoSize = true;
            this.lbl_Guid.Location = new System.Drawing.Point(3, 0);
            this.lbl_Guid.Name = "lbl_Guid";
            this.lbl_Guid.Size = new System.Drawing.Size(34, 13);
            this.lbl_Guid.TabIndex = 28;
            this.lbl_Guid.Text = "GUID";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(217, 0);
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
            // nud_Row_Limit
            // 
            this.nud_Row_Limit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Row_Limit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Row_Limit.Location = new System.Drawing.Point(525, 51);
            this.nud_Row_Limit.Name = "nud_Row_Limit";
            this.nud_Row_Limit.Size = new System.Drawing.Size(51, 20);
            this.nud_Row_Limit.TabIndex = 31;
            this.nud_Row_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Row_Limit
            // 
            this.lbl_Row_Limit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Row_Limit.AutoSize = true;
            this.lbl_Row_Limit.Location = new System.Drawing.Point(466, 53);
            this.lbl_Row_Limit.Name = "lbl_Row_Limit";
            this.lbl_Row_Limit.Size = new System.Drawing.Size(53, 13);
            this.lbl_Row_Limit.TabIndex = 32;
            this.lbl_Row_Limit.Text = "Row Limit";
            // 
            // lbl_Row_Count
            // 
            this.lbl_Row_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Row_Count.AutoSize = true;
            this.lbl_Row_Count.Location = new System.Drawing.Point(17, 380);
            this.lbl_Row_Count.Name = "lbl_Row_Count";
            this.lbl_Row_Count.Size = new System.Drawing.Size(0, 13);
            this.lbl_Row_Count.TabIndex = 33;
            // 
            // tlp_Search
            // 
            this.tlp_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp_Search.ColumnCount = 4;
            this.tlp_Search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlp_Search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlp_Search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlp_Search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tlp_Search.Controls.Add(this.txt_Guid, 1, 0);
            this.tlp_Search.Controls.Add(this.lbl_Guid, 0, 0);
            this.tlp_Search.Controls.Add(this.lbl_Name, 2, 0);
            this.tlp_Search.Controls.Add(this.txt_Name, 3, 0);
            this.tlp_Search.Location = new System.Drawing.Point(12, 50);
            this.tlp_Search.Name = "tlp_Search";
            this.tlp_Search.RowCount = 1;
            this.tlp_Search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Search.Size = new System.Drawing.Size(448, 25);
            this.tlp_Search.TabIndex = 34;
            // 
            // cmd_Get_Users
            // 
            this.cmd_Get_Users.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Get_Users.Location = new System.Drawing.Point(330, 394);
            this.cmd_Get_Users.Name = "cmd_Get_Users";
            this.cmd_Get_Users.Size = new System.Drawing.Size(100, 44);
            this.cmd_Get_Users.TabIndex = 35;
            this.cmd_Get_Users.Text = "Get Users";
            this.cmd_Get_Users.UseVisualStyleBackColor = true;
            this.cmd_Get_Users.Click += new System.EventHandler(this.cmd_Get_Users_Click);
            // 
            // frm_Data_Site
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.cmd_Get_Users);
            this.Controls.Add(this.tlp_Search);
            this.Controls.Add(this.lbl_Row_Count);
            this.Controls.Add(this.lbl_Row_Limit);
            this.Controls.Add(this.nud_Row_Limit);
            this.Controls.Add(this.cmd_Get_Views);
            this.Controls.Add(this.cmd_Get_Lists);
            this.Name = "frm_Data_Site";
            this.Load += new System.EventHandler(this.frm_Data_Site_Load);
            this.Controls.SetChildIndex(this.lbl_Header, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Lists, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Views, 0);
            this.Controls.SetChildIndex(this.nud_Row_Limit, 0);
            this.Controls.SetChildIndex(this.lbl_Row_Limit, 0);
            this.Controls.SetChildIndex(this.lbl_Row_Count, 0);
            this.Controls.SetChildIndex(this.tlp_Search, 0);
            this.Controls.SetChildIndex(this.cmd_Get_Users, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Row_Limit)).EndInit();
            this.tlp_Search.ResumeLayout(false);
            this.tlp_Search.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Get_Lists;
        private System.Windows.Forms.TextBox txt_Guid;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Guid;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button cmd_Get_Views;
        private System.Windows.Forms.ToolTip tip_Search_By_Guid;
        private System.Windows.Forms.ToolTip tip_Search_By_Name;
        private System.Windows.Forms.NumericUpDown nud_Row_Limit;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label lbl_Row_Limit;
        private System.Windows.Forms.Label lbl_Row_Count;
        private System.Windows.Forms.TableLayoutPanel tlp_Search;
        private System.Windows.Forms.Button cmd_Get_Users;
    }
}
