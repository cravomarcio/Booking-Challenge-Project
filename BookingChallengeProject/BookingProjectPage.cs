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
    public string Location
    {
      set
      {
        _driver.FindElement(By.Id("ss")).SendKeys(value);
      }
    }

    public string Filter
    {
      set
      {
        _driver.FindElement(By.CssSelector(".sb-date-field.b-datepicker")).SendKeys(value);
      }
    }

  }
}
