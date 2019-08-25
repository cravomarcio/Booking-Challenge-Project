using System;
using TechTalk.SpecFlow;

namespace BookingChallengeProject
{
    [Binding]
    public class BookingProjectSteps
    {
        [Given(@"I am in the booking website")]
        public void GivenIAmInTheBookingWebsite()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The booking page is opened")]
        public void GivenTheBookingPageIsOpened()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter the location of the hotel")]
        public void GivenIEnterTheLocationOfTheHotel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select the reservation dates")]
        public void GivenISelectTheReservationDates()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select the reservation for (.*) people")]
        public void GivenISelectTheReservationForPeople(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select only (.*) room in this reservation")]
        public void GivenISelectOnlyRoomInThisReservation(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The hotel search is completed")]
        public void WhenTheHotelSearchIsCompleted()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select the recommended for you filter of Sauna")]
        public void WhenISelectTheRecommendedForYouFilterOfSauna()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I find in the list the hotel name Limerick Strand Hotel")]
        public void ThenIFindInTheListTheHotelNameLimerickStrandHotel()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
