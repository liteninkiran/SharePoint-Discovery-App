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
            col = dgv_Data.Columns["title"].Index;

            // Store site name
            string siteName = dgv_Data[col, row].Value.ToString();

            // Open the List form
            frm_Data_List listForm = OpenForm(siteName, siteUrl, this.Name);

            // Get lists
            AddLists(siteUrl, listForm);

            // Show the List form
            listForm.Show();
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
                        defaultViewUrl = frm_Main_Menu.siteUrl + defaultView.ServerRelativeUrl;
                    }
                    catch (Exception ex)
                    {
                        defaultViewTitle = "";
                    }
                }

                // Increment counter
                i++;

                listForm.AddRow
                    (
                        i.ToString(),
                        oList.Title,
                        oList.BaseType.ToString(),
                        defaultViewTitle,
                        fieldCount,
                        viewCount,
                        itemCount,
                        oList.Id.ToString(),
                        oList.Description,
                        oList.Created.ToString(),
                        defaultViewUrl
                    );

            }
        }

        public static frm_Data_List OpenForm(string siteName, string siteUrl, string tag)
        {
            // Create a new instance of the Site class
            frm_Data_List listForm = new frm_Data_List();

            listForm.Text = "Lists";
            listForm.lbl_Header.Text = "Lists";

            listForm.Height = 700;
            listForm.Width = 1500;

            listForm.Text = "Lists - " + siteUrl;
            listForm.lbl_Header.Text = listForm.lbl_Header.Text + " - " + siteName;
            listForm.Tag = tag;

            // Add columns to the data grid view
            listForm.AddColumns();

            return listForm;
        }

        private void frm_Data_Site_Load(object sender, EventArgs e)
        {
            
        }

        public void AddColumns()
        {
            // Create a linked column for URL
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "Site URL";
            lnk.Name = "url";
            lnk.UseColumnTextForLinkValue = false;

            // Add columns
            dgv_Data.Columns.Add("siteNumber", "Number");
            dgv_Data.Columns.Add("title", "Title");
            dgv_Data.Columns.Add("parent", "Parent Site");
            dgv_Data.Columns.Add("listCount", "List Count");
            dgv_Data.Columns.Add(lnk);
        }
    }
}
