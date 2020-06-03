using System;
using System.Windows.Forms;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_User : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_User()
        {
            InitializeComponent();
        }

        public void AddColumns()
        {
            DataGridViewColumn col = null;

            DataGridViewCheckBoxColumn chkSiteAdmin = GetCheckColumn("siteAdmin", "Site Admin");
            DataGridViewCheckBoxColumn chkDeleted = GetCheckColumn("deleted", "Deleted");
            DataGridViewCheckBoxColumn chkHidden = GetCheckColumn("hidden", "Hidden");
            DataGridViewCheckBoxColumn chkActive = GetCheckColumn("isActive", "Active");

            // Add columns
            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowNumber", "Number")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("id", "ID")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("firstName", "First Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("lastName", "Last Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fullName", "Full Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("userName", "User Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("workEmail", "Work Email")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("sipAddress", "SIP Address")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkSiteAdmin)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkDeleted)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkHidden)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkActive)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("contentType", "Content Type")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("guid", "GUID")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("createDate", "Create Date")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("createUser", "Created By")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("modifiedDate", "Modified Date")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("modifiedUser", "Modified By")];
        }

        private DataGridViewCheckBoxColumn GetCheckColumn(string name, string header)
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.ValueType = typeof(bool);
            checkColumn.Name = name;
            checkColumn.HeaderText = header;

            return checkColumn;
        }

        private void frm_Data_User_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns();
        }
    }
}
