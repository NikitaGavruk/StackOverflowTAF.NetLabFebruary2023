Feature: Functionality of Stackoverflow


@tag1
Scenario: Look at video field
	Given I am on StackOverFlow page
	When I submit For Teams button
	And I submit Watch overview video button
	Then I should see video field

