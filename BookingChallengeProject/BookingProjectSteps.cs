using System;
using System.Diagnostics;
using Xunit;
using Xunit.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
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
      _driver.Manage().Cookies.DeleteAllCookies();
      _driver.Navigate().GoToUrl("http://booking.com");
    }

    [Given(@"The booking page is successfully opened")]
    public void GivenTheBookingPageIsSuccessfullyOpened()
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.CssSelector(".sb-searchbox__button")));

      var expectedSearchFieldTip = "Search";
      IWebElement searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));

      var actualSearchFieldTip = searchButton.Text;
      Assert.Equal(expectedSearchFieldTip, actualSearchFieldTip);
    }

    [Given(@"I enter the (.*) of the hotel")]
    public void GivenIEnterTheOfTheHotel(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.Id("ss")));

      IWebElement searchArgument = _driver.FindElement(By.Id("ss"));
      searchArgument.SendKeys(hotel);
    }

    [Given(@"I select the reservation dates")]
    public void GivenISelectTheReservationDates()
    {
      DateTime todaysDatePlus3Months = DateTime.Now.Date.AddMonths(+3);
      string reservationMonth = todaysDatePlus3Months.ToString("MMMM");
      //string reservationDay = todaysDatePlus3Months.Day.ToString();
      string reservationDate = todaysDatePlus3Months.Date.ToString("yyyy-mm-dd");

      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.CssSelector(".sb-date-field.b-datepicker")));

      IWebElement checkInDate = _driver.FindElement(By.CssSelector(".sb-date-field.b-datepicker"));
      checkInDate.Click();

      System.Collections.Generic.IList<IWebElement> calendarMonths = _driver.FindElements(By.CssSelector(".bui-calendar__month"));
      foreach (IWebElement month in calendarMonths)
      {
        if (month.Text != reservationMonth)
        {
          _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

          wait.Until(x => x.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next")));
          IWebElement calenderBoxNext = _driver.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next"));

          calenderBoxNext.Click();
          break;
        }
      }

      IWebElement table = _driver.FindElement(By.CssSelector(".bui-calendar__dates"));
      System.Collections.Generic.IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

      foreach (IWebElement row in rows)
      {
        System.Collections.Generic.IList<IWebElement> cells = row.FindElements(By.TagName("td"));
        foreach (IWebElement cell in cells)
        {
          if (cell.Text.Equals(reservationDate))
          {
            cell.FindElement(By.CssSelector(".warning_content")).Click();
          }
        }
      }
    }

    [When(@"The hotel search is completed")]
    public void WhenTheHotelSearchIsCompleted()
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.CssSelector(".sb-searchbox__button")));

      IWebElement searchButton = _driver.FindElement(By.CssSelector(".sb-searchbox__button"));
      searchButton.Click();

      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

      wait.Until(x => x.FindElement(By.Id("hotellist_inner")));

      IWebElement hotelList = _driver.FindElement(By.Id("hotellist_inner"));
      Assert.True(hotelList.Displayed, "Hotel search list is not completed");
    }

    [When(@"I select the recommended for you filter of (.*)")]
    public void WhenISelectTheRecommendedForYouFilterOf(string sauna)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'" + sauna + "')]")));

      IWebElement filterSauna = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'" + sauna + "')]"));

      Assert.True(filterSauna.Displayed, "Filter Sauna doesn't display." + " Expected: " + sauna + ",  Actual: " + filterSauna.Text);
      filterSauna = _driver.FindElement(By.XPath("//span[contains(@class,'filter_label')][contains(text(),'" + sauna + "')]"));
      filterSauna.Click();
    }

    [Then(@"I find in the list the hotel name (.*)")]
    public void ThenIFindInTheListTheHotelName(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]")));


      IWebElement hotelName = _driver.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]"));
      Assert.True(hotelName.Displayed, "Hotel Name doesn't display." + " Expected: " + hotel + ",  Actual: " + hotelName.Text);
    }

    [Then(@"I don't find in the list the hotel name (.*)")]
    public void ThenIDonTFindInTheListTheHotelName(string hotel)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

      OpenQA.Selenium.Support.UI.WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
      wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]")));

      IWebElement hotelName = _driver.FindElement(By.XPath("//span[contains(@class,'sr-hotel__name')][contains(text(),'" + hotel + "')]"));
      Assert.True(hotelName.Displayed, "Hotel Name doesn't display." + " Expected: " + hotel + ",  Actual: " + hotelName.Text);
    }

    [Then(@"I close the booking website")]
    public void ThenICloseTheBookingWebsite()
    {
      _driver.Dispose();
    }


  }
}
