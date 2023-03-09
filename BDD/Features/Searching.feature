Feature: Search Functionality
    As a user
    I want to be able to search for items on the website
    So that I can find the information I need quickly and easily

@BDD_UI
Scenario: Searching for an item in Spackflow
    Given the search bar is visible
    When executes the search request
    Then the search results should be displayed within 100 seconds