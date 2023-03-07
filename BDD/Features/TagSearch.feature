Feature: Searching Companies By Tag

@BDD_UI
Scenario: Searching Companies using the "Filter By Tag" option with 1 Tag
	Given I am successfully logged in
	When I go to the Companies Page
	And I click the 'Filter By Tag' Button
	And I Input 'rust' In the searchbox of the tag pane
	And Click on the searched Tag	
	Then The Tag should get attached to the searchbox with the option to remove it
	When I click the 'Apply Filter' button
	Then The selected filter should get applied correctly
	#1.The Company Count Is Displayed under The SearchBox
    #2. The Count Of Selected Tags Is Displayed within the 'Filter By Tag' Button
	#3. The Selected Tags Appeared Under The SearchBox
	When I Navigate To each page returned by the filter and click on the 'Our Tech Stack' tab	
	Then The 'rust' should be in the list of 'Our Tech Stack' area
