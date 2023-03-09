   Feature:Search Testing
    As a user
    I want to be able to search for items on the website
    So that I can find the information I need quickly and easily

   @BDD_UI
   Scenario: Search for an item with a given word
		Given I should see the search bar
		When I execute search with a given word
		Then I should see search results

