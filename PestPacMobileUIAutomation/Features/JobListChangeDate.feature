Feature: JobListChangeDate
	Change Dates and Verify Jobs are load for each date

@2.0
Scenario: Change Dates
	Given Job List Screen
	When Jobs List are Displayed
	And Change Date
	Then Job List are Updated

Scenario: Job not serviceable
    Given Job List Screen
	When Jobs List are Displayed
	And Change Date "4/28/22"
	And Set job as not serviceable "Dog was out"
	Then Verify job was set as not not serviceable

Scenario: Start job
	Given Job List Screen
	When Jobs List are Displayed
	And Change Date "4/28/22"
	And User starts the job
	Then job appears as started


