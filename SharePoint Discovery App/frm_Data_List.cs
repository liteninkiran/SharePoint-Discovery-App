﻿using System;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_List : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_List()
        {
            InitializeComponent();
        }

        private void frm_Data_List_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns("description");
        }

        private void cmd_Get_Views_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of List Name
            int col = dgv_Data.Columns["listName"].Index;

            // Store site List Name
            string listName = dgv_Data[col, row].Value.ToString();

            // Open the List form
            frm_Data_View viewForm = OpenForm_View(listName, this.Name, this.lbl_Header.Tag.ToString());

            // Store column of GUID
            col = dgv_Data.Columns["listId"].Index;

            // Store site GUID
            string listId = dgv_Data[col, row].Value.ToString();

            // Add records to the data grid
            AddViews(viewForm, listId);

            // Show the List form
            viewForm.Show();
        }

        private void cmd_Get_Fields_Click(object sender, EventArgs e)
        {

        }

        private void AddViews(frm_Data_View viewForm, string listId)
        {
            Guid g = new Guid(listId);

            SP.ClientContext clientContext = SharePoint.GetClient(dgv_Data.Tag.ToString(), frm_Main_Menu.username, frm_Main_Menu.password);
            SP.List oList = clientContext.Web.Lists.GetById(g);

            // Load in the Views
            clientContext.Load(oList.Views);
            clientContext.ExecuteQuery();

            int i = 0;

            foreach (SP.View oView in oList.Views)
            {
                i++;

                clientContext.Load(oView.ViewFields);
                clientContext.ExecuteQuery();

                string viewName = oView.Title;
                string fieldCount = oView.ViewFields.Count.ToString();
                string rowLimit = oView.RowLimit.ToString();
                string viewQuery = oView.ViewQuery;
                string url = frm_Main_Menu.siteUrl + oView.ServerRelativeUrl;

                viewForm.AddRow(i, viewName, fieldCount, rowLimit, viewQuery, url);
            }
        }

        public static frm_Data_View OpenForm_View(string listName, string tag, string subSiteName)
        {
            // Create a new instance of the Site class
            frm_Data_View viewForm = new frm_Data_View();

            viewForm.Height = 700;
            viewForm.Width = 1500;

            viewForm.Text = "";
            viewForm.lbl_Header.Text = "Views - " + listName + " (" + subSiteName + ")";
            viewForm.Tag = tag;

            // Add columns to the data grid view
            viewForm.AddColumns();

            return viewForm;
        }

        public void AddColumns()
        {
            // Create a linked column for URL
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "Site URL";
            lnk.Name = "url";
            lnk.UseColumnTextForLinkValue = false;

            DataGridViewColumn col = null;

            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowNumber", "Number")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("listName", "List Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("description", "Description")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("baseType", "Type")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("defaultView", "Default View")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fieldCount", "Field Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("viewCount", "View Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("itemCount", "Item Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("listId", "GUID")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("created", "Created")]; col.ValueType = typeof(DateTime);
            col = dgv_Data.Columns[dgv_Data.Columns.Add(lnk)];
        }
    }
}
