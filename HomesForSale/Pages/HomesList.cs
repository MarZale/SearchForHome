using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HomesForSale.Pages
{
    class HomesList
    {   
        public HomesList(IWebDriver driver)
        {
            _driver = driver;
        }
        private string homesListCss = "#root .MuiPaper-root";
        private string setFiltersButtonCss = "button.MuiButtonBase-root";
        IWebDriver _driver;
        
        public List<IWebElement> GetHomes()
        {
            Thread.Sleep(1000);
            return _driver.FindElements(By.CssSelector(homesListCss)).ToList();             
        }

        public Filter OpenFilter()
        {
            _driver.FindElement(By.CssSelector(setFiltersButtonCss)).Click();
            Thread.Sleep(500);
            return new Filter(_driver);
        }
    }
}
