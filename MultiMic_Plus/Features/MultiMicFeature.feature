Feature: MultiMic

A short summary of the feature

Scenario: Validating Multimic+ reflected in demo mode if selected
	Given I am on welcome page and i press take me to demo mode
	When  I press ok on Demo mode popup
	And   I press no thanks on welcome popup
	And   I press on More tab on bottom ribbon bar
	And   I press Pair new wireless accessory
	And   I select Multi_Mic+
	Then  I valiadte "Multi_Mic+" displayed on top of the page
	When  I press search
	Then  I valiadte "Multi-Mic+" displayed on top of the page
	When  I press ok
	Then  I valiadte "Multi-Mic+" displayed on top of the page
	When  I press ok



