using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApplication2
{
    class Class_excell

    {

        /// If the supplied excel File does not exist then Create it
        /// </summary>
        /// <param name="FileName"></param>
        /// 
        public string _path;
         
        public Class_excell(string path)
        {
            path = _path;
            _path = Class_Global.excellDatapath;

        }

        public void CreateExcelFile()
        {
            //create
            string FileName;
            FileName = _path;
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "Work";
            //headline
            worksheet.Cells[1, 1] = "FileName";
            worksheet.Cells[1, 2] = "FindString";
            worksheet.Cells[1, 3] = "ReplaceString";

            worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }

        /// <summary>
        /// open an excel file,then write the content to file
        /// </summary>
        /// <param name="FileName">file name</param>
        /// <param name="findString">first cloumn</param>
        /// <param name="replaceString">second cloumn</param>
        public void WriteToExcel( string filename, string findString, string replaceString)
        {
            //open
            string excelName;
            excelName = _path;
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];

            mysheet.Activate();
            //get activate sheet max row count

            int maxrow = mysheet.UsedRange.Rows.Count + 1;
            mysheet.Cells[maxrow, 1] = filename;
            mysheet.Cells[maxrow, 2] = findString;
            mysheet.Cells[maxrow, 3] = replaceString;
            mybook.Save();
            mybook.Close(false, Type.Missing, Type.Missing);
            mybook = null;
            //quit excel app
            app.Quit();
        }


    }
}

