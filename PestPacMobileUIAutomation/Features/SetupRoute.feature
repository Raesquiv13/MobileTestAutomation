Feature: SetupRoute
	Setup Route 

@regression
@done
Scenario: Enable Auto Navigate
	Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	And Enable Auto Navigate
	And Click on Back from Setup Route
	Given Home Displayed
	When Click on Stop
	Then Maps is opened
@regression
@done
Scenario: Deactivate Auto Navigate
	#Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	And Deactivate Auto Navigate
	And Click on Back from Setup Route
	When Click on Stop
	Then Confirm Button Is Displayed	
@regression
@done
Scenario: Deactivate Auto Refresh Route
	#Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	And Deactivate Auto Refresh Route
	And Click on Back from Setup Route
	Then Route List does not update automatically
@regression
@done
Scenario: Activate Quick Production
	Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	And Activate Quick Production
	And Click on Back from Setup Route
	When Click on Stop
	Then Interface Quick Production Mode is Displayed
	
@regression
@done
Scenario: Deactivate Quick Production
	#Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	And Deactivate Quick Production
	And Click on Back from Setup Route
	When Click on Stop
	Then Confirm Button Is Displayed
	
@regression
@blocked
Scenario: Activate Do Not Auto Advance
	Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	Then Activate Do Not Auto Advance
	Then Click on Back from Setup Route
	Then Date is not changed
@regression
@blocked
Scenario: Activate Show Distance and Direction
	Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	Then Activate Show Distance and Direction to Stop
	Then Click on Back from Setup Route
	Then Routes have Distance and Directions
@regression
@done
Scenario: Delete Data Base
	#Given Home Displayed
	When Click on Three Dots
	And Click on Setup Route
	And Click on Route Setup Three Dots
	And Click on Delete Data Base
	Then Data Base is Deleted
	
	#Then Click on Back from Setup Route
