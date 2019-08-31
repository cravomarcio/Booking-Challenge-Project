using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using Xunit.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
      // create driver instance
      _driver = new ChromeDriver();
      // delete cookies
      _driver.Manage().Cookies.DeleteAllCookies();
      // open url
      _driver.Navigate().GoToUrl("http://booking.com");
    }

    [Given(@"The booking page is successfully opened")]
    public void GivenTheBookingPageIsSuccessfullyOpened()
    {
      // wait
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
      // verify the search button displays on the page verifying the name of the button
      var expectedSearchFieldTip = "Search";
      IWebElement searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));
      var actualSearchFieldTip = searchButton.Text;
      Assert.Equal(expectedSearchFieldTip, actualSearchFieldTip);
    }

    [Given(@"I enter the (.*) hotel")]
    public void GivenIEnterTheOfTheHotel(string hotel)
    {
      //type the location of the hotel
      IWebElement location = _driver.FindElement(By.Id("ss"));
      location.SendKeys(hotel);
    }

    [Given(@"I want to open checkin calendar")]
    public void GivenISelectTheReservationDates()
    {
      // wait
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
      // click on the check-in calendar
      IWebElement checkInDate = _driver.FindElement(By.CssSelector(".sb-date-field.b-datepicker"));
      checkInDate.Click();
    }

    [Given(@"I want to go to the next months")]
    public void GivenIWantToEnterTheReservationDate()
    {
      // get name of the monyh
      string reservationMonth = todaysDatePlus3Months.ToString("MMMM");

      // wait
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

      // get the calendar name in the header and do the loop to change the months 
      System.Collections.Generic.IList<IWebElement> calendarMonths = _driver.FindElements(By.CssSelector(".bui-calendar__month")).ToList();
      foreach (IWebElement item in calendarMonths)
      {
        if (!(item.Text.Contains(reservationMonth)))
        {
          IWebElement calenderBoxNext = _driver.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next"));
          calenderBoxNext.Click();
          break;
        }
      }
    }

    [Given(@"I want to select the day of my reservation")]
    public void GivenIWantToSelectTheDayOfMyReservation()
    {
      // set reservation day and date
      string reservationDay = todaysDatePlus3Months.Day.ToString();
      string reservationDate = todaysDatePlus3Months.Date.ToString("yyyy-MM-dd");
     // _driver.FindElement(By.XPath("//div[@class='bui-calendar__wrapper']/table/tbody/tr/td[contains(text(), '" + reservationDay + "')]")).Click();
      _driver.FindElement(By.XPath("//div[@class='bui-calendar__wrapper']/table/tbody/tr/td[contains(text(), '" + reservationDay + "')]")).SendKeys(Keys.Enter);
    }

    [When(@"I search the hotel with my reservation date")]
    public void WhenTheHotelSearchIsCompleted()
    {
      //IWebElement searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));
      //searchButton.Click();
    }

    [When(@"My search is completed")]
    public void WhenMySearchIsCompleted()
    {
      //_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

      //OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      //wait.Until(x => x.FindElement(By.Id("hotellist_inner")));

      //IWebElement hotelList = _driver.FindElement(By.Id("hotellist_inner"));
      //Assert.True(hotelList.Displayed, "Hotel search list is not completed");
    }

    [When(@"I select the recommended for you filter of (.*)")]
    public void WhenISelectTheRecommendedForYouFilterOf(string sauna)
    {
      //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

      //OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      //wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'" + sauna + "')]")));

      //IWebElement filterSauna = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'" + sauna + "')]"));
      //Assert.True(filterSauna.Displayed, "Filter Sauna doesn't display." + " Expected: " + sauna + ",  Actual: " + filterSauna.Text);

      //filterSauna = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'" + sauna + "')]"));
      //filterSauna.Click();
    }

    [Then(@"I find the hotel with the name (.*)")]
    public void ThenIFindInTheListTheHotelName(string hotel)
    {
      //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

      //OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      //wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]")));

      //IWebElement hotelName = _driver.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]"));
      //Assert.True(hotelName.Displayed, "Hotel Name doesn't display." + " Expected: " + hotel + ",  Actual: " + hotelName.Text);
    }

    [Then(@"I don't find the hotel I want with the name (.*)")]
    public void ThenIDonTFindInTheListTheHotelName(string hotel)
    {
      //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

      //OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      //wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]")));

      //IWebElement hotelName = _driver.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]"));

      //Assert.True(hotelName.Displayed, "Hotel Name doesn't display." + " Expected: " + hotel + ",  Actual: " + hotelName.Text);
    }

    [Then(@"I close the booking website")]
    public void ThenICloseTheBookingWebsite()
    {
      //_driver.Dispose();
    }


  }
}
