Feature: ManageListingFeature

As a user of Mars, I should be able to update, delete and view 
the service listing I have added to the portal.


Scenario Outline: Update Service Listing
	Given Login to mars and user is on the profile page of mars
	When I add service to list from data located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ShareSkillAddTestData.json"
	And I update '<UpdateManageListing>' the service I added	
	Then Service should be updated successfully
Examples: 
| UpdateManageListing |
| C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\EditManageListingTestData.json |

Scenario Outline: Delete Service Listing
	Given Login to mars and user is on the profile page of mars
	When I add service to list from data located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ShareSkillAddTestData.json"
	And I delete '<DeleteServiceListing>' the service I added
	Then Service should be successfully deleted
Examples: 
| DeleteServiceListing |
|  C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\DeleteSkillListingTestData.json  |

Scenario Outline: View the listed skill
	Given Login to mars and user is on the profile page of mars
	When I add service to list from data located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ShareSkillAddTestData.json"
	And I view '<ViewListedSkill>' the service I added
	Then I should be able to view the service

Examples: 
| ViewListedSkill                                                                                                                                |
| C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\ViewSkillTestData.json |

Scenario Outline: Skill Pagination tests
	Given Login to mars and user is on the profile page of mars
	When I add service to list from data located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ShareSkillAddTestData.json"
	And I search for a the added skill using pagination '<Pagination>'
	Then I should be able to find the skill
Examples: 
| Pagination                                                                                                                                      |
| C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\PaginationTestData.json |

Scenario Outline: Activate Deactivate Service Listing
	Given Login to mars and user is on the profile page of mars
	When I click on toggle button in service listing from '<ActivateButton>'
	Then Service should be activated or deactivated successfully
Examples: 
| ActivateButton |
|   C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ActiveButtonManageListingTestData.json             |
