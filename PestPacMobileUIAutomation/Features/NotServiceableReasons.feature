Feature: NotServiceableReasons
	Add Not Servicable Reasons to Job

@2.0
Scenario: Add Not Serviciable Reason To Job
	Given Job List Screen
	And Hit on a Job from List
	When Add Serviceable Reason 
	Then Job is Marked Not Serviceable