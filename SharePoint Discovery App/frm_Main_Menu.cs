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
        public static SecureString secPassword;

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
            // Update button caption as it will take a while to load all sites/sub-sites
            ChangeButton(true);

            // Set the public variables
            SetStaticVars();

            // Open the Site form
            frm_Site siteForm = OpenForm();

            // Add columns to the data grid view
            AddColumns(siteForm);

            // Output all the sites/sub-sites into the data grid view
            GetAllSubWebs(siteForm.dgv_Site, siteUrl, username, secPassword);

            // Show the Site form
            siteForm.Show();

            // Change the button caption back
            ChangeButton(false);
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetStaticVars()
        {
            siteUrl = txt_Site.Text;
            username = txt_Username.Text;
            password = txt_Password.Text;
            secPassword = SharePoint.securePassword(password);
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

            siteForm.Height = 700;
            siteForm.Width = 1500;

            return siteForm;
        }

        private void AddColumns(frm_Site siteForm)
        {
            DataGridView dgv_Site = siteForm.dgv_Site;
            DataGridViewColumn col = null;

            col = dgv_Site.Columns[dgv_Site.Columns.Add("siteNumber", "Number")];
            col = dgv_Site.Columns[dgv_Site.Columns.Add("title", "Title")];
            col = dgv_Site.Columns[dgv_Site.Columns.Add("url", "Site URL")];
            col = dgv_Site.Columns[dgv_Site.Columns.Add("parent", "Parent Site")];

            foreach (DataGridViewColumn c in siteForm.dgv_Site.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void GetAllSubWebs(DataGridView dgv_Site, string path, string userName, SecureString password)
        {
            // ClienContext - Get the context for the SharePoint Online Site               
            using (var clientContext = new ClientContext(path))
            {
                // SharePoint Online Credentials    
                clientContext.Credentials = new SharePointOnlineCredentials(userName, password);

                // Get the SharePoint web  
                Web web = clientContext.Web;
                clientContext.Load(web, website => website.Webs, website => website.Title);

                // Execute the query to the server  
                clientContext.ExecuteQuery();

                // Loop through all the webs  
                foreach (Web subWeb in web.Webs)
                {
                    // Check whether it is an app URL or not - If not then get into this block  
                    if (subWeb.Url.Contains(path))
                    {
                        string newpath = subWeb.Url;

                        dgv_Site.Rows.Add();

                        dgv_Site[0, dgv_Site.RowCount - 1].Value = dgv_Site.RowCount;
                        dgv_Site[1, dgv_Site.RowCount - 1].Value = subWeb.Title;
                        dgv_Site[2, dgv_Site.RowCount - 1].Value = subWeb.Url;
                        dgv_Site[3, dgv_Site.RowCount - 1].Value = web.Title;

                        GetAllSubWebs(dgv_Site, newpath, userName, password);
                    }
                }
            }
        }
    }
}
