using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Test_List : System.Windows.Forms.Form
    {
        ClientContext clientContext = null;
        List oList = null;

        public frm_Test_List()
        {
            InitializeComponent();
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Test_List_Load(object sender, EventArgs e)
        {
            this.txt_Guid.Text = "1456cb7b-c2f5-4291-8bfc-cec60c153588";
            this.txt_Url.Text = @"https://brandingscience.sharepoint.com/BScFiles/3 Jobs Area/jobs";

            this.Width = 1000;
        }

        private void cmd_Open_List_Click(object sender, EventArgs e)
        {
            lbl_Summary.Text = "";
            dgv_List.Rows.Clear();
            dgv_List.Columns.Clear();
            dgv_List.Refresh();

            cmd_Versions.Enabled = false;

            string url = this.txt_Url.Text;
            string guid = this.txt_Guid.Text;

            string errorMessage = null;

            // Get client
            clientContext = SharePoint.GetClient(url, frm_Main_Menu.username, frm_Main_Menu.password, ref errorMessage);

            if (clientContext == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            // Get the SharePoint web  
            Web web = clientContext.Web;

            try
            {
                Guid g = new Guid(guid);
                oList = web.Lists.GetById(g);
            }
            catch(System.FormatException fex)
            {
                MessageBox.Show(fex.Message, "Incorrect GUID Format");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Load list
            clientContext.Load(oList);

            // Execute the query to the server
            try
            {
                clientContext.ExecuteQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            BindList(oList.Fields);            
        }

        private void BindList(SP.FieldCollection collField)
        {
            // Load in the Fields
            clientContext.Load(collField);
            clientContext.ExecuteQuery();

            int i = 0;

            // Create a Row Number column
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "rowNumber";
            col.HeaderText = "Row Number";
            col.ValueType = typeof(int);
            dgv_List.Columns.Add(col);

            // Update label text
            lbl_Summary.Text = "Adding columns to Data Grid View control";
            lbl_Summary.Refresh();

            // Loop through the fields in the list
            foreach (SP.Field oField in oList.Fields)
            {
                // We will not add computed fields
                bool add = true;

                // We will not show lookup fields
                bool show = true;

                // Determine whether to add/show field
                switch(oField.TypeAsString)
                {
                    case "Computed":
                        add = false;
                        break;
                    case "Lookup":
                        show = false;
                        break;
                }

                // Check the we are not adding computed fields as these are not included in the oListItem.FieldValues[] array
                if (add)
                {
                    // Increment row counter
                    i++;

                    // Create a Text Box column, set name and header
                    col = new DataGridViewTextBoxColumn();
                    col.Name = oField.InternalName;
                    col.HeaderText = oField.Title;
                    dgv_List.Columns.Add(col);
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Visible = show;

                    // Refresh for visual effect
                    if (i <= 20)
                    {
                        dgv_List.Refresh();
                    }
                }
            }

            // Update label text
            lbl_Summary.Text = "Added " + i.ToString() + " columns...";
            lbl_Summary.Refresh();

            // Create a new Caml Query
            CamlQuery camlQuery = new CamlQuery();

            // Set the XML
            camlQuery.ViewXml = "<View><Query>{0}</Query></View>";

            // Define a collection to store the list items in
            ListItemCollection collListItem = oList.GetItems(camlQuery);

            // Load in the items
            clientContext.Load(collListItem);

            // Attempt to retreive the List Items
            try
            {
                clientContext.ExecuteQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Determine the row limit
            int numRowsMax = (int)nud_Row_Limit.Value;
            int numRowsList = collListItem.Count;
            int numRows = numRowsMax;

            // Return all rows if no limit set
            if (numRows == 0)
            {
                numRows = numRowsList;
            }

            // Reset row counter
            i = 0;

            // Declare variable for reporting column lookup errors
            string colError = "";

            // Loop through each item in the collection
            foreach (ListItem oListItem in collListItem)
            {
                // Add a row to the Data Grid View control
                dgv_List.Rows.Add();

                // Reset column counter
                int j = 0;

                // Add the "row number" field we created manually
                dgv_List[j, i].Value = i + 1;

                // Loop through fields in the list
                foreach (SP.Field oField in oList.Fields)
                {
                    // Exclude computed fields
                    if (oField.TypeAsString != "Computed")
                    {
                        // Increment column counter
                        j++;

                        // Store the list/field value
                        try
                        {
                            var value = oListItem.FieldValues[oField.InternalName];

                            // Check for null
                            if (value != null)
                            {
                                /*
                                // Try and lookup object-based fields
                                switch (value.ToString())
                                {
                                    case "Microsoft.SharePoint.Client.FieldUserValue":

                                        SP.FieldUserValue uField = (SP.FieldUserValue)value;
                                        value = uField.LookupValue.ToString();

                                        break;

                                    case "Microsoft.SharePoint.Client.FieldLookupValue[]":

                                        value = null;

                                        break;
                                }
                                */

                                value = ChangeValue(value);
                            }

                            // Enter the value in the cell
                            dgv_List[j, i].Value = value;
                        }
                        catch(Exception ex)
                        {
                            // Report as lookup error
                            if (i == 0)
                            {
                                colError += oField.InternalName + "\r\n";
                            }

                            j--;
                        }
                    }
                }

                // Increment the row counter
                i++;

                // Update label text
                lbl_Summary.Text = "Returned " + i.ToString("#,##0") + " out of " + numRowsList.ToString("#,##0") + " record(s)";
                lbl_Summary.Refresh();

                // Jump out if we have reached the limit
                if (i >= numRows)
                {
                    break;
                }
            }

            // Report column lookup errors
            if(colError != "")
            {
                colError = "The following columns could not be found in the FieldValues array:\r\n\r\n" + colError;

                MessageBox.Show(colError, "Column Not Found");
            }

            // Finally, if any rows got added, auto-size the columns
            if (dgv_List.Rows.Count > 0 && dgv_List.Rows.Count <= 500)
            {
                string text = lbl_Summary.Text;
                lbl_Summary.Text = "Auto-sizing columns...";
                lbl_Summary.Refresh();

                foreach (DataGridViewColumn c in dgv_List.Columns)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    int width = c.Width;

                    if(width >= 300)
                    {
                        width = 300;
                    }

                    c.Width = width;

                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }

                lbl_Summary.Text = text;
                lbl_Summary.Refresh();

                cmd_Versions.Enabled = true;
            }
        }

        private dynamic ChangeValue(dynamic value)
        {
            // Try and lookup object-based fields
            switch (value.ToString())
            {
                case "Microsoft.SharePoint.Client.FieldUserValue":

                    SP.FieldUserValue uField = (SP.FieldUserValue)value;
                    value = uField.LookupValue.ToString();

                    break;

                case "Microsoft.SharePoint.Client.FieldLookupValue[]":

                    value = null;

                    break;
            }

            return value;
        }

        private void cmd_Excel_Click(object sender, EventArgs e)
        {
            cls_Excel.ExportDatagridview(dgv_List);
        }

        private void cmd_Versions_Click(object sender, EventArgs e)
        {
            if (clientContext == null)
            {
                return;
            }

            frm_Test_List testForm = new frm_Test_List();

            // Disable / hide irrelevant controls
            testForm.cmd_Open_List.Visible = false;
            testForm.cmd_Versions.Visible = false;
            testForm.txt_Guid.Visible = false;
            testForm.txt_Url.Visible = false;
            testForm.lbl_Guid.Visible = false;
            testForm.lbl_Url.Visible = false;
            testForm.nud_Row_Limit.Value = 0;
            testForm.nud_Row_Limit.Enabled = false;

            testForm.Show();

            int col = dgv_List.Columns["ID"].Index;
            int row = dgv_List.CurrentRow.Index;
            int id = (int)dgv_List[col, row].Value;

            // Find the specified item
            SP.ListItem oListItem = oList.GetItemById(id);

            // Load the Item
            clientContext.Load(oListItem);

            // Load the Versions
            clientContext.Load(oListItem.Versions);

            // Do this bit
            clientContext.ExecuteQuery();

            // Loop through each Version
            foreach (SP.ListItemVersion versionItem in oListItem.Versions)
            {
                // Retrieve the fields
                SP.FieldCollection collField = versionItem.Fields;

                clientContext.Load(collField);
                clientContext.ExecuteQuery();

                int i = 0;

                // Loop through fields
                foreach (SP.Field oField in collField)
                {
                    string fieldName = oField.Title;
                    string fieldValue = "null";

                    try
                    {
                        if (oListItem[oField.InternalName] != null)
                        {
                            fieldValue = versionItem[oField.InternalName].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        fieldValue = "Error";
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
        }
    }
}
