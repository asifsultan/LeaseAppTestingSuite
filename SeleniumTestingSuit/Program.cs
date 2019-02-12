using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;
using System.IO;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Support.UI;
using AutoItX3Lib;

namespace SeleniumTestingSuit
{
    class Program
    {
        // Browser web reference
        // IWebDriver driver = new ChromeDriver();
        Dictionary<int, string> testResult = new Dictionary<int, string>();
        Dictionary<int, string> errorMessage = new Dictionary<int, string>();
        static void Main(string[] args)
        {

        }
        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            testResult.Add(0, "Status");
            errorMessage.Add(0, "Reason of failure");


        }
        [Test]
        public void FillLeaseForm()
        {
            // var watch = System.Diagnostics.Stopwatch.StartNew();
          
            ExcelLibrary.PopulateInCollection(@"C:\Users\DevOps-05\Documents\shareData.xlsx");
            for (int i = 1; i <= ExcelLibrary.getTotalRow(@"C:\Users\DevOps-05\Documents\shareData.xlsx"); i++)
            {

                try
                {
                    String start_URL = PropertiesCollection.driver.Url.ToString();
                    Console.WriteLine("Running Test number : " + i);
                    PropertiesCollection.driver.Navigate().GoToUrl("http://192.168.1.25:8080/ls/signin.jsp?reload");
                    Console.WriteLine("Opened URL");


                    // login to application

                    String prev_URL = PropertiesCollection.driver.Url.ToString();

                    do
                    {
                        prev_URL = PropertiesCollection.driver.Url.ToString();
                        Thread.Sleep(2000);

                    } while (!prev_URL.ToString().Contains("signin.jsp"));
                    LoginPageObject pageLogin = new LoginPageObject();
                    // EAPageObject pageEA = pageLogin.Login(ExcelLibrary.ReadData(i, "UserName"), ExcelLibrary.ReadData(i, "Password"));
                    pageLogin.ClearFeilds("");
                    CreateAndUpload pageLeaseForm = pageLogin.Login(ExcelLibrary.ReadData(i, "UserName"),
                        ExcelLibrary.ReadData(i, "Password"));


                    prev_URL = PropertiesCollection.driver.Url.ToString();

                    do
                    {
                        prev_URL = PropertiesCollection.driver.Url.ToString();
                        Thread.Sleep(2000);

                    } while (!prev_URL.ToString().Contains("ls_landing_page"));


                    pageLeaseForm.FillLeaseForm(ExcelLibrary.ReadData(i, "Address"),
                        ExcelLibrary.ReadData(i, "Department"),
                        ExcelLibrary.ReadData(i, "DL Year"),
                        ExcelLibrary.ReadData(i, "Desired Date"),
                        ExcelLibrary.ReadData(i, "Location SqFt"),
                        ExcelLibrary.ReadData(i, "Location Type"),
                        ExcelLibrary.ReadData(i, "Phone"),
                        ExcelLibrary.ReadData(i, "Program"),
                        ExcelLibrary.ReadData(i, "FilePath"),
                        ExcelLibrary.ReadData(i, "FileFormat")
                        );
                    Console.WriteLine("Executed test number " + i + " successfully");
                    testResult.Add(i, "True");

                }


                catch (Exception ex)
                {
                    // Console.WriteLine("Executed test number " + i + " unsuccessfully");
                    Console.WriteLine("Test failed with following error: ");
                    Console.WriteLine(ex.Message);
                    //testResult.Add(i, "Fail");
                    //errorMessage.Add(i, ex.Message);

                }

                Console.WriteLine(" ");
                // watch.Stop();
                //Console.WriteLine($"Loop " + i + $" Execution Time: {watch.ElapsedMilliseconds} ms");
                //System.Diagnostics.Stopwatch.StartNew();
            }

                ReportGenerator.GenerateXLS(testResult, errorMessage, true);
                //PropertiesCollection.driver.Close();
            
        }

        [Test]
        public void SearchAndAquire()
        {

            // var watch = System.Diagnostics.Stopwatch.StartNew();
            ExcelLibrary.PopulateInCollection(@"C:\Users\DevOps-05\Documents\shareData.xlsx");
            //for (int i = 1; i <= ExcelLibrary.getTotalRow(@"C:\Users\DevOps-05\Documents\shareData.xlsx"); i++)
            //{

                try
                {
                String start_URL = PropertiesCollection.driver.Url.ToString();
                Console.WriteLine("Running search and aquire test : " + "1");
                PropertiesCollection.driver.Navigate().GoToUrl("http://192.168.1.25:8080/ls/signin.jsp?reload");
                Console.WriteLine("Opened URL");


                // login to application

                String prev_URL = PropertiesCollection.driver.Url.ToString();

                do
                {
                    prev_URL = PropertiesCollection.driver.Url.ToString();
                    Thread.Sleep(2000);

                } while (!prev_URL.ToString().Contains("signin.jsp"));
                LoginPageObject pageLogin = new LoginPageObject();
                // EAPageObject pageEA = pageLogin.Login(ExcelLibrary.ReadData(i, "UserName"), ExcelLibrary.ReadData(i, "Password"));
                pageLogin.ClearFeilds("");
                SearchAndAquire pageLeaseForm = pageLogin.LogIn(ExcelLibrary.ReadData(1, "UserName"),
                    ExcelLibrary.ReadData(1, "Password"));


                    prev_URL = PropertiesCollection.driver.Url.ToString();

                    do
                    {
                        prev_URL = PropertiesCollection.driver.Url.ToString();
                        Thread.Sleep(2000);

                    } while (!prev_URL.ToString().Contains("ls_landing_page"));

                    pageLeaseForm.searchAndAquire("432", "Approve"); 

                }


                catch (Exception ex)
                {
                    // Console.WriteLine("Executed test number " + i + " unsuccessfully");
                    Console.WriteLine("Test failed with following error: ");
                    Console.WriteLine(ex.Message);
                    //testResult.Add(i, "Fail");
                    //errorMessage.Add(i, ex.Message);

                }



            Console.WriteLine(" ");
            // watch.Stop();
            //Console.WriteLine($"Loop " + i + $" Execution Time: {watch.ElapsedMilliseconds} ms");
            //System.Diagnostics.Stopwatch.StartNew();
            //}

            //ReportGenerator.GenerateXLS(testResult, errorMessage, true);
            //PropertiesCollection.driver.Close();
        }
        [TearDown]
        public void CleanUp()
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            //PropertiesCollection.driver.Close();

            Console.WriteLine("Close the browser");
        }
    }
}
//    public class ReportGenerator
//    {
      

//        internal static void GenerateXLS(Dictionary<int, string> testResult, Dictionary<int, string> errorMessage, bool status)
//        {
//            var xlApp = new
//            Microsoft.Office.Interop.Excel.Application();
//            var xlWorkBook = xlApp.Workbooks.Add("shareData.xlsx");


//            var xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
//            foreach (var item in testResult)
//            {
//                xlWorkSheet.Cells[item.Key+1, 13] = item.Value.ToString();
                
//            }
//            foreach (var item in errorMessage)
//            {
//                xlWorkSheet.Cells[item.Key + 1, 14] = item.Value.ToString();

//            }

//            var fileName = DateTime.Now.ToString("MMMM dd yyyy HH mm") + ".xlsx";
//            xlWorkBook.SaveAs(fileName);

//            xlWorkBook.Close(true);
//        }
//    }
//}
