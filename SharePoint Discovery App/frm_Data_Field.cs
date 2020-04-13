using System;
using System.Windows.Forms;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data_Field : SharePoint_Discovery_App.frm_Data
    {
        public frm_Data_Field()
        {
            InitializeComponent();
        }

        public void AddColumns()
        {
            DataGridViewColumn col = null;

            DataGridViewCheckBoxColumn chkRequired = GetCheckColumn("required", "Required");
            DataGridViewCheckBoxColumn chkReadOnly = GetCheckColumn("readOnly", "Read Only");
            DataGridViewCheckBoxColumn chkUnique = GetCheckColumn("enforceUniqueValues", "Unique");
            DataGridViewCheckBoxColumn chkSealed = GetCheckColumn("sealed", "Sealed");

            // Add columns
            col = dgv_Data.Columns[dgv_Data.Columns.Add("rowNumber", "Number")]; col.ValueType = typeof(int);
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fieldName", "Name")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("fieldType", "Type")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("maxLength", "Length")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkUnique)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkRequired)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkReadOnly)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add(chkSealed)];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("defaultValue", "Default Value")];
            col = dgv_Data.Columns[dgv_Data.Columns.Add("formula", "Formula")];
        }

        private void frm_Data_Field_Load(object sender, EventArgs e)
        {
            // Re-size columns
            ResizeColumns("formula");
        }

        private DataGridViewCheckBoxColumn GetCheckColumn(string name, string header)
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.ValueType = typeof(bool);
            checkColumn.Name = name;
            checkColumn.HeaderText = header;

            return checkColumn;
        }
    }
}
