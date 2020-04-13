using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Test_List : System.Windows.Forms.Form
    {
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
            this.txt_Guid.Text = "a0aa00a0-1234-1a23-9f99-54321bc78d90";
            this.txt_Url.Text = @"https://my.sharepoint.com/Files/File%20Area/Live/";

            this.Width = 1000;
        }

        private void cmd_Open_List_Click(object sender, EventArgs e)
        {
            lbl_Summary.Text = "";
            dgv_List.Rows.Clear();
            dgv_List.Columns.Clear();
            dgv_List.Refresh();

            string url = this.txt_Url.Text;
            string guid = this.txt_Guid.Text;

            string errorMessage = null;

            // Get client
            ClientContext clientContext = SharePoint.GetClient(url, frm_Main_Menu.username, frm_Main_Menu.password, ref errorMessage);

            if (clientContext == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            // Get the SharePoint web  
            Web web = clientContext.Web;

            Guid g = new Guid(guid);

            List oList = web.Lists.GetById(g);

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

            BindList(clientContext, oList);            
        }

        private void BindList(ClientContext clientContext, List oList)
        {
            // Load in the Fields
            clientContext.Load(oList.Fields);
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
                        var value = oListItem.FieldValues[oField.InternalName];

                        // Check for null
                        if(value != null)
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
                        }

                        // Enter the value in the cell
                        dgv_List[j, i].Value = value;
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

            // Finally, if any rows got added, auto-size the columns
            if (dgv_List.Rows.Count > 0)
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
            }
        }

        private void cmd_Excel_Click(object sender, EventArgs e)
        {
            cls_Excel.ExportDatagridview(dgv_List);
        }
    }
}
