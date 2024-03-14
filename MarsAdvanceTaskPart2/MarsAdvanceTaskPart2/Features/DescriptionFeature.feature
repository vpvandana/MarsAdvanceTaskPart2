Feature: DescriptionFeature

Aa a Mars user, I should be able to add, update and delete description about me


Scenario Outline: Add and update description
	Given Login to mars and user is on the profile page of mars
	And I click on description edit icon in profile page
	When Add description about me located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\DescriptionTestData.json"
	Then Description should be added successfully

Scenario: Delete Description
	Given Login to mars and user is on the profile page of mars
	And I click on description edit icon in profile page
	When I delete the added description located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\DeleteDescriptionTestData.json"
	Then Description has been deleted successfully

Scenario: Add SpecialNumericCharacters in description
	Given  Login to mars and user is on the profile page of mars
	And I click on description edit icon in profile page
	When I Add description as numeric or special characters located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\DescriptionSpecialNumericSymbolTestData.json"
	Then Description should be added successfully

Scenario:Add description with first character space
	Given  Login to mars and user is on the profile page of mars
	And I click on description edit icon in profile page
	When I add description with first character as space located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\FirstCharacterSpaceTestData.json"
	Then Error message should be displayed correctly