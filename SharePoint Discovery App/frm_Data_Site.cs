
using System;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_Site : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_Site()
        {
            InitializeComponent();
        }

        private void frm_Data_Site_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns();

            tip_Search_By_Guid.SetToolTip(this.txt_Guid, "Enter a List or View GUID. The Data Grid View will be searched row-by-row until a match is found.");
            tip_Search_By_Name.SetToolTip(this.txt_Name, "Enter a List or View Name. The Data Grid View will be searched row-by-row, returning all matches found.");
        }

        private void cmd_Get_Lists_Click(object sender, EventArgs e)
        {
            string listGuid = txt_Guid.Text;
            string listName = txt_Name.Text;

            if (listGuid != "" || listName != "")
            {
                GetListByNameOrGuid(listGuid, listName);
            }
            else
            {
                GetAllListsForSelectedSite();
            }            
        }

        private void cmd_Get_Views_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button doesn't do anything yet");
        }

        private void cmd_Get_Users_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of URL
            int col = dgv_Data.Columns["url"].Index;

            // Store site URL
            string siteUrl = dgv_Data[col, row].Value.ToString();

            // Store column of Site Name
            col = dgv_Data.Columns["parent"].Index;

            // Create a variable for the Site Name
            string siteName = "";

            // Store parent site name if we are not at the top level
            if (dgv_Data[col, row].Value != null)
            {
                siteName = dgv_Data[col, row].Value.ToString() + " --> ";
            }

            // Store column of Site Name
            col = dgv_Data.Columns["siteName"].Index;

            // Store site name
            siteName += dgv_Data[col, row].Value.ToString();

            // Open the List form
            frm_Data_User userForm = OpenForm_User(siteName, siteUrl, this.Name, 1500, 700);

            // Hide the Site Name column
            //userForm.dgv_Data.Columns["siteName"].Visible = false;

            // Hide the Site Name column
            //userForm.dgv_Data.Columns["siteAddress"].Visible = false;

            // Get lists
            AddUsers(siteName, siteUrl, userForm);

            // Show the List form
            userForm.Show();
        }

        private void GetListByNameOrGuid(string listGuid, string listName)
        {
            txt_Guid.Text = "";
            txt_Name.Text = "";

            // Store loop counter for rows added to the data grid view
            int i = 0;

            // If we find a GUID, there will only be one
            bool foundGuid = false;

            // Store variables for field values
            string defaultViewUrl = null;
            string defaultViewTitle = null;
            string viewCount = null;
            string fieldCount = null;
            string itemCount = null;
            string listType = null;
            string siteName = null;
            string siteAddress = null;
            string listTitle = null;

            // Open the List form
            frm_Data_List listForm = OpenForm("", "", this.Name, 1000, 500);

            // Show the Site Name column
            listForm.dgv_Data.Columns["siteName"].Visible = true;

            // Hide the Site Address column
            listForm.dgv_Data.Columns["siteAddress"].Visible = false;

            // Loop through each row of the data grid view
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                // If we find a GUID, there will only be one
                foundGuid = false;

                // Store the Site URL to get the Client Context
                string siteUrl = row.Cells[5].Value.ToString();

                // Select the row in the data grid view for visual effect
                row.Selected = true;

                // Do this or it won't show the selected record
                dgv_Data.Refresh();

                // Get the Client Context
                ClientContext clientContext = SharePoint.GetClient(siteUrl, frm_Main_Menu.username, frm_Main_Menu.password);

                // Store the lists
                ListCollection collList = clientContext.Web.Lists;

                // Load lists
                clientContext.Load(collList);

                // Execute the query to the server  
                clientContext.ExecuteQuery();

                // Loop through each list to check against Name (i.e. Title) or GUID
                foreach (SP.List oList in collList)
                {
                    // Variable to check if we need to add a row
                    bool addRow = false;

                    // If we have a GUID, check the GUID
                    if (listGuid != "")
                    {
                        // Check the GUID
                        if (oList.Id.ToString() == listGuid)
                        {
                            // Select the cell to indicate a find
                            row.Cells[1].Selected = true;

                            // Set the variables
                            foundGuid = true;
                            addRow = true;
                        }
                    }
                    // We are checking name
                    else
                    {
                        // Do a contains for basic "fuzzy" matching
                        if(oList.Title.ToLower().Contains(listName.ToLower()))
                        {
                            // Select the cell to indicate a find
                            row.Cells[1].Selected = true;

                            // Set the variable to add a row
                            addRow = true;
                        }
                    }

                    // Check if we are needing to add a row to the data grid view
                    if(addRow)
                    {
                        // Increment counter
                        i++;

                        // Load lists
                        clientContext.Load(oList, l => l.SchemaXml);
                        
                        // Execute the query to the server  
                        clientContext.ExecuteQuery();

                        // Set the field-related vairables
                        SetFieldVars(clientContext, oList, listForm.dgv_Data, ref fieldCount);

                        // Set the view-related variables
                        SetViewVars(clientContext, oList, listForm.dgv_Data, ref defaultViewUrl, ref defaultViewTitle, ref viewCount);

                        // Set other variables
                        itemCount = oList.ItemCount.ToString();
                        listType = GetBaseTypeDescription(oList.BaseType);
                        siteAddress = row.Cells[5].Value.ToString();
                        listTitle = oList.Title;

                        // Find the full Site Name that the List belongs to
                        if (row.Cells[2].Value != null)
                        {
                            siteName = row.Cells[2].Value.ToString() + " --> " + row.Cells[1].Value.ToString();
                        }
                        else
                        {
                            siteName = row.Cells[1].Value.ToString();
                        }

                        // Add a row to the data grid view
                        listForm.AddRow
                        (
                            i.ToString(),
                            siteName,
                            siteAddress,
                            listTitle,
                            oList.Description,
                            listType,
                            oList.EnableVersioning,
                            oList.MajorVersionLimit,
                            defaultViewTitle,
                            fieldCount,
                            viewCount,
                            itemCount,
                            !oList.DisableGridEditing,
                            oList.Id.ToString(),
                            oList.Created.ToString(),
                            defaultViewUrl,
                            oList.SchemaXml.ToString()
                        );

                        lbl_Row_Count.Text = i.ToString() + " record(s) found";
                        lbl_Row_Count.Refresh();

                        // Show the form if it is still invisible
                        if (listForm.Visible == false)
                        {
                            listForm.Show();
                        }

                        // Refresh it for visual effects
                        listForm.Refresh();

                        // Leave if the addition was the result of a GUID match
                        if (foundGuid == true)
                        {
                            break;
                        }

                    }
                }

                // Leave if the addition was the result of a GUID match
                if (foundGuid == true)
                {
                    break;
                }
            }

            if (i > 0)
            {
                if (foundGuid == true)
                {
                    MessageBox.Show("Found list '" + listTitle + "' with GUID " + listGuid);
                }
                else
                {
                    MessageBox.Show("Found " + i + " list(s) matching the name '" + listName + "'");
                }
            }
            else
            {
                MessageBox.Show("Could not find a match");
            }
        }

        private void GetAllListsForSelectedSite()
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of URL
            int col = dgv_Data.Columns["url"].Index;

            // Store site URL
            string siteUrl = dgv_Data[col, row].Value.ToString();

            // Store column of Site Name
            col = dgv_Data.Columns["parent"].Index;

            // Create a variable for the Site Name
            string siteName = "";

            // Store parent site name if we are not at the top level
            if (dgv_Data[col, row].Value != null)
            {
                siteName = dgv_Data[col, row].Value.ToString() + " --> ";
            }

            // Store column of Site Name
            col = dgv_Data.Columns["siteName"].Index;

            // Store site name
            siteName += dgv_Data[col, row].Value.ToString();

            // Open the List form
            frm_Data_List listForm = OpenForm(siteName, siteUrl, this.Name, 1500, 700);

            // Hide the Site Name column
            listForm.dgv_Data.Columns["siteName"].Visible = false;

            // Hide the Site Name column
            listForm.dgv_Data.Columns["siteAddress"].Visible = false;

            // Get lists
            AddLists(siteName, siteUrl, listForm);

            // Show the List form
            listForm.Show();
        }

        private void SetViewVars(ClientContext clientContext, SP.List oList, DataGridView dgv_Data, ref string defaultViewUrl, ref string defaultViewTitle, ref string viewCount)
        {
            clientContext.Load(oList.Views);
            clientContext.Load(oList.DefaultView);
            clientContext.ExecuteQuery();

            viewCount = oList.Views.Count.ToString();

            try
            {
                SP.View defaultView = oList.DefaultView;

                defaultViewTitle = defaultView.Title;
                defaultViewUrl = frm_Main_Menu.siteUrl + defaultView.ServerRelativeUrl;
            }
            catch (Exception ex)
            {
                defaultViewTitle = "";
            }
        }

        private void SetFieldVars(ClientContext clientContext, SP.List oList, DataGridView dgv_Data, ref string fieldCount)
        {
            clientContext.Load(oList.Fields);
            clientContext.ExecuteQuery();
            fieldCount = oList.Fields.Count.ToString();
        }

        private string GetBaseTypeDescription(SP.BaseType baseType)
        {
            string listType = null;

            switch ((int)baseType)
            {
                case -1: listType = "None"; break;
                case  0: listType = "List"; break;
                case  1: listType = "Document Library"; break;
                case  2: listType = "Unused"; break;
                case  3: listType = "Discussion Board"; break;
                case  4: listType = "Survey"; break;
                case  5: listType = "Issue"; break;
            }

            return listType;
        }

        private void AddLists(string siteName, string siteUrl, frm_Data_List listForm)
        {
            ClientContext clientContext = SharePoint.GetClient(siteUrl, frm_Main_Menu.username, frm_Main_Menu.password);
            ListCollection collList = SharePoint.GetLists(clientContext);

            // Initialise row counter
            int i = 0;

            foreach (SP.List oList in collList)
            {
                // Load lists
                clientContext.Load(oList, l => l.SchemaXml);

                // Execute the query to the server  
                clientContext.ExecuteQuery();

                string defaultViewUrl = null;
                string defaultViewTitle = null;
                string viewCount = null;
                string fieldCount = null;
                string itemCount = oList.ItemCount.ToString();
                string listType = GetBaseTypeDescription(oList.BaseType);

                SetFieldVars(clientContext, oList, listForm.dgv_Data, ref fieldCount);
                SetViewVars(clientContext, oList, listForm.dgv_Data, ref defaultViewUrl, ref defaultViewTitle, ref viewCount);

                // Increment counter
                i++;

                //oList.DisableGridEditing = (listType == "List");
                //oList.Update();   

                listForm.AddRow
                    (
                        i.ToString(),
                        siteName,
                        siteUrl,
                        oList.Title,
                        oList.Description,
                        listType,
                        oList.EnableVersioning,
                        oList.MajorVersionLimit,
                        defaultViewTitle,
                        fieldCount,
                        viewCount,
                        itemCount,
                        !oList.DisableGridEditing,
                        oList.Id.ToString(),
                        oList.Created.ToString(),
                        defaultViewUrl,
                        oList.SchemaXml.ToString()
                    );

                lbl_Row_Count.Text = i.ToString() + " record(s) found";
                lbl_Row_Count.Refresh();

                if (i >= nud_Row_Limit.Value && nud_Row_Limit.Value != 0)
                {
                    break;
                }
            }

            //clientContext.ExecuteQuery();
        }

        private void AddUsers(string siteName, string siteUrl, frm_Data_User userForm)
        {
            ClientContext clientContext = SharePoint.GetClient(siteUrl, frm_Main_Menu.username, frm_Main_Menu.password);

            Web web = clientContext.Web;

            // Instantiates the User Information List
            SP.List userList = web.SiteUserInfoList;

            // Get the current user
            SP.User user = web.CurrentUser;

            // Initialise row counter
            int rowNum = 0;

            // Create a new Caml Query
            CamlQuery camlQuery = new CamlQuery();

            // Set the XML
            camlQuery.ViewXml = "<View><Query>{0}</Query></View>";

            // Define a collection to store the list items in
            ListItemCollection collListItem = userList.GetItems(camlQuery);


            // Load in the items
            clientContext.Load(collListItem, icol => icol.Include(i => i.ContentType));
            clientContext.Load(collListItem);

            // Attempt to retreive the List Items
            try
            {
                clientContext.ExecuteQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            foreach (SP.ListItem oListItem in collListItem)
            {
                // Increment counter
                rowNum++;

                int id = (int)oListItem.FieldValues["ID"];

                object firstName = oListItem.FieldValues["FirstName"];
                object lastName = oListItem.FieldValues["LastName"];
                object fullName = oListItem.FieldValues["Title"];
                object userName = oListItem.FieldValues["UserName"];
                object email = oListItem.FieldValues["EMail"];
                object sipAddress = oListItem.FieldValues["SipAddress"];

                object isSiteAdmin = oListItem.FieldValues["IsSiteAdmin"];
                object deleted = oListItem.FieldValues["Deleted"];
                object hidden = oListItem.FieldValues["UserInfoHidden"];
                object isActive = oListItem.FieldValues["IsActive"];

                string ContentTypeName = oListItem.ContentType.Name;
                object guid = oListItem.FieldValues["GUID"];

                DateTime createDate = Convert.ToDateTime(oListItem.FieldValues["Created"]);
                SP.FieldUserValue author = (SP.FieldUserValue)oListItem.FieldValues["Author"];
                string createUser = author.LookupValue.ToString();

                DateTime modifyDate = Convert.ToDateTime(oListItem.FieldValues["Modified"]);
                SP.FieldUserValue editor = (SP.FieldUserValue)oListItem.FieldValues["Editor"];
                string modifyUser = editor.LookupValue.ToString();

                if (firstName != null)
                {
                    //System.Diagnostics.Debugger.Break();
                }

                userForm.AddRow
                (
                    rowNum,
                    id,
                    firstName,
                    lastName,
                    fullName,
                    userName,
                    email,
                    sipAddress,
                    isSiteAdmin,
                    deleted,
                    hidden,
                    isActive,
                    ContentTypeName,
                    guid,
                    createDate,
                    createUser,
                    modifyDate,
                    modifyUser
                );

                lbl_Row_Count.Text = rowNum.ToString() + " record(s) found";
                lbl_Row_Count.Refresh();

                if (rowNum >= nud_Row_Limit.Value && nud_Row_Limit.Value != 0)
                {
                    break;
                }
            }


        }

        public frm_Data_List OpenForm(string siteName, string siteUrl, string tag, int width, int height)
        {
            // Create a new instance of the Site class
            frm_Data_List listForm = new frm_Data_List();

            listForm.Width = width;
            listForm.Height = height;
            listForm.WindowState = FormWindowState.Maximized;

            listForm.Text = siteUrl;
            listForm.lbl_Header.Text = "Lists - " + siteName;
            listForm.lbl_Header.Tag = siteName;
            listForm.Tag = tag;

            // Add columns to the data grid view
            listForm.AddColumns();
            
            return listForm;
        }

        public frm_Data_User OpenForm_User(string siteName, string siteUrl, string tag, int width, int height)
        {
            // Create a new instance of the Site class
            frm_Data_User userForm = new frm_Data_User();

            userForm.Width = width;
            userForm.Height = height;
            userForm.WindowState = FormWindowState.Maximized;

            userForm.Text = siteUrl;
            userForm.lbl_Header.Text = "Lists - " + siteName;
            userForm.lbl_Header.Tag = siteName;
            userForm.Tag = tag;

            // Add columns to the data grid view
            userForm.AddColumns();

            return userForm;
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
            col = dgv_Data.Columns[dgv_Data.Columns.Add("siteName", "Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("parent", "Parent Site")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("listCount", "List Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("created", "Created")]; col.ValueType = typeof(DateTime);
            col = dgv_Data.Columns[dgv_Data.Columns.Add(lnk)];
        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Guid.Enabled = txt_Name.Text == "";
            cmd_Get_Views.Enabled = (txt_Name.Text != "" || txt_Guid.Text != "");
            nud_Row_Limit.Visible = (txt_Name.Text == "" && txt_Guid.Text == "");
            lbl_Row_Limit.Visible = (txt_Name.Text == "" && txt_Guid.Text == "");
        }

        private void txt_Guid_TextChanged(object sender, EventArgs e)
        {
            txt_Name.Enabled = txt_Guid.Text == "";
            cmd_Get_Views.Enabled = (txt_Name.Text != "" || txt_Guid.Text != "");
            nud_Row_Limit.Visible = (txt_Name.Text == "" && txt_Guid.Text == "");
            lbl_Row_Limit.Visible = (txt_Name.Text == "" && txt_Guid.Text == "");
        }
    }
}
