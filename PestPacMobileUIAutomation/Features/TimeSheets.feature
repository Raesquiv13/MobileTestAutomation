Feature: TimeSheets
	TimeSheets Allow user Clock In and Clock Out, also add Crews

@2.0
Scenario: 4Clock In
	Given Job List Screen
	And Tap on Time Sheets
	When User is Not Clocked In
	And Tap on Clock In
	Then User is Clocked In
@2.0
Scenario: 5Clock Out
	Given Time Sheets Screen
	When User is Clocked In
	And Tap on Clock Out
	Then User is Not Clocked In
@2.0
Scenario: 1Select Crew Members
	Given User is logged in
	When User is on timesheets screen
	And User adds crew members
	Then System displayed the crew members selected
@2.0
Scenario: 2Add Crew Members
	Given User is logged in
	When User is on timesheets screen
	Then Crew members selected appears in the timesheets screen
@2.0
Scenario: 3Remove Crew Members
	Given User is logged in
	When User is on timesheets screen
	And User removes the Crew Members
	Then Crew members were removed from timesheets screen




