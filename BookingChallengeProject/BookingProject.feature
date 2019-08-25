Feature: BookingProject
	In order to book an hotel reservation
	As a traveller in my holidays
	I want to select hotels using the filters

Scenario: Book hotel using filter is completed successfully
	Given I am in the booking website
		And The booking page is opened
		And I enter the location of the hotel
		And I select the reservation dates
		And I select the reservation for 2 people
		And I select only 1 room in this reservation
	When The hotel search is completed
	And I select the recommended for you filter of Sauna
	Then I find in the list the hotel name Limerick Strand Hotel 
