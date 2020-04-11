using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            col = dgv_Data.Columns[dgv_Data.Columns.Add("query", "Query")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(lnk)];
        }

        private void frm_Data_View_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns();
        }
    }
}
