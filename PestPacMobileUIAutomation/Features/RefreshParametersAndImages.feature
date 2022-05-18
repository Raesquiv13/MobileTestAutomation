Feature: RefreshParametersAndImages
	Verify Refresh Parameters Working as expected
	Verify Refresh Images Working as expected
@regression
@done
Scenario: Refresh Parameters
	#Given Home Displayed
	When Click on Three Dots
	And Click on Refresh Parameters
	Then Parameters are Refreshed
@regression
@done
Scenario: Refresh Images
	Given Home Displayed
	When Click on Three Dots
	And Click on Refresh Images
	Then Images are Refreshed