using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MyStore.Handler;
using OpenQA.Selenium.Support.UI;
using MyStore.Utils;


namespace MyStore.PageObject
{
    class CreateAccountPage
    {
        //Driver
        protected IWebDriver Driver;


        //Localizadores
        protected By registrationForm = By.Id("account-creation_form");
        protected By registerAccountButton = By.Id("submitAccount");


        //Sección "YOUR PERSONAL INFORMATION"
        protected By mrRadioBtn = By.Id("id_gender1");
        protected By mrsRadioBtn = By.Id("id_gender2");
        protected By firstNameInput = By.Id("customer_firstname");
        protected By lastNameInput = By.Id("customer_lastname");
        protected By emailInput = By.Id("email");
        protected By passwordInput = By.Id("passwd");
        protected By daySelector = By.Id("days");
        protected By monthSelector = By.Id("months");
        protected By yearSelector = By.Id("years");
        protected By NewsletterCheckbox = By.Id("newsletter");
        protected By OffersCheckbox = By.Id("optin");


        //Sección "YOUR ADDRESS"
        protected By addrFirstnameInput = By.Id("firstname");
        protected By addrLastnameInput = By.Id("lastname");
        protected By addrCompanyInput = By.Id("company");
        protected By addrAddress1Input = By.Id("address1");
        protected By addrAddress2Input = By.Id("address2");
        protected By addrCityInput = By.Id("city");
        protected By addrStateSelector = By.Id("id_state");
        protected By addrPostalCodeInput = By.Id("postcode");
        protected By addrCountrySelector = By.Id("id_country");
        protected By addrAdditionalTextArea = By.Id("other");
        protected By addrHomePhoneInput = By.Id("phone");
        protected By addrMobilePhoneInput = By.Id("phone_mobile");
        protected By addrAliasInput = By.Id("alias");


        //Constructor
        public CreateAccountPage(IWebDriver driver)
        {
            Driver = driver;
            if ( !WaitForRegistrationForm() )
                throw new Exception("You are not on Create Account Page");
        }


        //Esperar a que aparezca el formulario de registro
        public bool WaitForRegistrationForm()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, registrationForm);
        }


        //Esperar a que aparezca el botón para registrar cuenta
        public bool WaitForRegisterButton()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, registerAccountButton);
        }


        //Esperar a que aparezca el campo Firstname
        public bool WaitForFirstNameInput()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, firstNameInput);
        }


        //Esperar a que aparezca el campo Lastname
        public bool WaitForLastNameInput()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, lastNameInput);
        }


        //Esperar a que aparezca el campo Alias
        public bool WaitForAliasInput()
        {
            WaitHandler searcher = new WaitHandler();
            return searcher.ElementAvailable(Driver, addrAliasInput);
        }


        //Completar el formulario de registro de nueva cuenta
        public void CompleteRegistrationForm(String firstname, String lastname)
        {
            //Sección "YOUR PERSONAL INFORMATION"
            if ( DataGenerator.RandomNumber(0,1) == "0")
                Driver.FindElement(mrRadioBtn).Click();
            else
                Driver.FindElement(mrsRadioBtn).Click();

            WaitForFirstNameInput();
            Driver.FindElement(firstNameInput).Clear();
            Driver.FindElement(firstNameInput).SendKeys(firstname);

            WaitForLastNameInput();
            Driver.FindElement(lastNameInput).Clear();
            Driver.FindElement(lastNameInput).SendKeys(lastname);

            Driver.FindElement(passwordInput).SendKeys("P4SSw0rd!!");

            var select = Driver.FindElement(daySelector);
            new SelectElement(select).SelectByValue(DataGenerator.RandomNumber(1,31));

            select = Driver.FindElement(monthSelector);
            new SelectElement(select).SelectByValue(DataGenerator.RandomNumber(1, 12));

            select = Driver.FindElement(yearSelector);
            new SelectElement(select).SelectByValue(DataGenerator.RandomNumber(1900, 2021));

            Driver.FindElement(NewsletterCheckbox).Click();

            Driver.FindElement(OffersCheckbox).Click();



            //Sección "YOUR ADDRESS"
            Driver.FindElement(addrCompanyInput).SendKeys(DataGenerator.RandomString(5));

            Driver.FindElement(addrAddress1Input).SendKeys(DataGenerator.RandomString(10));

            Driver.FindElement(addrAddress2Input).SendKeys(DataGenerator.RandomString(10));

            Driver.FindElement(addrCityInput).SendKeys(DataGenerator.RandomString(5));

            select = Driver.FindElement(addrStateSelector);
            new SelectElement(select).SelectByValue(DataGenerator.RandomNumber(1, 53));

            Driver.FindElement(addrPostalCodeInput).SendKeys(DataGenerator.RandomZipCode());

            select = Driver.FindElement(addrCountrySelector);
            new SelectElement(select).SelectByValue(DataGenerator.RandomNumber(21, 21)); // solo hay Estados Unidos

            Driver.FindElement(addrAdditionalTextArea).SendKeys(DataGenerator.RandomString(10));

            Driver.FindElement(addrHomePhoneInput).SendKeys(DataGenerator.RandomHome());

            Driver.FindElement(addrMobilePhoneInput).SendKeys(DataGenerator.RandomMobile());

            WaitForAliasInput();
            Driver.FindElement(addrAliasInput).Clear();
            Driver.FindElement(addrAliasInput).SendKeys(DataGenerator.RandomString(10));

            Driver.FindElement(registerAccountButton).Click();
        }
    }
}
