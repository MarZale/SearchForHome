using HomesForSale.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomesForSale
{
    public class TestsFilteredResult
    {
        IWebDriver _driver;
        //ILogger logger = new Logger();
        [SetUp]
        public void Setup()
        {
          _driver = new ChromeDriver(TestContext.CurrentContext.TestDirectory);
          _driver.Navigate().GoToUrl("https://d1ykeet4wi4s9r.cloudfront.net/");
        }

        [Test] //Verifies that only results matching search criteria are shown, 2+ bathrooms
        public void TwoBathroomsResult()
        {
            //
            HomesList homeList = new HomesList(_driver);
            var homes = homeList.GetHomes();
            var filter = homeList.OpenFilter();
            filter.SelectBathrooms(BathroomsCount.two);
            filter.ApplyFilter();
            var bathroomsFilteredTwo = homeList.GetHomes();
            foreach (var home in bathroomsFilteredTwo)
            {
                Assert.False(home.Text.Contains("Bathrooms: 1"), "Result for 2+ bathrooms does not match search criteria.");
            }
        }
        [Test] //Verifies that only results matching search criteria are shown, 3+ bathrooms
        public void ThreeBathroomsResult()
        {
            //
            HomesList homeList = new HomesList(_driver);
            var homes = homeList.GetHomes();
            var filter = homeList.OpenFilter();
            filter.SelectBathrooms(BathroomsCount.three);
            filter.ApplyFilter();
            var bathroomsFilteredThree = homeList.GetHomes();
            foreach (var home in bathroomsFilteredThree)
            {                
                Assert.True(home.Text.Contains("Bathrooms: 3"), "Result for 3+ bathrooms does not match search criteria.");
            }
        }

        [TearDown]
        public void TearDown()
        {
        _driver.Close();
        }        
    }
}