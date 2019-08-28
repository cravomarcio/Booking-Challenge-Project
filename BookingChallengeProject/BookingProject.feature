Feature: BookingProject
	In order to book an hotel reservation
	As a traveller in my holidays
	I want to select hotels using the filters

Scenario: Book hotel using filter is completed successfully
	Given I am in the booking website
		And The booking page is successfully opened
		And I enter the Limerick County, Irlanda of the hotel
		And I select the reservation dates
	When The hotel search is completed
	And I select the recommended for you filter of Sauna
	Then I find in the list the hotel name Limerick County, Irlanda
	And I close the booking website

Scenario: Book hotel using filter is not completed successfully
	Given I am in the booking website
		And The booking page is successfully opened
		And I enter the Limerick County, Irlanda of the hotel
		And I select the reservation dates
	When The hotel search is completed
	And I select the recommended for you filter of Sauna
	Then I don't find in the list the hotel name George Limerick Hotel
	And I close the booking website
