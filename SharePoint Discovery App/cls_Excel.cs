using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SharePoint_Discovery_App
{
    class cls_Excel
    {
        public static void ExportDatagridview(DataGridView dataGridView)
        {
            Excel.Application xlExcel;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlExcel = new Excel.Application();
            xlWorkBook = xlExcel.Workbooks.Add();
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    xlWorkSheet.Cells[j + 1, i + 1].Value = "'" + dataGridView[i, j].Value;
                }
            }

            xlWorkSheet.Cells.Font.Name = "Calibri";
            xlWorkSheet.Cells.EntireColumn.AutoFit();

            xlExcel.Visible = true;
        }
    }
}
