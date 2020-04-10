using System;
using System.Windows.Forms;

namespace SharePoint_Discovery_App
{
    public partial class frm_List : Form
    {
        public frm_List()
        {
            InitializeComponent();
        }

        private void cmd_Get_Lists_Click(object sender, EventArgs e)
        {

        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_Excel_Click(object sender, EventArgs e)
        {
            // Update button caption as it will take a while
            cls_Form.ChangeButton(this.cmd_Excel, true, "Exporting data. Please wait...");

            // Export to Excel
            cls_Excel.ExportDatagridview(dgv_List);

            // Update button caption
            cls_Form.ChangeButton(this.cmd_Excel, false);
        }

        private void dgv_List_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Store column index of current cell
            int i = dgv_List.CurrentCell.ColumnIndex;

            // Check the column name
            if (dgv_List.Columns[i].Name == "url")
            {
                string url = dgv_List.CurrentCell.Value.ToString();

                System.Diagnostics.Process.Start(url);

            }
        }

        private void frm_List_Load(object sender, EventArgs e)
        {
            // Auto-size columns
            foreach (DataGridViewColumn col in dgv_List.Columns)
            {
                switch (col.Name)
                {
                    case "description":

                        break;

                    default:

                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; col.Width = col.Width + 10;
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                        break;
                }
            }
        }
    }
}
