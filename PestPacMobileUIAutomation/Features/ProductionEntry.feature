Feature: ProductionEntry
	Allow to user Add Products, Conditions, Weather, Feedback Notes

@2.0
Scenario: Verify Production ENtry Elements are Displayed 
	Given Job List Screen
	And Disable Quick Production
	When Open and Start a Service
	Then Elements in Production Entry are Displayed