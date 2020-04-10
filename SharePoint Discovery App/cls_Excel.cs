using System;
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
            Excel.Range xlRange;

            // Create Excel application
            xlExcel = new Excel.Application();

            // Show Excel
            //xlExcel.Visible = true;

            // Add a new workbook
            xlWorkBook = xlExcel.Workbooks.Add();

            // Use sheet 1
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Change font
            xlWorkSheet.Cells.Font.Name = "Calibri";

            // Make header row pretty
            xlWorkSheet.Rows[1].Font.Bold = true;
            xlWorkSheet.Rows[1].HorizontalAlignment = Excel.Constants.xlCenter;
            xlWorkSheet.Rows[1].VerticalAlignment = Excel.Constants.xlCenter;

            // Enter column headers
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                xlWorkSheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
            }

            // Split first row and freeze
            xlExcel.ActiveWindow.SplitRow = 1;
            xlExcel.ActiveWindow.FreezePanes = true;

            // Loop through the data grid view columns
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                // Loop through the data grid view rows
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if(dataGridView[i, j].Value != null && dataGridView[i, j].Value.ToString() != "")
                    {
                        try
                        {
                            // Enter cell value
                            xlWorkSheet.Cells[j + 2, i + 1].Value = dataGridView[i, j].Value;
                        }
                        catch (Exception ex)
                        {
                            // Enter cell value as text
                            xlWorkSheet.Cells[j + 2, i + 1].Value = "'" + dataGridView[i, j].Value;
                        }
                    }                    
                }
            }

            // Get current region
            xlRange = xlWorkSheet.Cells[1, 1].CurrentRegion;

            // Auto-size the columns
            xlWorkSheet.Cells.EntireColumn.AutoFit();

            foreach(Excel.Range xlCell in xlRange.Rows[1].Cells)
            {
                if(xlCell.ColumnWidth >= 50)
                {
                    xlCell.ColumnWidth = 50;
                }
            }

            // Show Excel
            xlExcel.Visible = true;
        }
    }
}
