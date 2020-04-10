using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmd_Get_Lists_Click(object sender, EventArgs e)
        {
            // Clear the grid
            dgv_List.Rows.Clear();

            string errorMessage = "";

            ClientContext clientContext = SharePoint.GetClient(txt_Site.Text, txt_Username.Text, txt_Password.Text, ref errorMessage);

            if (clientContext == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            ListCollection collList = SharePoint.GetLists(clientContext, ref errorMessage);

            if (collList == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }


            // Add columns
            if (dgv_List.ColumnCount == 0)
            {
                DataGridViewColumn col = null;

                col = dgv_List.Columns[dgv_List.Columns.Add("listNumber", "Number")];
                col = dgv_List.Columns[dgv_List.Columns.Add("listName", "List Name")];
                col = dgv_List.Columns[dgv_List.Columns.Add("defaultView", "Default View")];
                col = dgv_List.Columns[dgv_List.Columns.Add("fieldCount", "Field Count")];
                col = dgv_List.Columns[dgv_List.Columns.Add("viewCount", "View Count")];
                col = dgv_List.Columns[dgv_List.Columns.Add("itemCount", "Item Count")];
                col = dgv_List.Columns[dgv_List.Columns.Add("listId", "GUID")];
                col = dgv_List.Columns[dgv_List.Columns.Add("description", "Description")];
                col = dgv_List.Columns[dgv_List.Columns.Add("created", "Created")];
            }

            foreach (DataGridViewColumn col in dgv_List.Columns)
            {
                switch(col.Name)
                {
                    case "description":
                        break;
                    default:
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        break;
                }                
            }
            

            // Initialise row counter
            int i = 0;

            foreach (SP.List oList in collList)
            {
                string defaultViewTitle = "";
                string viewCount = "";
                string fieldCount = "";
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
                    }
                    catch (Exception ex)
                    {
                        defaultViewTitle = "";
                    }
                }

                dgv_List.Rows.Add();

                dgv_List[0, i].Value = i + 1;
                dgv_List[1, i].Value = oList.Title;
                dgv_List[2, i].Value = defaultViewTitle;
                dgv_List[3, i].Value = fieldCount;
                dgv_List[4, i].Value = viewCount;
                dgv_List[5, i].Value = itemCount;
                dgv_List[6, i].Value = oList.Id;
                dgv_List[7, i].Value = oList.Description;
                dgv_List[8, i].Value = oList.Created;

                // Increment counter
                i++;
            }
        }

        private void cmd_Clear_Click(object sender, EventArgs e)
        {
            dgv_List.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Site.Text = "https://my.sharepoint.com";
            txt_Username.Text = "user@domain.com";
            txt_Password.Text = "password";
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
