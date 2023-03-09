Feature: Functionality of stackoverflow

@BDD_UI
Scenario: Video field successfully loading on ForTeams page
	Given I go to  "For Teams" page
	When I click on "Watch Overview Video" button
	Then I should see that the video field displayed
