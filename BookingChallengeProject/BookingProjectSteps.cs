using System;
using Xunit;
using Xunit.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using TechTalk.SpecFlow;

namespace BookingChallengeProject
{
    [Binding]
    public class BookingProjectSteps
    {
        private IWebDriver _driver;
        private string expectedSearchFieldTip;

        [Given(@"I am in the booking website")]
        public void GivenIAmInTheBookingWebsite()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://booking.com");
        }

        [Given(@"The booking page is successfully opened")]
        public void GivenTheBookingPageIsSuccessfullyOpened()
        {
            expectedSearchFieldTip = "Search";
            IWebElement searchFieldId = _driver.FindElement(By.Id("ss"));
            string actualSearchFieldTip = searchFieldId.GetProperty("placeholder");
            Assert.Equal(expectedSearchFieldTip, actualSearchFieldTip);
        }

        [Given(@"I enter the location of the hotel")]
        public void GivenIEnterTheLocationOfTheHotel()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I select the reservation dates")]
        public void GivenISelectTheReservationDates()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I select the reservation for (.*) people")]
        public void GivenISelectTheReservationForPeople(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I select only (.*) room in this reservation")]
        public void GivenISelectOnlyRoomInThisReservation(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"The hotel search is completed")]
        public void WhenTheHotelSearchIsCompleted()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"I select the recommended for you filter of Sauna")]
        public void WhenISelectTheRecommendedForYouFilterOfSauna()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I find in the list the hotel name Limerick Strand Hotel")]
        public void ThenIFindInTheListTheHotelNameLimerickStrandHotel()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I close the booking website")]
        public void ThenICloseTheBookingWebsite()
        {
            _driver.Dispose();
        }


    }
}
