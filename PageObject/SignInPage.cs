using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MyStore.Handler;


namespace MyStore.PageObject
{
    class SignInPage
    {
        //Driver
        protected IWebDriver Driver;


        //Localizadores
        protected By emailInput = By.Id("email_create");
        protected By createAccountBtn = By.Id("SubmitCreate");


        //Constructor
        public SignInPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("Login - My Store"))
                throw new Exception("You are not on SignIn Page");
        }


        //Llenar el mail
        public void TypeEmail(String email)
        {
            Driver.FindElement(emailInput).SendKeys(email);
        }


        //Clickear el botón "Create an account"
        public void ClickCreateAccountButton()
        {
            Driver.FindElement(createAccountBtn).Click();
        }


        //Llenar el mail y clickear en el botón "Create an account"
        public CreateAccountPage CompleteEmailForm(String email)
        {
            TypeEmail(email);
            ClickCreateAccountButton();
            return new CreateAccountPage(Driver);
        }


        //Esperar que aparezcan el mail input y el botón de Create Account
        public bool WaitForCreateAccountElements()
        {
            WaitHandler searcher = new WaitHandler();
            if (  searcher.ElementAvailable(Driver, emailInput) &  searcher.ElementAvailable(Driver, createAccountBtn) )
                return true;
            else
                return false;
        }
    }
}
