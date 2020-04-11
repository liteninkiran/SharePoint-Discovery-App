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

        private void cmd_Get_Lists_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of URL
            int col = dgv_Data.Columns["url"].Index;
            
            // Store site URL
            string siteUrl = dgv_Data[col, row].Value.ToString();

            // Store column of Site Name
            col = dgv_Data.Columns["siteName"].Index;

            // Store site name
            string siteName = dgv_Data[col, row].Value.ToString();

            // Open the List form
            frm_Data_List listForm = OpenForm(siteName, siteUrl, this.Name);

            // Get lists
            AddLists(siteUrl, listForm);

            // Show the List form
            listForm.Show();
        }

        private void SetViewVars(ClientContext clientContext, SP.List oList, DataGridView dgv_Data, ref string defaultViewUrl, ref string defaultViewTitle, ref string viewCount)
        {
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
                    defaultViewUrl = frm_Main_Menu.siteUrl + defaultView.ServerRelativeUrl;
                }
                catch (Exception ex)
                {
                    defaultViewTitle = "";
                }
            }
            else
            {
                dgv_Data.Columns["defaultView"].Visible = false;
                dgv_Data.Columns["viewCount"].Visible = false;
                dgv_Data.Columns["url"].Visible = false;
            }
        }

        private void SetFieldVars(ClientContext clientContext, SP.List oList, DataGridView dgv_Data, ref string fieldCount)
        {
            if (chk_Load_Fields.Checked == true)
            {
                clientContext.Load(oList.Fields);
                clientContext.ExecuteQuery();
                fieldCount = oList.Fields.Count.ToString();
            }
            else
            {
                dgv_Data.Columns["fieldCount"].Visible = false;
            }
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

        private void AddLists(string siteUrl, frm_Data_List listForm)
        {
            ClientContext clientContext = SharePoint.GetClient(siteUrl, frm_Main_Menu.username, frm_Main_Menu.password);
            ListCollection collList = SharePoint.GetLists(clientContext);

            // Initialise row counter
            int i = 0;

            foreach (SP.List oList in collList)
            {
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

                listForm.AddRow
                    (
                        i.ToString(),
                        oList.Title,
                        oList.Description,
                        listType,
                        defaultViewTitle,
                        fieldCount,
                        viewCount,
                        itemCount,
                        oList.Id.ToString(),
                        oList.Created.ToString(),
                        defaultViewUrl
                    );
            }
        }

        public static frm_Data_List OpenForm(string siteName, string siteUrl, string tag)
        {
            // Create a new instance of the Site class
            frm_Data_List listForm = new frm_Data_List();

            listForm.Height = 700;
            listForm.Width = 1500;

            listForm.Text = siteUrl;
            listForm.lbl_Header.Text = "Lists - " + siteName;
            listForm.lbl_Header.Tag = siteName;
            listForm.Tag = tag;
            listForm.dgv_Data.Tag = siteUrl;

            // Add columns to the data grid view
            listForm.AddColumns();
            
            return listForm;
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

        private void frm_Data_Site_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns();
        }
    }
}
