Feature: LanguageFeature

As a Seller
I want the feature to add edit delete Language Details on Profile 
so that
The people seeking for skills can look into my details 

Scenario Outline: Validate if Seller can Add Edit Delete Languages
	Given Seller visits Profile page
	When Seller adds '<Language>' 
	Then verify Seller can see the added '<Language>' in the Language section of Profile page
	When Seller edits '<Language>' with '<Edited Language>'
	Then Seller can see the '<Edited Language>' in the Language section of Profile page
	When Seller Deletes '<Edited Language>' Edited Language
	Then Verify Seller can see confirmation message '<Edited Language>' has been deleted from your languages
	And Seller closes the browser

	Examples: 
	| Language | Edited Language |
	| English  | Edited English  |
	| Telugu   | Edited Telugu   |
	| Hindi    | Edited Hindi    |
	