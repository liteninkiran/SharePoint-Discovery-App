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
            ListCollection collList = SharePoint.GetLists(txt_Site.Text, txt_Username.Text, txt_Password.Text);

            // Add columns
            if(dgv_List.ColumnCount == 0)
            {
                DataGridViewColumn col = null;
                col = dgv_List.Columns[dgv_List.Columns.Add("listNumber", "Number")];
                col = dgv_List.Columns[dgv_List.Columns.Add("listName", "List Name")];
            }

            // Clear the grid
            dgv_List.Rows.Clear();

            // Initialise row counter
            int i = 0;

            foreach (SP.List oList in collList)
            {
                dgv_List.Rows.Add();

                dgv_List[0, i].Value = i + 1;
                dgv_List[1, i].Value = oList.Title;

                // Increment counter
                i++;
            }
        }

        private void cmd_Clear_Click(object sender, EventArgs e)
        {
            dgv_List.Rows.Clear();
        }
    }
}
