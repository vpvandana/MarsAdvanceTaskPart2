Feature: LoginFeature

As a registered Mars user, I should be able to login to the application successfully


Scenario: Do Login with valid credential
	When I enters valid credentials using json file located at "C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\UserInformationTestData.json"
	Then I should be logged in successfully


Scenario: Do succesfull login
	Given Login to Mars and user is on profile page of mars
	Then I should be logged in successfully


Scenario Outline: Invalid username and valid password
	When I enter invalid username and valid password as '<InvalidUsernameValidPassword>'
	Then Error message to enter a valid username should be dispalyed

Examples: 
| InvalidUsernameValidPassword |
| C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\InvalidUsernameValidPasswordTestData.json  |

Scenario Outline: Valid Username and Incorrect password
	When I enter valid username but incorrect password '<ValidUsernameIncorrectPassword>'
	Then Error message to confirm email or password should be dispalyed
Examples: 
| ValidUsernameIncorrectPassword |
|  C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\IncorrectPasswordTestData.json  |

Scenario Outline: Forgot Password Functionality
	When I click on forgot password link and I enter email in send email verification '<EmailVerification>'
	Then Email verification sent message to change password should be dispalyed
Examples: 
| EmailVerification |
| C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\ForgotPasswordTestData.json  |

Scenario Outline: Invalid Email Verification in Forgot Password
	When I click on forgot password link and I enter invalid email id for email verification '<InvalidVerificationId>'
	Then Error message email is inavalid should be displayed

Examples:
| InvalidVerificationId |
|C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\InvalidVerificationIdTestData.json |

Scenario Outline: Password Character Specification
	When I enter a password less than six characters '<LessCharacterPassword>'
	Then Error message to add more than six characters should be dispalyed
Examples: 
| LessCharacterPassword |
|   C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\TestData\PasswordCharacterSpecificationTestData.json  |