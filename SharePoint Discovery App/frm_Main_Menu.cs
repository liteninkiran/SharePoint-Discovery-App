using System;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

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

            tip_Recursive.SetToolTip(this.chk_Recursive, "Uncheck to search sub-sites 1 layer deep (quicker). Check to recursively search all sites (slower).");
            tip_Limit.SetToolTip(this.nud_Limit, "Limit the number of sub-sites retrieved (quicker). Set to zero to retreive all sub-sites (slower).");
        }

        private void cmd_Get_Sites_Click(object sender, EventArgs e)
        {
            // Set the public variables
            SetStaticVars();

            // Try to get the client
            ClientContext clientContext = GetClient();

            // Exit if we got an error
            if (clientContext == null){return;}

            // Open the Site form
            frm_Data_Site siteForm = OpenForm();

            // Output all the sites/sub-sites into the data grid view
            GetSiteAndSubSites(clientContext, siteForm, chk_Recursive.Checked);

            // Show the Site form
            siteForm.ShowDialog();
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

        public frm_Data_Site OpenForm()
        {
            // Create a new instance of the Site class
            frm_Data_Site siteForm = new frm_Data_Site();

            // Give a new header row
            siteForm.Text = "Sites";
            siteForm.lbl_Header.Text = "Sites && Sub-Sites";

            // Re-size the form
            siteForm.Height = 700;
            siteForm.Width = 1000;
            siteForm.WindowState = FormWindowState.Maximized;

            // Add columns to the data grid view
            siteForm.AddColumns();

            // Return the form object
            return siteForm;
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

        private void GetSiteAndSubSites(ClientContext clientContext, frm_Data_Site siteForm, bool recursive)
        {
            // Get the SharePoint web  
            Web web = clientContext.Web;

            // Load objects
            //clientContext.Load(web, website => website.Webs, website => website.Title, website => website.Url);

            // Load lists
            clientContext.Load(web.Lists);

            // Execute the query to the server  
            clientContext.ExecuteQuery();

            // Store the data grid view's row count
            int i = siteForm.dgv_Data.RowCount + 1;

            // Add row to data grid view
            siteForm.AddRow(i.ToString(), web.Title, null, web.Lists.Count.ToString(), web.Created, web.Url);

            // Loop through sub-sites
            GetSubSites(clientContext, web, siteForm, recursive, null);
        }

        private void GetSubSites(ClientContext clientContext, Web web, frm_Data_Site siteForm, bool recursive, string parent)
        {
            // Load objects
            clientContext.Load(web, website => website.Webs, website => website.Title, website => website.Url);

            // Load lists
            clientContext.Load(web.Lists);

            // Execute the query to the server  
            clientContext.ExecuteQuery();

            // Loop through all the webs  
            foreach (Web subWeb in web.Webs)
            {
                // Check whether it is an app URL or not - If not then get into this block  
                if (subWeb.Url.Contains(web.Url))
                {
                    // Store the data grid view's row count
                    int i = siteForm.dgv_Data.RowCount + 1;

                    // Check to see if we have exceeded the limit
                    if(siteForm.dgv_Data.RowCount >= nud_Limit.Value && nud_Limit.Value != 0)
                    {
                        return;
                    }

                    // Store full path of parent
                    string parentNew = null;

                    // If the incoming parent variable is null, we are at the top
                    if(parent != null)
                    {
                        // New parent is incoming parent with the (parent) web title
                        parentNew = parent + " --> " + web.Title;
                    }
                    else
                    {
                        // New parent is just the (parent) web title
                        parentNew = web.Title;
                    }

                    // Add row to data grid view
                    siteForm.AddRow(i.ToString(), subWeb.Title, parentNew, web.Lists.Count.ToString(), web.Created, subWeb.Url);

                    // Loop through sub-sites
                    if (recursive)
                    {
                        GetSubSites(clientContext, subWeb, siteForm, recursive, parentNew);
                    }
                }
            }
        }

        private void btn_Test_List_Click(object sender, EventArgs e)
        {
            SetStaticVars();
            frm_Test_List testForm = new frm_Test_List();
            testForm.Show();
        }
    }
}
