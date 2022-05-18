Feature: JobListChangeDate
	Change Dates and Verify Jobs are load for each date

@2.0
Scenario: Change Dates
	Given Job List Screen
	When Jobs List are Displayed
	And Change Date
	Then Job List are Updated