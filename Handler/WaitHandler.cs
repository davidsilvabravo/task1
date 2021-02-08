using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MyStore.Handler
{
    class WaitHandler
    {
        //Método para esperar a que cargue un elemento
        //Lo intenta por 5s; si lo encuentra devuelve true, sino devuelve false
        public bool ElementAvailable(IWebDriver driver, By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(drv => drv.FindElement(locator));               
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
