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
    }
}
