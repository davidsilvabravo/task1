using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MyStore.Handler;


namespace MyStore.PageObject
{
    class IndexPage
    {
        //Driver
        protected IWebDriver  Driver;


        //Localizadores
        protected By SignInBtn = By.LinkText("Sign in");


        //Constructor
        public IndexPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("My Store"))
                throw new Exception("You are not on Index Page");
        }


        //Clickear el botón de SignIn
        public void ClickSignInButton()
        {
            Driver.FindElement(SignInBtn).Click();
         }


        //Esperar a que el botón SignIn esté disponible
        public bool WaitForSignInButton()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, SignInBtn);
        }
    }
}
