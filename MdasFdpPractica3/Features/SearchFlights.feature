Feature: Search Flights
	In order to find available flights
	As a client of https://vueling.com/es
	I want to be able to search flights
	
@mytag
Scenario: Initial Search
	Given I'm in main page
	When I try to find a flight
        | Origin    | Destination | Outbound  | Return | Passengers |
        | Barcelona | Madrid      | NEXT_WEEK |        | 2          |
	Then I get available flight