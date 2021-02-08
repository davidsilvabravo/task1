using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyStore.PageObject;
using MyStore.Utils;


namespace MyStore.Testcases
{
    [TestFixture]
    class Task1
    {
        protected IWebDriver Driver;


        [SetUp]
        public void BeforeTest()
        {
            //Abrir el navegador e ir a la url indicada
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://www.automationpractice.com/index.php");
        }


        [Test]
        public void NewAccountRegistration()
        {
            //Generar los datos más relevantes
            String randomEmail = DataGenerator.RandomEmail();
            String firstname = DataGenerator.RandomString(5);
            String lastname = DataGenerator.RandomString(5);

            //Estando en la página Index, dar click en el botón de SignIn (previa espera a que aparezca)
            IndexPage indexPage = new IndexPage(Driver);
            if (indexPage.WaitForSignInButton())
                indexPage.ClickSignInButton();

            //Estando en la página SignIn, completar el formulario de email y continuar
            SignInPage signInPage = new SignInPage(Driver);
            if (signInPage.WaitForCreateAccountElements())
                signInPage.CompleteEmailForm(randomEmail);

            //Estando en la página CreateAccount, completar el formulario de registro
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            if (createAccountPage.WaitForRegistrationForm())
                createAccountPage.CompleteRegistrationForm(firstname, lastname);

            //Estando en la página MyAccount, realizar las validaciones solicitadas
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            bool SignOutValidation = myAccountPage.WaitForSignOutBtn();
            bool UsernameValidation = myAccountPage.WaitForUsernameBtn(firstname, lastname);
            bool UrlValidation = myAccountPage.UrlContainsString("?controller=my-account");

            Assert.IsTrue(SignOutValidation && UsernameValidation && UrlValidation);
        }


        [TearDown]
        public void AfterTest()
        {
            if (Driver != null)
                Driver.Quit();
        }
    }
}
