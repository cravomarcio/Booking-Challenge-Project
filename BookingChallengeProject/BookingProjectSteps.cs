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

    [Given(@"I am in the booking website")]
    public void GivenIAmInTheBookingWebsite()
    {
      _driver = new FirefoxDriver();
      _driver.Manage().Cookies.DeleteAllCookies();
      _driver.Navigate().GoToUrl("http://booking.com");
    }

    [Given(@"The booking page is successfully opened")]
    public void GivenTheBookingPageIsSuccessfullyOpened()
    {

      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

      var searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));

      Assert.NotNull(searchButton.Text);
    }

    [Given(@"I enter location (.*)")]
    public void GivenIEnterLocationLimerickCountyIrlanda(string hotel)
    {
      _driver.FindElement(By.Id("ss")).SendKeys(hotel);
    }

    [Given(@"I want to open checkin calendar")]
    public void GivenISelectTheReservationDates()
    {
      //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
      _driver.FindElement(By.CssSelector(".xp__dates-inner.xp__dates__checkin")).Click();
    }

    [Given(@"I want to go to the next months")]
    public void GivenIWantToEnterTheReservationDate()
    {

      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

      _driver.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next")).Click();
    }

    [Given(@"I want to select the day of my reservation")]
    public void GivenIWantToSelectTheDayOfMyReservation()
    {
      string reservationMonth = todaysDatePlus3Months.ToString("MMMM");
      string reservationDay = todaysDatePlus3Months.Day.ToString();
      string reservationDate = todaysDatePlus3Months.Date.ToString("yyyy-MM-dd");
     _driver.FindElement(By.XPath("//div[@class='bui-calendar__wrapper']/table/tbody/tr/td[contains(text(), '" + reservationDay + "')]")).Click();
    }

    [When(@"I search the hotel with my reservation date")]
    public void WhenTheHotelSearchIsCompleted()
    {
      _driver.FindElement(By.CssSelector(".sb-searchbox__button")).Click();
    }

    [When(@"My search is completed")]
    public void WhenMySearchIsCompleted()
    {
      _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

      var hotelList = _driver.FindElement(By.Id("hotellist_inner"));
      Assert.True(hotelList.Displayed, "Hotel search list is not completed");
    }

    [When(@"I select the recommended for you filter of (.*)")]
    public void WhenISelectTheRecommendedForYouFilterOf(string filter)
    {
     // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

      //var checkBoxFilter = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label ')][contains(text(),'" + filter + "')]"));

      //_driver.FindElement(By.XPath("//div[@class='bui-bui-checkbox__label filter_item css-checkbox']/span[contains(@class,'filter_label')][contains(text(),'" + filter + "')]")).Click();
    }

    [Then(@"I find the hotel with the name (.*)")]
    public void ThenIFindInTheListTheHotelName(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

      var hotelName = _driver.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]"));

      Assert.True(hotelName.Displayed, "Hotel Name doesn't display." + " Expected: " + hotel + ",  Actual: " + hotelName.Text);
    }

    [Then(@"I don't find the hotel I want with the name (.*)")]
    public void ThenIDonTFindInTheListTheHotelName(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

      var AllHotelsListResults = _driver.FindElement(By.CssSelector(".hotellist.sr_double_search ")).Text.ToString();

      Assert.Contains(hotel.Trim().ToLower(), AllHotelsListResults.Trim().ToLower());
    }

    [Then(@"I close the booking website")]
    public void ThenICloseTheBookingWebsite()
    {
      _driver.Dispose();
    }


  }
}
