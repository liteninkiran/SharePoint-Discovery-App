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

            // Store column of Site Address
            col = dgv_Data.Columns["siteAddress"].Index;

            // Store column of Site Address
            string siteAddress = dgv_Data[col, row].Value.ToString();

            // Store column of Site URL
            col = dgv_Data.Columns["url"].Index;

            // Store site URL if it exists
            string siteUrl = null;

            // Store site URL
            if (dgv_Data[col, row].Value != null)
            {
                siteUrl = dgv_Data[col, row].Value.ToString();
            }
            else
            {
                siteUrl = siteAddress;
            }

            // Open the List form
            frm_Data_View viewForm = OpenForm_View(listName, this.Name, this.lbl_Header.Tag.ToString(), siteUrl);

            // Store column of GUID
            col = dgv_Data.Columns["listId"].Index;

            // Store site GUID
            string listId = dgv_Data[col, row].Value.ToString();

            // Add records to the data grid
            AddViews(viewForm, listId, siteAddress);

            // Show the List form
            viewForm.Show();
        }

        private void cmd_Get_Fields_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of List Name
            int col = dgv_Data.Columns["listName"].Index;

            // Store site List Name
            string listName = dgv_Data[col, row].Value.ToString();

            // Store column of Site Address
            col = dgv_Data.Columns["siteAddress"].Index;

            // Store column of Site Address
            string siteAddress = dgv_Data[col, row].Value.ToString();

            // Store column of Site URL
            col = dgv_Data.Columns["url"].Index;

            // Store site URL if it exists
            string siteUrl = null;

            // Store site URL
            if (dgv_Data[col, row].Value != null)
            {
                siteUrl = dgv_Data[col, row].Value.ToString();
            }
            else
            {
                siteUrl = siteAddress;
            }

            // Open the List form
            frm_Data_Field fieldForm = OpenForm_Field(listName, this.Name, this.lbl_Header.Tag.ToString(), siteUrl);

            // Store column of GUID
            col = dgv_Data.Columns["listId"].Index;

            // Store site GUID
            string listId = dgv_Data[col, row].Value.ToString();

            // Add records to the data grid
            AddFields(fieldForm, listId, siteAddress);

            // Show the List form
            fieldForm.Show();
        }

        private void AddViews(frm_Data_View viewForm, string listId, string siteAddress)
        {
            Guid g = new Guid(listId);

            SP.ClientContext clientContext = SharePoint.GetClient(siteAddress, frm_Main_Menu.username, frm_Main_Menu.password);
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
                string viewId = oView.Id.ToString();
                string fieldCount = oView.ViewFields.Count.ToString();
                string rowLimit = oView.RowLimit.ToString();
                string viewQuery = oView.ViewQuery;
                string url = frm_Main_Menu.siteUrl + oView.ServerRelativeUrl;

                viewForm.AddRow(i, viewName, fieldCount, rowLimit, viewId, viewQuery, url);
            }
        }

        private void AddFields(frm_Data_Field fieldForm, string listId, string siteAddress)
        {
            Guid g = new Guid(listId);

            SP.ClientContext clientContext = SharePoint.GetClient(siteAddress, frm_Main_Menu.username, frm_Main_Menu.password);
            SP.List oList = clientContext.Web.Lists.GetById(g);

            // Load in the Views
            clientContext.Load(oList.Fields);
            clientContext.ExecuteQuery();

            int i = 0;

            foreach (SP.Field oField in oList.Fields)
            {
                i++;

                string fieldName = oField.Title;
                string fieldType = oField.TypeAsString;
                string defaultValue = oField.DefaultValue;
                string enforceUniqueValues = oField.EnforceUniqueValues.ToString();
                string required = oField.Required.ToString();
                string readOnly = oField.ReadOnlyField.ToString();
                string formula = null;

                if (oField.TypeAsString == "Calculated")
                {
                    FieldCalculated calcField = (FieldCalculated)oField;
                    formula = calcField.Formula;
                }

                if (oField.TypeAsString == "Computed")
                {
                    //FieldComputed calcField = (FieldComputed)oField;
                    //formula = calcField.SchemaXml;
                }

                fieldForm.AddRow(i, fieldName, fieldType, enforceUniqueValues, required, readOnly, defaultValue, formula);
            }
        }

        public frm_Data_View OpenForm_View(string listName, string tag, string subSiteName, string siteUrl)
        {
            // Create a new instance of the Site class
            frm_Data_View viewForm = new frm_Data_View();

            viewForm.Height = 700;
            viewForm.Width = 1500;

            viewForm.Text = siteUrl;
            viewForm.lbl_Header.Text = "Views - " + listName + " (" + subSiteName + ")";
            viewForm.Tag = tag;

            // Add columns to the data grid view
            viewForm.AddColumns();

            return viewForm;
        }

        public frm_Data_Field OpenForm_Field(string listName, string tag, string subSiteName, string siteUrl)
        {
            // Create a new instance of the Site class
            frm_Data_Field fieldForm = new frm_Data_Field();

            fieldForm.Height = 700;
            fieldForm.Width = 1500;

            fieldForm.Text = siteUrl;
            fieldForm.lbl_Header.Text = "Fields - " + listName + " (" + subSiteName + ")";
            fieldForm.Tag = tag;

            // Add columns to the data grid view
            fieldForm.AddColumns();

            return fieldForm;
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
            col = dgv_Data.Columns[dgv_Data.Columns.Add("siteName", "Site Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("siteAddress", "Site Address")];
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
