Feature: BookingProject
	In order to book an hotel reservation
	As a traveller in my holidays
	I want to select hotels using the filters

Scenario: Find a hotel using a filter
	Given I am in the booking website
		And The booking page is successfully opened
		And I enter the Limerick County, Irlanda hotel
		And I want to open checkin calendar
		And I want to go to the next months
		And I want to select the day of my reservation
	When I search the hotel with my reservation date
	And My search is completed
	And I select the recommended for you filter of Sauna
	Then I find the hotel with the name Limerick County, Irlanda
	And I close the booking website

Scenario: Don't find a hotel using a filter
	Given I am in the booking website
		And The booking page is successfully opened
		And I enter the Limerick County, Irlanda of the hotel
		And I want to open checkin calendar
		And I want to go to the next months
		And I want to select the day of my reservation
	When I search the hotel with my reservation date
	And My search is completed
	And I select the recommended for you filter of Sauna
	Then I don't find the hotel I want with the name George Limerick Hotel
	And I close the booking website
