Feature: RefreshVehicleInventory
	Refresh Vehicle Inventory

@regression
@done
Scenario: Refresh Vehicle Inventory
	Given Home Displayed
	When Click on Route Setup Three Dots
	And Click on Refresh Vehicle Inventory
	Then Vehicle Inventory is Refreshed