using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HomesForSale.Pages
{
    class Filter
    {
        public Filter(IWebDriver driver)
        {
            _driver = driver;
        }
        IWebDriver _driver;
        private string bedroomsButtonsCss = ".MuiToggleButtonGroup-root[aria-label='Bedrooms']>button";
        private string bathroomsButtonsCss = ".MuiToggleButtonGroup-root[aria-label='Bathrooms']>button";
        private string minPriceInputCss = "input[name='minprice']";
        private string maxPriceInputCss = "input[name='maxprice']";
        private string filterButtonCss = "button.MuiButton-containedPrimary";
        private string resetButtonCss = "p button";

        public void SelectBedrooms(BedroomsCount count)
        {
            var bedroomsButtonsList = _driver.FindElements(By.CssSelector(bedroomsButtonsCss)).ToList();
            switch (count)
            {
                case BedroomsCount.one:
                     bedroomsButtonsList[0].Click();
                    break;
                case BedroomsCount.two:
                    bedroomsButtonsList[1].Click();
                    break;
                case BedroomsCount.three:
                    bedroomsButtonsList[2].Click();
                    break;
                case BedroomsCount.four:
                    bedroomsButtonsList[3].Click();
                    break;
                case BedroomsCount.five:
                    bedroomsButtonsList[4].Click();
                    break;
                case BedroomsCount.six:
                    bedroomsButtonsList[5].Click();
                    break;
                case BedroomsCount.all:
                    bedroomsButtonsList[6].Click();
                    break;
            }
        }

        public void SelectBathrooms(BathroomsCount count)
        {
            var bathroomsButtonsList = _driver.FindElements(By.CssSelector(bathroomsButtonsCss)).ToList();
            switch (count)
            {
                case BathroomsCount.one:
                    bathroomsButtonsList[0].Click();
                    break;
                case BathroomsCount.two:
                    bathroomsButtonsList[1].Click();
                    break;
                case BathroomsCount.three:
                    bathroomsButtonsList[2].Click();
                    break;
                case BathroomsCount.all:
                    bathroomsButtonsList[6].Click();
                    break;
            }
        }

        public string minPrice
        {
            get => _driver.FindElement(By.CssSelector(minPriceInputCss)).Text;
            set => _driver.FindElement(By.CssSelector(minPriceInputCss)).SendKeys(value);
        }

        public string maxPrice
        {
            get => _driver.FindElement(By.CssSelector(maxPriceInputCss)).Text;
            set => _driver.FindElement(By.CssSelector(maxPriceInputCss)).SendKeys(value);
        }

        public IWebElement resetButton => _driver.FindElement(By.CssSelector(resetButtonCss));        
        public IWebElement filterButton => _driver.FindElement(By.CssSelector(filterButtonCss));

        public void ApplyFilter()
        {
            filterButton.Click();
            Thread.Sleep(500);
        }

        
    }
    enum BedroomsCount { one, two, three, four, five, six, all }
    enum BathroomsCount { one, two, three, all }

}
