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

            // Store site URL
            string siteUrl = dgv_Data[3, row].Value.ToString();

            // Store site name
            string siteName = dgv_Data[1, row].Value.ToString();

            // Open the List form
            frm_Data_List listForm = OpenForm(siteName, siteUrl, this.Name);

            // Add columns to the data grid view
            AddColumns(listForm);

            // Get lists
            AddLists(siteUrl, listForm.dgv_Data);

            // Show the List form
            listForm.Show();
        }

        private void AddColumns(frm_Data_List listForm)
        {
            DataGridView dgv_List = listForm.dgv_Data;

            // Create a linked column for URL
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "Site URL";
            lnk.Name = "url";
            lnk.UseColumnTextForLinkValue = false;

            dgv_List.Columns.Add("listNumber", "Number");
            dgv_List.Columns.Add("listName", "List Name");
            dgv_List.Columns.Add("baseType", "Type");
            dgv_List.Columns.Add("defaultView", "Default View");
            dgv_List.Columns.Add("fieldCount", "Field Count");
            dgv_List.Columns.Add("viewCount", "View Count");
            dgv_List.Columns.Add("itemCount", "Item Count");
            dgv_List.Columns.Add("listId", "GUID");
            dgv_List.Columns.Add("description", "Description");
            dgv_List.Columns.Add("created", "Created");
            dgv_List.Columns.Add(lnk);
        }

        private void AddLists(string siteUrl, DataGridView dgv_List)
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


                dgv_List.Rows.Add();

                dgv_List[0, i].Value = i + 1;
                dgv_List[1, i].Value = oList.Title;
                dgv_List[2, i].Value = oList.BaseType;
                dgv_List[3, i].Value = defaultViewTitle;
                dgv_List[4, i].Value = fieldCount;
                dgv_List[5, i].Value = viewCount;
                dgv_List[6, i].Value = itemCount;
                dgv_List[7, i].Value = oList.Id;
                dgv_List[8, i].Value = oList.Description;
                dgv_List[9, i].Value = oList.Created;
                dgv_List[10, i].Value = defaultViewUrl;

                // Increment counter
                i++;
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

            return listForm;
        }
    }
}
