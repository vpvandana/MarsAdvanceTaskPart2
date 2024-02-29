Feature: ProfileAboutMeFeature

As a Mars user, I should be able to add and update details about me.

Scenario: Add and update user name
	Given Login to Mars and user is on profile page of mars
	And I click on username dropdown icon
	When I add firstname and lsatname in aboutme section from file "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ProfileAboutMeTestData.json"
	Then Username should be updated successfully

Scenario: Update availability
	Given Login to Mars and user is on profile page of mars
	And I click on availability edit icon
	When I choose availability from dropdown using file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ProfileAvailabilityTestData.json"
	Then availability should be updated successfully

Scenario: Update hours available 
	Given Login to Mars and user is on profile page of mars
	And I click on hours edit icon
	When I choose the hours that I am available from file "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\AvailabilityHoursTestData.json"
	Then Hours should be updated successfully

Scenario: Update Earn Target amount
	Given Login to Mars and user is on profile page of mars
	And I click on earn target edit icon
	When I choose the target amount from file "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\EarnTargetTestData.json"
	Then Earn target should be updated successfully


