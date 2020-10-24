using HomesForSale.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomesForSale
{
    public class TestsFilteredResultNumber
    {
        IWebDriver _driver;
        //ILogger logger = new Logger();
        [SetUp]
        public void Setup()
        {
          _driver = new ChromeDriver(TestContext.CurrentContext.TestDirectory);
          _driver.Navigate().GoToUrl("https://d1ykeet4wi4s9r.cloudfront.net/");
        }

        [Test] //The aim is to compare number of results before any filtering and after All bedrooms filter is applied

        public void BedroomsFiltersResultsAll()
        {
            //_driver.Navigate().GoToUrl("https://d1ykeet4wi4s9r.cloudfront.net/");
            HomesList homeList = new HomesList(_driver);
            var homes = homeList.GetHomes();
            var filter = homeList.OpenFilter();
            filter.SelectBedrooms(BedroomsCount.all);
            filter.ApplyFilter();
            var bedroomsFilteredAll = homeList.GetHomes();
            Assert.AreEqual(homes.Count, bedroomsFilteredAll.Count, $"Incorrect filtering result for All bedrooms. " +
                $"Should be {homes.Count}, but was {bedroomsFilteredAll.Count}.");
        }

        [Test] //Verifies if the correct number of homes is shown for the search with 1+ bedrooms filter option
        public void BedroomsFiltersResultsOne()
        {
            //1+ option selected
            HomesList homeList = new HomesList(_driver);
            var homes = homeList.GetHomes();
            var filter = homeList.OpenFilter();
            filter.SelectBedrooms(BedroomsCount.one);
            filter.ApplyFilter();
            var bedroomsFilteredOne = homeList.GetHomes();
            Assert.AreEqual(homes.Count, bedroomsFilteredOne.Count, $"Incorrect filtering result for 1+ bedrooms. " +
                $"Should be {homes.Count}, but was {bedroomsFilteredOne.Count}.");
        }

        [Test] //Verifies if the correct number of homes is shown for the search with 6+ bedrooms filter option
        public void BedroomsFiltersResultsSix()
        {
            //1+ option selected
            HomesList homeList = new HomesList(_driver);
            var homes = homeList.GetHomes();
            var filter = homeList.OpenFilter();
            filter.SelectBedrooms(BedroomsCount.six);
            filter.ApplyFilter();
            var bedroomsFilteredSix = homeList.GetHomes();
            Assert.AreEqual(9, bedroomsFilteredSix.Count, $"Incorrect filtering result for 6+ bedrooms. " +
                $"Should be 9, but was {bedroomsFilteredSix.Count}.");
        }

        [TearDown]
        public void TearDown()
        {
        _driver.Close();
        }        
    }
}