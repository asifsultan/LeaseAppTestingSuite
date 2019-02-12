using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestingSuit
{
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "j_username")]
        public IWebElement TxtUserName { get; set; }

        //private RemoteWebDriver _driver;

        //IWebElement TxtUserName => _driver.FindElementById("j_username");
        //IWebElement TxtPassowrd => _driver.FindElementById("j_password-inputEl");
        //IWebElement BtnLogin => _driver.FindElementById("signin-btn-btnInnerEl");

        [FindsBy(How = How.Id, Using = "j_password-inputEl")]
        public IWebElement TxtPassowrd { get; set; }

        [FindsBy(How = How.Id, Using = "signin-btn-btnInnerEl")]
        public IWebElement BtnLogin { get; set; }

        public void ClearFeilds(string userName)
        {
            TxtUserName.EnterText(userName);
        }

        public CreateAndUpload Login(string userName, string password)
        {
            // var element = PropertiesCollection.driver.FindElement(By.Name("Login")); // works for your case.

                TxtUserName.EnterText(userName);
                TxtPassowrd.EnterText(password);
                BtnLogin.Clicks();


            
                return new CreateAndUpload();

        }


        public SearchAndAquire LogIn(string userName, string password)
        {
            // var element = PropertiesCollection.driver.FindElement(By.Name("Login")); // works for your case.

            TxtUserName.EnterText(userName);
            TxtPassowrd.EnterText(password);
            BtnLogin.Clicks();



            return new SearchAndAquire();

        }

    }
}
