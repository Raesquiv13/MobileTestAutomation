@Login
Feature: Login
	Log into mobile app as a tech
	Log out mobile app as a tech

@2.0
# New code
Scenario: Successful Login
Given Home
When Enter user name and password
Then Real Green Home page displayed
@2.0
Scenario: Failed Loggin
Given Home
When Enter user name and Wrong password
Then Login Failed

	


	