using System;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    public partial class frm_Data : System.Windows.Forms.Form
    {
        public frm_Data()
        {
            InitializeComponent();
        }

        private void cmd_Excel_Click(object sender, EventArgs e)
        {
            cls_Excel.ExportDatagridview(dgv_Data);
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ResizeColumns(params string[] list)
        {
            // Auto-size columns
            foreach (DataGridViewColumn col in dgv_Data.Columns)
            {
                bool exclude = Array.Exists(list, s => s.Equals(col.Name));

                if(exclude == false)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; col.Width = col.Width + 10;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
            }
        }

        private void frm_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close forms that this form opened
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                // Check if the tag has been set
                if (Application.OpenForms[i].Tag != null)
                {
                    // Check the tag against this form's name
                    if (Application.OpenForms[i].Tag.ToString() == this.Name)
                    {
                        // Close the form
                        Application.OpenForms[i].Close();
                    }
                }
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Store column index of current cell
            int i = dgv_Data.CurrentCell.ColumnIndex;

            // Check the column name
            if (dgv_Data.Columns[i].Name == "url")
            {
                string url = dgv_Data.CurrentCell.Value.ToString();

                System.Diagnostics.Process.Start(url);
            }
        }

        public void AddRow(params object[] list)
        {
            // Store the row count
            int j = dgv_Data.RowCount;

            // Add a new row
            dgv_Data.Rows.Add();

            // Loop through array to get values
            for (int i = 0; i < list.Length; i++)
            {
                if(dgv_Data.Columns[i].ValueType == null)
                {
                    // We did not assign a value type. String is assumed.
                    dgv_Data[i, j].Value = list[i];
                }
                else
                {
                    // Store the value type
                    string valueType = dgv_Data.Columns[i].ValueType.ToString();

                    // Decide how to convert the string
                    switch (valueType)
                    {
                        case "System.Int32"   : dgv_Data[i, j].Value = Convert.ToInt32(list[i]);            break;
                        case "System.DateTime": dgv_Data[i, j].Value = Convert.ToDateTime(list[i]);         break;
                        default               : dgv_Data[i, j].Value = list[i]; MessageBox.Show(valueType); break;
                    }
                }
            }
        }
    }
}
