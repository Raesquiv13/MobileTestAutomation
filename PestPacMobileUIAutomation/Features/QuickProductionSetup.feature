Feature: QuickProductionSetup
	Verify Enable and Disable Quick Production Options are Displayed

@2.0
Scenario: Verify Enable and Disable Quick Production
	Given Job List Screen
	And Click on More
	When Click on Quick Production
	Then Enable and Disable Options Are Displayed