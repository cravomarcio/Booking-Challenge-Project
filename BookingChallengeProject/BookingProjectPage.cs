using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingChallengeProject
{
  public class LoadBookingPage
  {
    private readonly IWebDriver _driver;
    private const string PageUri = @"http://booking.com";

    public LoadBookingPage(IWebDriver driver)
    {
      _driver = driver;
    }

    public static LoadBookingPage NavigateTo(IWebDriver driver)
    {
      driver.Navigate().GoToUrl(PageUri);
      return new LoadBookingPage(driver);
    }

    public string EnterHotelLocationLocation
    {
      set
      {
        _driver.FindElement(By.Id("ss")).SendKeys(value);
      }
    }

    public void SelectCalendar()
    {
      _driver.FindElement(By.CssSelector(".xp__dates-inner.xp__dates__checkin")).Click();
    }

    public void SelectNextMonthsInCalendar()
    {
      _driver.FindElement(By.CssSelector(".bui-calendar__control.bui-calendar__control--next")).Click();
    }

    public void SelectDayInCalendar(string reservationDay)
    {
      _driver.FindElement(By.XPath("//div[@class='bui-calendar__wrapper']/table/tbody/tr/td[contains(text()," + reservationDay + ")]")).Click();
    }

    public void SelectFilter(string filter)
    {
        _driver.FindElement(By.XPath("//span[contains(@class,'filter_label ')][contains(text()," + filter + ")]")).Click();
    }

    public bool HotelResultsDisplayed =>
      _driver.FindElement(By.Id("search_results_table")).Displayed.Equals(true);

    public BookingConfirmationPage SearchApplication()
    {
      _driver.FindElement(By.CssSelector(".sb-searchbox__button")).Click();

      return new BookingConfirmationPage(_driver);
    }

  }
}
