Feature: check the availablity of elements
check if the elements of UI are visible for user in https://stackoverflow.co

@elementIsVisible
Scenario: check if the "who We are" element is wisible
	Given I navigate to https://stackoverflow.co
	When I navigate to 'Careers' page
	Then I can see the 'who we are' section