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

            dgv_Data.Columns.Add("listNumber", "Number");
            dgv_Data.Columns.Add("listName", "List Name");
            dgv_Data.Columns.Add("baseType", "Type");
            dgv_Data.Columns.Add("defaultView", "Default View");
            dgv_Data.Columns.Add("fieldCount", "Field Count");
            dgv_Data.Columns.Add("viewCount", "View Count");
            dgv_Data.Columns.Add("itemCount", "Item Count");
            dgv_Data.Columns.Add("listId", "GUID");
            dgv_Data.Columns.Add("description", "Description");
            dgv_Data.Columns.Add("created", "Created");
            dgv_Data.Columns.Add(lnk);
        }

    }
}
