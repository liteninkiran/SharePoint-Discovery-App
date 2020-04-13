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

            // Load lists
            clientContext.Load(oList);

            // Execute the query to the server  
            clientContext.ExecuteQuery();

            BindList(clientContext, oList);            
        }

        private void BindList(ClientContext clientContext, List oList)
        {
            // Load in the Fields
            clientContext.Load(oList.Fields);
            clientContext.ExecuteQuery();

            int i = 0;

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "rowNumber";
            col.HeaderText = "Row Number";
            col.ValueType = typeof(int);

            dgv_List.Columns.Add(col);

            foreach (SP.Field oField in oList.Fields)
            {
                if (oField.TypeAsString != "Computed")
                {
                    i++;

                    col = new DataGridViewTextBoxColumn();
                    col.Name = oField.InternalName;
                    col.HeaderText = oField.Title;

                    dgv_List.Columns.Add(col);

                    if(i <= 20)
                    {
                        dgv_List.Refresh();
                    }
                }
            }

            // Create a new Caml Query
            CamlQuery camlQuery = new CamlQuery();

            // Set the XML
            camlQuery.ViewXml = "<View><Query>{0}</Query></View>";

            // Define a collection to store the list items in
            ListItemCollection collListItem = oList.GetItems(camlQuery);

            // Load in the items
            clientContext.Load(collListItem);
            clientContext.ExecuteQuery();

            dgv_List.Refresh();

            i = 0;

            // Loop through each item in the collection
            foreach (ListItem oListItem in collListItem)
            {
                dgv_List.Rows.Add();
                dgv_List.Refresh();

                int j = 0;

                dgv_List[j, i].Value = i + 1;

                foreach (var x in oListItem.FieldValues)
                {
                    j++;

                    if (x.Value != null)
                    {
                        dgv_List[j, i].Value = x.Value.ToString();
                    }
                }               

                i++;

                if(i >= nud_Row_Limit.Value && nud_Row_Limit.Value != 0)
                {
                    break;
                }
            }
        }
    }
}
