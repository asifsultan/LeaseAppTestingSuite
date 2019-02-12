using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestingSuit
{
    class ReportGenerator
    {

        internal static void GenerateXLS(Dictionary<int, string> testResult, Dictionary<int, string> errorMessage, bool status)
        {
            var xlApp = new
            Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = xlApp.Workbooks.Add("shareData.xlsx");


            var xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
            foreach (var item in testResult)
            {
                xlWorkSheet.Cells[item.Key + 1, 13] = item.Value.ToString();

            }
            foreach (var item in errorMessage)
            {
                xlWorkSheet.Cells[item.Key + 1, 14] = item.Value.ToString();

            }

            var fileName = DateTime.Now.ToString("MMMM dd yyyy HH mm") + ".xlsx";
            xlWorkBook.SaveAs(fileName);

            xlWorkBook.Close(true);
        }
    }
}

