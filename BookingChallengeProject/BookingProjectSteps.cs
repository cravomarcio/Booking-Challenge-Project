using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using Xunit.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace BookingChallengeProject
{
  [Binding]
  public class BookingProjectSteps
  {
    private const string Message = "month";
    private DateTime todaysDatePlus3Months = DateTime.Now.Date.AddMonths(+3);
    private IWebDriver _driver;
    private LoadBookingPage _loadBookingPage;
    private BookingConfirmationPage _bookingConfirmation;

    [Given(@"I am in the booking website")]
    public void GivenIAmInTheBookingWebsite()
    {
      _driver = new FirefoxDriver();
      _driver.Manage().Cookies.DeleteAllCookies();

      //_driver.Navigate().GoToUrl("http://booking.com");
      _loadBookingPage = LoadBookingPage.NavigateTo(_driver);
    }

    [Given(@"The booking page is successfully opened")]
    public void GivenTheBookingPageIsSuccessfullyOpened()
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //_driver.FindElement(By.CssSelector(".sb-searchbox__button")).Displayed.Equals(true);
      Assert.True(_loadBookingPage.HotelResultsDisplayed);
    }

    [Given(@"I enter location (.*)")]
    public void GivenIEnterLocationLimerickCountyIrlanda(string location)
    {
      // _driver.FindElement(By.Id("ss")).SendKeys(location);
      _loadBookingPage.EnterHotelLocationLocation = location;
    }

    [Given(@"I want to open checkin calendar")]
    public void GivenISelectTheReservationDates()
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //_driver.FindElement(By.CssSelector(".xp__dates-inner.xp__dates__checkin")).Click();
      _loadBookingPage.SelectCalendar();
    }

    [Given(@"I want to go to the next months")]
    public void GivenIWantToEnterTheReservationDate()
    {

      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //_driver.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next")).Click();
      _loadBookingPage.SelectNextMonthsInCalendar();
    }

    [Given(@"I want to select the day of my reservation")]
    public void GivenIWantToSelectTheDayOfMyReservation()
    {
      string reservationMonth = todaysDatePlus3Months.ToString("MMMM");
      string reservationDay = todaysDatePlus3Months.Day.ToString();
      string reservationDate = todaysDatePlus3Months.Date.ToString("yyyy-MM-dd");

      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //_driver.FindElement(By.XPath("//div[@class='bui-calendar__wrapper']/table/tbody/tr/td[contains(text(), '" + reservationDay + "')]")).Click();
      _loadBookingPage.SelectDayInCalendar(reservationDay);
    }

    [When(@"I search the hotel with my reservation date")]
    public void WhenTheHotelSearchIsCompleted()
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //_driver.FindElement(By.CssSelector(".sb-searchbox__button")).Click();
      _bookingConfirmation = _loadBookingPage.SearchApplication();
    }

    [When(@"I select the recommended for you filter of (.*)")]
    public void WhenISelectTheRecommendedForYouFilterOf(string filter)
    {
      //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //_driver.FindElement(By.XPath("//span[contains(@class,'filter_label ')][contains(text(),'" + filter + "')]")).Click();
      //_loadBookingPage.SelectFilter(filter);
    }

    [When(@"My search is completed")]
    public void WhenMySearchIsCompleted()
    {
      _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);
      //Boolean hotelResultsDisplays = _driver.FindElement(By.Id("search_results_table")).Displayed.Equals(true);
      //Assert.True(_loadBookingPage., "Hotel search list is not completed");
      Assert.True(_loadBookingPage.HotelResultsDisplayed);
    }

    [Then(@"I find the hotel with the name (.*)")]
    public void ThenIFindInTheListTheHotelName(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //string AllHotelsListResults = _driver.FindElement(By.CssSelector(".search_results_table")).Text.ToString();
      //Assert.Contains(hotel.Trim().ToLower(), AllHotelsListResults.Trim().ToLower());
      Assert.Contains(hotel.Trim().ToLower(), _bookingConfirmation.HotelResults.Trim().ToLower());
    }

    [Then(@"I don't find the hotel I want with the name (.*)")]
    public void ThenIDonTFindInTheListTheHotelName(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
      //string AllHotelsListResults = _driver.FindElement(By.CssSelector(".search_results_table")).Text.ToString();
      //Assert.DoesNotContain(hotel.Trim().ToLower(), AllHotelsListResults.Trim().ToLower());
      Assert.DoesNotContain(hotel.Trim().ToLower(), _bookingConfirmation.HotelResults.Trim().ToLower());
    }

    [Then(@"I close the booking website")]
    public void ThenICloseTheBookingWebsite()
    {
      _driver.Dispose();
    }
  }
}
