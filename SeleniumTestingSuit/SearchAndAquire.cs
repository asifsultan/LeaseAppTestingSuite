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
    class SearchAndAquire
    {
        public SearchAndAquire()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.Id, Using = "xcp_button-1049-btnInnerEl")]
        public IWebElement BtnActiveLeases { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1083-inputEl")]
        public IWebElement SearchByAddress { get; set; }

        
       [FindsBy(How = How.Id, Using = "xcp_button-1089-btnInnerEl")]
        public IWebElement BtnSearch { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'javascript:void(0)')]")] 
        public IWebElement LeaseID { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_button-1120-btnInnerEl")]
        public IWebElement BtnAquire { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_text_input-1219-inputEl")]
        public IWebElement CommentArea { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_button-1685-btnInnerEl")]
        public IWebElement BtnApprove { get; set; }

        [FindsBy(How = How.Id, Using = "xcp_button-1687-btnInnerEl")]
        public IWebElement BtnReject { get; set; }


        public void searchAndAquire(string address, string comment)
    {

            String start_URL = PropertiesCollection.driver.Url.ToString();

            BtnActiveLeases.Clicks();

            String prev_URL = PropertiesCollection.driver.Url.ToString();

            do
            {
                prev_URL = PropertiesCollection.driver.Url.ToString();
                Thread.Sleep(2000);

            } while (!prev_URL.ToString().Contains("ls_view_lease_folders"));
            Thread.Sleep(2000);
            SearchByAddress.EnterText(address);
            BtnSearch.Clicks();
            Thread.Sleep(6000);
            LeaseID.Clicks();

            Thread.Sleep(3000);

            BtnAquire.Clicks();
            if(comment.ToLower() == "approve")
            { 
                 CommentArea.EnterText(comment);
                BtnApprove.Clicks();
            }
            else
            {
                CommentArea.EnterText(comment);
                BtnReject.Clicks();
            }
        }

    }

}