using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MyStore.Handler;


namespace MyStore.PageObject
{
    class MyAccountPage
    {
        //Driver
        protected IWebDriver Driver;


        //Localizadores
        protected By SignOutBtn = By.LinkText("Sign out");


        //Constructor
        public MyAccountPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("My account - My Store"))
                throw new Exception("You are not on SignOut Page");
        }


        //Esperar que aparezcan el botón SignIn
        public bool WaitForSignOutBtn()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, SignOutBtn);
        }


        //Esperar que aparezcan el campo Username
        public bool WaitForUsernameBtn(String firstname, String lastname)
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, By.LinkText(firstname + " "+ lastname));
        }


        //Consultar si la url contiene un string
        public bool UrlContainsString(String value)
        {
            if ( Driver.Url.Contains(value) )
               return true;
            else
                return false;
        }
    }
}
