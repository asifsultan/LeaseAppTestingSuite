using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestingSuit
{
    class CreateAndUpload
    {
        public CreateAndUpload()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "xcp_button-1045")]
        public IWebElement BtnCreate { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1089-inputEl")]
        public IWebElement TxtAddress { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1090-inputEl")]
        public IWebElement TxtDepartment { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1091-inputEl")]
        public IWebElement TxtDLYear { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id$=datefield-1093-inputEl]")]
        public IWebElement DateDesired { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1096-inputEl")]
        public IWebElement TxtLSqFt  { get; set; }


        [FindsBy(How = How.Id, Using = "xcp_dropdown_list-1097-inputEl")]
        public IWebElement DdlLType { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_number_input-1098-inputEl")]
        public IWebElement TxtPhone { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1099-inputEl")]
        public IWebElement TxtProgram { get; set; }
        

        [FindsBy(How = How.Id, Using = "button-1118-btnInnerEl")]
        public IWebElement UploadFile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id$=trigger-filebutton]")]
        public IWebElement AddBtn { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_dropdown_list-1179-inputEl")]
        public IWebElement Format { get; set; }
        

        [FindsBy(How = How.Id, Using = "button-1130-btnInnerEl")]
        public IWebElement Finish { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_button-1121-btnInnerEl")]
        public IWebElement BtnSave { get; set; }

       

        public void FillLeaseForm(string address, string deperatment, 
            string desiredLYear, string desiredDate, string locationSqF,
            string locationType, string phone, string program, string filePath,
            string fileFormat)
        {
            String start_URL = PropertiesCollection.driver.Url.ToString();
            

            BtnCreate.Clicks();

            String prev_URL = PropertiesCollection.driver.Url.ToString();

            do
            {
                prev_URL = PropertiesCollection.driver.Url.ToString();
                Thread.Sleep(2000);

            } while (!prev_URL.ToString().Contains("ls_create_lease_initiate"));
            Thread.Sleep(2000);
            TxtAddress.EnterText(address);
            TxtDepartment.EnterText(deperatment);
            TxtDLYear.EnterText(desiredLYear);
            DateDesired.EnterText(desiredDate);
            TxtLSqFt.EnterText(locationSqF);
            DdlLType.EnterText(locationType);
            TxtPhone.EnterText(PinGenerator(10));
            TxtProgram.EnterText(program);
            UploadFile.Clicks();
            Thread.Sleep(3000);
            AddBtn.UploadFile(filePath);
            Thread.Sleep(5000);
            Format.EnterText(fileFormat);
            Thread.Sleep(3000);
            Finish.Clicks();
            Thread.Sleep(3000);
            BtnSave.Clicks();
            Thread.Sleep(5000);

        }
        public static readonly Random _rdm = new Random();
        public string PinGenerator(int digits)
        {
            if (digits <= 1) return "";

            var _min = (int)Math.Pow(10, digits - 1);
            var _max = (int)Math.Pow(10, digits) - 1;
            return _rdm.Next(_min, _max).ToString();
        }
    }

    
}
