Feature: ShareSkillAddFeature

As a Mars user, I should be able to add skills I have to service listing


Scenario: Share skill add
	Given Login to Mars and user is on profile page of mars
	When I add service to list from data located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ShareSkillAddTestData.json"
	Then Service should be added successfully

Scenario: Mandatory field empty
	Given Login to Mars and user is on profile page of mars
	When I left mandatory fields in the form empty "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\MandatoryFieldsEmptyShareSkillTestData.json"
	Then Error message to fill the form should be displayed correctly

Scenario Outline: Add Special characters in Title field
	Given Login to Mars and user is on profile page of mars
	When I add special characters in title field '<SpecialCharacterTitle>'
	Then Error message should be displayed

Examples: 
| SpecialCharacterTitle |
| C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SpecialCharacterTitleDescriptionShareSkillTestData.json |

Scenario Outline: Add first character space in Title field
	Given Login to Mars and user is on profile page of mars
	When I add space as first character in title field '<FirstCharacterSpace>'
	Then Error message that indicates space as first character not allowed should be displayed

Examples: 
| FirstCharacterSpace |
| C:\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\FirstChatacterSpaceOnTitleShareSkill.json |

Scenario Outline: Add first character space on description field
	Given Login to Mars and user is on profile page of mars
	When I add first character as space in description field '<FirstCharacterSpaceDescription>'
	Then Space not allowed as first character should be displayed

Examples: 
| FirstCharacterSpaceDescription |
|  C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\FirstCharacterSpaceOnDescriptionShareSkill.json  |

Scenario Outline: SubCatagory not selected
	Given Login to Mars and user is on profile page of mars
	When I did not choose sub catagory from dropdown and tags '<SubCatagoryandTagsNotChosen>'
	Then Error message to fill form completely should be displayed

Examples: 
| SubCatagoryandTagsNotChosen |
|  C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SubCatagoryNotSelectedTestData.json  |

Scenario Outline: Tags not selected
	Given Login to Mars and user is on profile page of mars
	When I did not choose sub catagory from dropdown and tags '<SubCatagoryandTagsNotChosen>'
	Then Error message to fill tags should be displayed

Examples: 
| SubCatagoryandTagsNotChosen |
|  C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SubCatagoryNotSelectedTestData.json  |

Scenario Outline: Click on Cancel button without saving
	Given Login to Mars and user is on profile page of mars
	When I add all the fields '<ClickOnCancel>' and click on cancel button
	Then Service should not be added to manage listing

Examples: 
| ClickOnCancel |
|   C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ClickOnCancelShareSkillAddTestData.json            |