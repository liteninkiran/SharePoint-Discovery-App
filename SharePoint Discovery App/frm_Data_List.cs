using System;
using System.Windows.Forms;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_List : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_List()
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

            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowNumber", "Number")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("listName", "List Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("description", "Description")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("baseType", "Type")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("defaultView", "Default View")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fieldCount", "Field Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("viewCount", "View Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("itemCount", "Item Count")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("listId", "GUID")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("created", "Created")]; col.ValueType = typeof(DateTime);
            col = dgv_Data.Columns[dgv_Data.Columns.Add(lnk)];
        }

        private void frm_Data_List_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns("description");
        }

        private void cmd_Get_Views_Click(object sender, EventArgs e)
        {

        }

        private void cmd_Get_Fields_Click(object sender, EventArgs e)
        {

        }
    }
}
