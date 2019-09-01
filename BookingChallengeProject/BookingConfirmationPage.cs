using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingChallengeProject
{
  public class BookingConfirmationPage
  {
    private readonly IWebDriver _driver;

    public BookingConfirmationPage(IWebDriver driver)
    {
      _driver = driver;
    }

    public string HotelResults =>
      _driver.FindElement(By.Id("hotellist_inner")).Text.ToString();
  }
}
