using System;
using System.Diagnostics;
using Xunit;
using Xunit.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using System.Globalization;
using OpenQA.Selenium.Support.PageObjects;

namespace BookingChallengeProject
{
    [Binding]
    public class BookingProjectSteps
    {
        private const string Message = "month";
        private IWebDriver _driver;

        [Given(@"I am in the booking website")]
        public void GivenIAmInTheBookingWebsite()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://booking.com");
        }

        [Given(@"The booking page is successfully opened")]
        public void GivenTheBookingPageIsSuccessfullyOpened()
        {
            var expectedSearchFieldTip = "Search";
            IWebElement searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));
            var actualSearchFieldTip = searchButton.Text;
            Assert.Equal(expectedSearchFieldTip, actualSearchFieldTip);
        }

        [Given(@"I enter the location of the hotel")]
        public void GivenIEnterTheLocationOfTheHotel()
        {
            IWebElement searchArgument = _driver.FindElement(By.Id("ss"));
            searchArgument.SendKeys("Limerick County, Irlanda");
        }

        [Given(@"I select the reservation dates")]
        public void GivenISelectTheReservationDates()
        {
            DateTime todaysDatePlus3Months = DateTime.Now.Date.AddMonths(+3);
            string reservationMonth = todaysDatePlus3Months.ToString("MMMM");
            string reservationDay = todaysDatePlus3Months.Day.ToString();

            IWebElement checkInDate = _driver.FindElement(By.CssSelector(".sb-date-field.b-datepicker"));
            checkInDate.Click();

            System.Collections.Generic.IList<IWebElement> calendarMonths = _driver.FindElements(By.CssSelector(".bui-calendar__month"));
            foreach (IWebElement month in calendarMonths)
            {
                if (month.Text != reservationMonth)
                {
                    IWebElement calenderBoxNext = _driver.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next"));
                    calenderBoxNext.Click();
                    break;
                }
            }

            System.Collections.Generic.IList<IWebElement> calendarDays = _driver.FindElements(By.CssSelector(".bui-calendar__date"));
            foreach (IWebElement day in calendarDays)
            {
                if ( day.Text == reservationDay)
                {
                    day.Click();
                    break;
                }
            }
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
            IWebElement searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));
            searchButton.Click();

            IWebElement hotelList = _driver.FindElement(By.Id("hotellist_inner"));
            Assert.True(hotelList.Displayed, "Hotel search list is not completed");
        }

        [When(@"I select the recommended for you filter of Sauna")]
        public void WhenISelectTheRecommendedForYouFilterOfSauna()
        {
            IWebElement filterSauna = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'Sauna')]"));
            Assert.True(filterSauna.Displayed, "Filter Sauna doesn't display." + " Expected: Sauna" + ",  Actual:" + filterSauna.Text);

            filterSauna = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'Sauna')]"));
            filterSauna.Click();
        }

        [Then(@"I find in the list the hotel name Limerick Strand Hotel")]
        public void ThenIFindInTheListTheHotelNameLimerickStrandHotel()
        {
            IWebElement hotelName = _driver.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'Limerick Strand Hotel')]"));
            Assert.True(hotelName.Displayed, "Hotel Name doesn't display." + " Expected: Limerick Strand Hotel" + ",  Actual:" + hotelName.Text);
        }

        [Then(@"I close the booking website")]
        public void ThenICloseTheBookingWebsite()
        {
            _driver.Dispose();
        }


    }
}
