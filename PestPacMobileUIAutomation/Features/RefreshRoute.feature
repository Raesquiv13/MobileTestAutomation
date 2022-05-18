Feature: RefreshRoute
	User is able to refresh Route

@regression
@done
Scenario: Refresh Route
	Given Home Displayed
	When Click on Three Dots 
	And Click on Setup Route
	And Enable AutoRefresh 
	And Click on Back from Setup Route
	Then Route is refresh