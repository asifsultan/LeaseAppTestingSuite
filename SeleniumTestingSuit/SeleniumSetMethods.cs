using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;

namespace SeleniumTestingSuit
{
    public static class SeleniumSetMethods
    {
        // Enter Test
        // Extended method for entering text in the control
        public static void EnterText(this IWebElement element,  string value)
        {
            element.SendKeys(value);         
        }
        public static void EnterDate(this IWebElement element, int value)
        {
            new SelectElement(element).SelectByIndex(value);
        }

        // click into a button, checkbox, option etc

        public static void Clicks(this IWebElement element)
        {
            element.Click();
     
        }

        // Selecting a drop down control

        public static void SelectDropDown(this  IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
            
        }

        //public static long RandomNumber() {
        //    Random rnd = new Random();
        //    long myRandomNo = rnd.Next(1000000000, 999999000);
        //    return myRandomNo;
        //}
        public static readonly Random _rdm = new Random();
        public static string PinGenerator(this IWebElement element, int digits)
        {
            if (digits <= 1) return "";

            var _min = (int)Math.Pow(10, digits - 1);
            var _max = (int)Math.Pow(10, digits) - 1;
            return _rdm.Next(_min, _max).ToString();
        }

        public static void UploadFile(this IWebElement element, string filePath)
        {
            element.Click();

            // element = PropertiesCollection.driver.FindElement(By.CssSelector("[id$=trigger-filebutton]"));

            // Sendkey

            // element.SendKeys(filePath);



            //AutoIT for file uploading
            Thread.Sleep(1000);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");

            autoIt.Send(filePath);
            Thread.Sleep(2000);
            autoIt.Send("{ENTER}");

        }

    }
}

