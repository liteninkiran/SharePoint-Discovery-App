using System;
using System.Security;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Main_Menu : System.Windows.Forms.Form
    {
        public static string siteUrl = "";
        public static string username = "";
        public static string password = "";

        public frm_Main_Menu()
        {
            InitializeComponent();
        }

        private void frm_Main_Menu_Load(object sender, EventArgs e)
        {
            txt_Site.Text = "https://my.sharepoint.com";
            txt_Username.Text = "user@domain.com";
            txt_Password.Text = "password";
        }

        private void cmd_Get_Sites_Click(object sender, EventArgs e)
        {
            // Set the public variables
            SetStaticVars();

            // Try to get the client
            ClientContext clientContext = GetClient();

            // Exit if we got an error
            if (clientContext == null){return;}

            // Update button caption as it will take a while to load all sites/sub-sites
            ChangeButton(true);

            // Open the Site form
            frm_Site siteForm = OpenForm();

            // Add columns to the data grid view
            AddColumns(siteForm);

            // Output all the sites/sub-sites into the data grid view
            GetSiteAndSubSites(clientContext, siteForm.dgv_Site, chk_Recursive.Checked);

            // Show the Site form
            siteForm.ShowDialog();

            // Change the button caption back
            ChangeButton(false);
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetStaticVars()
        {
            // Store credentials
            siteUrl = txt_Site.Text;
            username = txt_Username.Text;
            password = txt_Password.Text;
        }

        private void ChangeButton(bool start)
        {
            if(start)
            {
                this.cmd_Get_Sites.Width = 200;
                this.cmd_Get_Sites.Text = "Getting sites. Please wait...";
            }
            else
            {
                this.cmd_Get_Sites.Text = "Get Sites";
                this.cmd_Get_Sites.Width = 100;
            }
        }

        public static frm_Site OpenForm()
        {
            // Create a new instance of the Site class
            frm_Site siteForm = new frm_Site();

            // Re-size the form
            siteForm.Height = 700;
            siteForm.Width = 1500;

            // Return the form object
            return siteForm;
        }

        private void AddColumns(frm_Site siteForm)
        {
            // Store reference to data grid view
            DataGridView dgv_Site = siteForm.dgv_Site;

            // Create a linked column for URL
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "Site URL";
            lnk.Name = "url";
            lnk.UseColumnTextForLinkValue = false;

            // Add columns
            dgv_Site.Columns.Add("siteNumber", "Number");
            dgv_Site.Columns.Add("title", "Title");
            dgv_Site.Columns.Add("parent", "Parent Site");
            dgv_Site.Columns.Add(lnk);
        }

        private void AddRow(DataGridView dgv_Site, params string[] list)
        {
            // Add a new row
            dgv_Site.Rows.Add();

            // Loop through array to get values
            for (int i = 0; i < list.Length; i++)
            {
                // Enter the value
                dgv_Site[i, dgv_Site.RowCount - 1].Value = list[i];
            }
        }

        private static ClientContext GetClient()
        {
            string errorMessage = "";

            // Get client
            ClientContext clientContext = SharePoint.GetClient(siteUrl, username, password, ref errorMessage);

            if (clientContext == null)
            {
                MessageBox.Show(errorMessage);
                return null;
            }

            return clientContext;
        }

        private void GetSiteAndSubSites(ClientContext clientContext, DataGridView dgv_Site, bool recursive)
        {
            // Get the SharePoint web  
            Web web = clientContext.Web;

            // Load objects
            clientContext.Load(web, website => website.Webs, website => website.Title, website => website.Url);

            // Execute the query to the server  
            clientContext.ExecuteQuery();

            // Add row to data grid view
            AddRow(dgv_Site, (dgv_Site.RowCount + 1).ToString(), web.Title, null, web.Url);

            // Loop through sub-sites
            GetSubSites(clientContext, web, dgv_Site, recursive);
        }

        private void GetSubSites(ClientContext clientContext, Web web, DataGridView dgv_Site, bool recursive)
        {
            // Load objects
            clientContext.Load(web, website => website.Webs, website => website.Title, website => website.Url);

            // Execute the query to the server  
            clientContext.ExecuteQuery();

            // Loop through all the webs  
            foreach (Web subWeb in web.Webs)
            {
                // Check whether it is an app URL or not - If not then get into this block  
                if (subWeb.Url.Contains(web.Url))
                {
                    // Add row to data grid view
                    AddRow(dgv_Site, (dgv_Site.RowCount + 1).ToString(), subWeb.Title, web.Title, subWeb.Url);

                    // Loop through sub-sites
                    if(recursive)
                    {
                        GetSubSites(clientContext, subWeb, dgv_Site, recursive);
                    }                    
                }
            }
        }
        
    }
}
