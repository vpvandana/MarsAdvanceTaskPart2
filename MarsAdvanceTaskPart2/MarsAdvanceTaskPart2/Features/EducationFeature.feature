Feature: EducationFeature

Registered Mars user should be able to add, update and delete education 

Scenario: Add Education
	Given Login to Mars and user is on profile page of mars
	When I add education from file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\AddEducationTestData.json"
	Then Education should be added successfully

Scenario: Update Education
	Given Login to Mars and user is on profile page of mars
	When I add education from file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\AddEducationTestData.json"
	And I update education from file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\UpdateEducationTestData.json"
	Then Education should be updated successfully

Scenario Outline: Delete Education
	Given Login to Mars and user is on profile page of mars
	When I add education from file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\AddEducationTestData.json"
	And I delete education from file '<DeleteEducation>'
	Then Education should be deleted successfully
Examples: 
| DeleteEducation                                                                                                                                      |
| C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\TestData\\DeleteEducationTestData.json |


Scenario: Add Empty Education
	Given Login to Mars and user is on profile page of mars
	When I add education field empty as in file "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\AddEmptyEducationTestData.json"
	Then Error message to enter all fields should be displayed

Scenario: Add same degree same year
	Given Login to Mars and user is on profile page of mars
	When I add education from file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SameDegreeSameYear.json"
	And I add degree and year that is already adeed as in file "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SameDegreeSameYear.json"
	Then error message information already exists should be displayed

Scenario: Add same degree different year
	Given Login to Mars and user is on profile page of mars
	When I add education from file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SameDegreeSameYear.json"
	And I add  same degree and different year as in file "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\SameDegreeDifferentYear.json"
	Then error message duplicated data should be displayed

Scenario: Update education without making changes
	Given Login to Mars and user is on profile page of mars
	When I click on Update button without making changes
	Then Error message that information already exists should be displayed
