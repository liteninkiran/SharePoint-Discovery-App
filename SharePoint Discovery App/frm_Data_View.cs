using System;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_View : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_View()
        {
            InitializeComponent();
        }

        public void AddColumns()
        {
            // Create a linked column for URL
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.HeaderText = "Site URL";
            lnk.Name = "url";
            lnk.UseColumnTextForLinkValue = false;

            DataGridViewColumn col = null;

            // Add columns
            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowNumber", "Number")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("viewName", "Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fieldCount", "Field Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowLimit", "Row Limit")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("viewId", "GUID")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("query", "Query")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(lnk)];
        }

        private void frm_Data_View_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns("query");
        }

        private void cmd_Copy_Click(object sender, EventArgs e)
        {
            // Store selected row
            int row = dgv_Data.SelectedCells[0].RowIndex;

            // Store column of URL
            int col = dgv_Data.Columns["query"].Index;

            // Store query XML
            string camlQuery = dgv_Data[col, row].Value.ToString();

            // Try and tidy up
            camlQuery = camlQuery.Replace("<", "\r\n<").Trim();

            // Copy to clipboard
            Clipboard.SetText(camlQuery);

            // Inform user
            MessageBox.Show("Copied to clipboard:\r\n\r\n" + camlQuery);
        }
    }
}
