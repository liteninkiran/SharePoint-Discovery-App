using System;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_View : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_View()
        {
            InitializeComponent();
        }

        public void AddColumns()
        {
            // Create a linked column for URL
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "Site URL";
            lnk.Name = "url";
            lnk.UseColumnTextForLinkValue = false;

            DataGridViewColumn col = null;

            // Add columns
            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowNumber", "Number")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("viewName", "Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("siteName", "Site Name")]; //col.Visible = false;
            col = dgv_Data.Columns[dgv_Data.Columns.Add("siteAddress", "Site Address")]; //col.Visible = false;
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fieldCount", "Field Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowLimit", "Row Limit")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("viewId", "GUID")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("query", "Query")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(lnk)];
        }

        private void frm_Data_View_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns("query");
        }

        private void cmd_Copy_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of URL
            int col = dgv_Data.Columns["query"].Index;

            // Store query XML
            string camlQuery = dgv_Data[col, row].Value.ToString();

            // Try and tidy up
            camlQuery = camlQuery.Replace("<", "\r\n<").Trim();

            // Copy to clipboard
            Clipboard.SetText(camlQuery);

            // Inform user
            MessageBox.Show("Copied to clipboard:\r\n\r\n" + camlQuery);
        }

        private void cmd_Get_Fields_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button doesn't do anything yet");
        }

        private void GetFields(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of View Name
            int col = dgv_Data.Columns["viewName"].Index;

            // Store site List Name
            string viewName = dgv_Data[col, row].Value.ToString();

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
            frm_Data_Field fieldForm = OpenForm_Field(viewName, this.Name, this.lbl_Header.Tag.ToString(), siteUrl);

            // Store column of GUID
            col = dgv_Data.Columns["listId"].Index;

            // Store site GUID
            string listId = dgv_Data[col, row].Value.ToString();

            // Add records to the data grid
            AddFields(fieldForm, listId, siteAddress);

            // Show the List form
            fieldForm.Show();
        }

        public frm_Data_Field OpenForm_Field(string listName, string tag, string subSiteName, string siteUrl)
        {
            // Create a new instance of the Site class
            frm_Data_Field fieldForm = new frm_Data_Field();

            fieldForm.Height = 700;
            fieldForm.Width = 1500;
            fieldForm.WindowState = FormWindowState.Maximized;

            fieldForm.Text = siteUrl;
            fieldForm.lbl_Header.Text = "Fields - " + listName + " (" + subSiteName + ")";
            fieldForm.Tag = tag;

            // Add columns to the data grid view
            fieldForm.AddColumns();

            return fieldForm;
        }

        private void AddFields(frm_Data_Field fieldForm, string listId, string siteAddress)
        {
            Guid g = new Guid(listId);

            SP.ClientContext clientContext = SharePoint.GetClient(siteAddress, frm_Main_Menu.username, frm_Main_Menu.password);
            SP.List oList = clientContext.Web.Lists.GetById(g);

            // Load in the Fields
            clientContext.Load(oList.Fields);
            clientContext.ExecuteQuery();

            int i = 0;

            foreach (SP.Field oField in oList.Fields)
            {
                // Store the Field Type
                string fieldType = oField.TypeAsString;

                // We will exclude some entries by Field Type
                bool skip = false;

                // These 2 attributes will depend on the field type
                string maxLength = null;
                string formula = null;

                // Find field types for specific actions
                switch (fieldType)
                {
                    // Max Length
                    case "Text":

                        // Convert to "Text Field"
                        SP.FieldText textField = (SP.FieldText)oField;

                        // We now have access to the attribute
                        maxLength = textField.MaxLength.ToString();

                        // Break out of the switch
                        break;

                    // Formula
                    case "Calculated":

                        // Convert to "Calculated Field"
                        FieldCalculated calcField = (FieldCalculated)oField;

                        // We now have access to the attribute
                        formula = calcField.Formula;

                        // Break out of the switch
                        break;

                    // We won't include "Computed" or "Lookup" fields
                    case "Lookup":
                    case "Computed":

                        // Skip
                        skip = true;

                        // Break out of the switch
                        break;
                }

                if (skip == false)
                {
                    i++;

                    string fieldName = oField.Title;
                    string defaultValue = oField.DefaultValue;
                    string enforceUniqueValues = oField.EnforceUniqueValues.ToString();
                    string required = oField.Required.ToString();
                    string readOnly = oField.ReadOnlyField.ToString();
                    string isSealed = oField.Sealed.ToString();

                    fieldForm.AddRow
                    (
                        i,
                        fieldName,
                        fieldType,
                        maxLength,
                        enforceUniqueValues,
                        required,
                        readOnly,
                        isSealed,
                        defaultValue,
                        formula
                    );
                }
            }
        }
    }
}
