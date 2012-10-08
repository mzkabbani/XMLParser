using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace XmlParsersAndUi.Forms {

	static class FastExportingMethod
	{

		public static void ExportToExcel(DataSet dataSet, string outputPath)
		{
			// Create the Excel Application object
            ApplicationClass excelApp = new ApplicationClass();

			// Create a new Excel Workbook
			Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

			int sheetIndex = 0;

			// Copy each DataTable
			foreach (System.Data.DataTable dt in dataSet.Tables)
			{

				// Copy the DataTable to an object array
				object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

				// Copy the column names to the first row of the object array
				for (int col = 0; col < dt.Columns.Count; col++)
				{
					rawData[0, col] = dt.Columns[col].ColumnName;
				}

				// Copy the values to the object array
				for (int col = 0; col < dt.Columns.Count; col++)
				{
					for (int row = 0; row < dt.Rows.Count; row++)
					{
						rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
					}
				}

				// Calculate the final column letter
				string finalColLetter = string.Empty;
				string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				int colCharsetLen = colCharset.Length;

				if (dt.Columns.Count > colCharsetLen) {
					finalColLetter = colCharset.Substring(
						(dt.Columns.Count - 1) / colCharsetLen - 1, 1);
				}

				finalColLetter += colCharset.Substring(
						(dt.Columns.Count - 1) % colCharsetLen, 1);

				// Create a new Sheet
				Worksheet excelSheet = (Worksheet) excelWorkbook.Sheets.Add(
					excelWorkbook.Sheets.get_Item(++sheetIndex),
					Type.Missing, 1, XlSheetType.xlWorksheet);

				excelSheet.Name = dt.TableName;

				// Fast data export to Excel
				string excelRange = string.Format("A1:{0}{1}",
					finalColLetter, dt.Rows.Count + 1);

				excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

				// Mark the first row as BOLD
				((Range) excelSheet.Rows[1, Type.Missing]).Font.Bold = true;               
                
			}
            
			// Save and Close the Workbook
			excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
			excelWorkbook.Close(true, Type.Missing, Type.Missing);
			excelWorkbook = null;

			// Release the Application object
			excelApp.Quit();
			excelApp = null;

			// Collect the unreferenced objects
			GC.Collect();
			GC.WaitForPendingFinalizers();

		}

	}
}
