﻿using System;
using System.Security;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Site : System.Windows.Forms.Form
    {
        public frm_Site()
        {
            InitializeComponent();
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_Get_Lists_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Site.SelectedCells[0].RowIndex;

            // Store site URL
            string siteUrl = dgv_Site[2, row].Value.ToString();

            // Update button caption as it will take a while to load all sites/sub-sites
            ChangeButton(true);

            // Open the List form
            frm_List listForm = OpenForm();

            // Add columns to the data grid view
            AddColumns(listForm);

            // Get lists
            AddLists(siteUrl, listForm.dgv_List);

            // Show the List form
            listForm.Show();

            // Change the button caption back
            ChangeButton(false);
        }

        private void ChangeButton(bool start)
        {
            if (start)
            {
                this.cmd_Get_Lists.Width = 200;
                this.cmd_Get_Lists.Text = "Getting lists. Please wait...";
            }
            else
            {
                this.cmd_Get_Lists.Text = "Get Lists";
                this.cmd_Get_Lists.Width = 100;
            }
        }

        public static frm_List OpenForm()
        {
            // Create a new instance of the Site class
            frm_List listForm = new frm_List();

            listForm.Height = 700;
            listForm.Width = 1500;

            return listForm;
        }

        private void AddColumns(frm_List listForm)
        {
            DataGridView dgv_List = listForm.dgv_List;
            DataGridViewColumn col = null;

            col = dgv_List.Columns[dgv_List.Columns.Add("listNumber", "Number")];
            col = dgv_List.Columns[dgv_List.Columns.Add("listName", "List Name")];
            col = dgv_List.Columns[dgv_List.Columns.Add("defaultView", "Default View")];
            col = dgv_List.Columns[dgv_List.Columns.Add("fieldCount", "Field Count")];
            col = dgv_List.Columns[dgv_List.Columns.Add("viewCount", "View Count")];
            col = dgv_List.Columns[dgv_List.Columns.Add("itemCount", "Item Count")];
            col = dgv_List.Columns[dgv_List.Columns.Add("listId", "GUID")];
            col = dgv_List.Columns[dgv_List.Columns.Add("description", "Description")];
            col = dgv_List.Columns[dgv_List.Columns.Add("created", "Created")];

            foreach (DataGridViewColumn c in dgv_List.Columns)
            {
                switch (c.Name)
                {
                    case "description":
                        break;
                    default:
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        break;
                }
            }
        }

        private void AddLists(string siteUrl, DataGridView dgv_List)
        {
            ClientContext clientContext = SharePoint.GetClient(siteUrl, frm_Main_Menu.username, frm_Main_Menu.password);
            ListCollection collList = SharePoint.GetLists(clientContext);

            // Initialise row counter
            int i = 0;

            foreach (SP.List oList in collList)
            {
                string defaultViewTitle = "";
                string viewCount = "";
                string fieldCount = "";
                string itemCount = oList.ItemCount.ToString();

                if (chk_Load_Fields.Checked == true)
                {
                    clientContext.Load(oList.Fields);
                    clientContext.ExecuteQuery();
                    fieldCount = oList.Fields.Count.ToString();
                }

                if (chk_Load_Views.Checked == true)
                {
                    clientContext.Load(oList.Views);
                    clientContext.Load(oList.DefaultView);
                    clientContext.ExecuteQuery();

                    viewCount = oList.Views.Count.ToString();

                    try
                    {
                        SP.View defaultView = oList.DefaultView;

                        defaultViewTitle = defaultView.Title;
                    }
                    catch (Exception ex)
                    {
                        defaultViewTitle = "";
                    }
                }

                dgv_List.Rows.Add();

                dgv_List[0, i].Value = i + 1;
                dgv_List[1, i].Value = oList.Title;
                dgv_List[2, i].Value = defaultViewTitle;
                dgv_List[3, i].Value = fieldCount;
                dgv_List[4, i].Value = viewCount;
                dgv_List[5, i].Value = itemCount;
                dgv_List[6, i].Value = oList.Id;
                dgv_List[7, i].Value = oList.Description;
                dgv_List[8, i].Value = oList.Created;

                // Increment counter
                i++;
            }
        }
    }
}
