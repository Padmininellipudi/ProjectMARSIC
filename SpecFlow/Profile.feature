Feature: ProfileFeature

As a Seller
I want the feature to add my Profile Details
so that
The people seeking for some skills can look into my details 

Scenario: Validate if seller can login with valid credentials
	Given Seller is in home page
	When Seller enters valid username and password
	And Clicks Login button
	Then Seller logged in successfully

Scenario: Validate if seller can navigate to progile page
	Given Seller has Home page
	When Seller clicks Hi Padmini link
	And Selcts Go to Profile option
	Then Seller navigates to profile page successfully

Scenario: Validate if the seller can view the profile image
	Given Seller has a Profile Image
	When Seller visits Profile page
	Then verify Seller can see the Profile Image
	
Scenario: Validate if the seller can't view the profile image 
	Given Seller doesnt have a Profile Image
	When Seller visits Profile page
	Then verify Seller sees a message to upload the Profile Image

Scenario: Validate if the seller can view the Seller's Name
	Given Seller has a Seller's Name
	When Seller visits Profile page
	Then verify Seller can see the Seller's Name

Scenario: Validate if the seller can't view the Seller's Name
	Given Seller doesnt have a Seller's Name
	When Seller visits Profile page
	Then verify Seller sees a message to Add Name

Scenario: Validate if the seller can view the Seller's Extra Details
	Given Seller has a Seller's Extra Details
	When Seller visits Profile page
	Then verify Seller can see the Seller's Extra Details

Scenario: Validate if the seller can't view the Seller's Extra Details
	Given Seller doesnt have a Seller's Extra Details
	When Seller visits Profile page
	Then verify Seller sees a message to Add Seller's Extra Details

Scenario: Validate if the seller can Add/Update the profile image 
	Given Seller visits Profile page
	When Seller Adds/Edits Profile Image
	Then verify Seller can see the Added/Updated Profile Image on the Profile Page

Scenario: Validate if the seller can Add/Update the Seller's Name
	Given Seller visits Profile page
	When Seller Adds/Edits Seller's Name
	Then verify Seller can see the Added/Updated Seller's Name on the Profile Page

Scenario: Validate if the seller can Add/Update the Seller's Extra Details
	Given Seller visits Profile page
	When Seller Adds/Edits Seller's Extra Details
	Then verify Seller can see the Added/Updated Seller's Extra Details on the Profile Page

Scenario: Validate if the Seller can input Valid fields on Name section
	Given Seller visits Profile page
	When Seller inputs First Name and Last Name 
	And clicks on Save button  
	Then verify Seller can see the Name on the Profile page         

Scenario: Validate if the Seller can input MaxLength values on Name section
	Given Seller visits Profile page
	When Seller inputs MaxLength value in First Name and Last Name field
	And clicks on Save button  
	Then verify Seller can see the appropriate message on the Profile page      
	
Scenario: Validate if the Seller can input Null values on Name section
	Given Seller visits Profile page
	When Seller inputs Null value in First Name and Last Name field
	And clicks on Save button  
	Then verify Seller can see the appropriate message on the Profile page 

Scenario: Validate if seller can View Description
	Given Seller visits Profile page
	When there is any Description for Seller
	Then verify Seller can view the Description

Scenario: Validate if seller can't View Description
	Given Seller visits Profile page
	When there is no Description for Seller
	Then verify Seller has to enter the Description

Scenario: Validate if seller can Add Description
	Given Seller visits Profile page
	When Seller Adds Description
	Then verify Seller can view the Added Description

Scenario: Validate if seller Adds Null value in Description
	Given Seller visits Profile page
	When Seller inputs Null value in Description
	Then verify Seller can see the appropriate message on the Profile page

Scenario: Validate if seller Adds MaxLength of 600 characters in Description
	Given Seller visits Profile page
	When Seller inputs MaxLength of 600 characters in Description
	Then verify Seller can see the appropriate message on the Profile page

Scenario: Validate if seller can View characters remaining in Description
	Given Seller visits Profile page
	When Seller Adds Description
	Then verify Seller can view the characters remaining in Description

Scenario: Validate if seller can Edit Description
	Given Seller visits Profile page
	And Seller has Description
	When Seller Edits Description
	Then verify Seller can view the Edited Description

Scenario: Validate if seller can View Languages in table
	Given Seller visits Profile page
	When there is any Language for Seller
	Then verify Seller can view the Language in table with Language, Level and option to Edit and Delete

Scenario: Validate if seller can't View Languages
	Given Seller visits Profile page
	When there is no Language for Seller
	Then verify Seller has to enter the Language

Scenario: Validate if seller can View Copy of Language
	Given Seller visits Profile page
	When Seller clicks Language tab
	Then verify Seller can view "How many languages do you speak?"...is displayed with an option to Add New Language

Scenario Outline: Validate if Seller can Add Languages
	Given Seller visits Profile page
	When Seller inputs '<Language>' 
	And clicks Add button
	Then verify Seller can see the added '<Language>' in the Language section of Profile page

	Examples: 
	| Language |
	| English  |
	| Telugu   |
	| Tamil    |

Scenario: Validate if Seller can Add up to a max of 4 Languages
	Given Seller visits Profile page
	When Seller has already 4 Languages
	Then verify Seller can't Add any more languages in the Language section of Profile page 

Scenario: Validate if seller Adds MaxLength value in Language field in Languages
	Given Seller visits Profile page
	When Seller inputs MaxLength value in Language field in Languages
	Then verify Seller can see the appropriate message on the Profile page


Scenario: Validate if seller Adds Null value in Language field in Languages
	Given Seller visits Profile page
	When Seller inputs Null value in Language field in Languages
	Then verify Seller can see the appropriate message on the Profile page 

Scenario: Validate if seller Adds Null value in Choose Language level dropdown in Languages
	Given Seller visits Profile page
	When Seller inputs Null value in Choose Language level dropdown in Languages
	Then verify Seller can see the appropriate message on the Profile page 

Scenario: Validate if Seller can Cancel the form while adding a Language
	Given Seller visits Profile page
	When Seller inputs Language and Level
	And clicks Cancel button
	Then verify Seller can't see the added languages in the Language section of Profile page

Scenario: Validate if Seller can Edit Languages
	Given Seller has Languages in Language section
	When Seller Edits Languages
	Then verify Seller can see the updated Languages in the Language section of Profile page

Scenario: Validate if Seller Edits with same value in Languages
	Given Seller has Languages in Language section
	When Seller Edits Languages with same values in Add Language and Choose Language Level dropdown fields
	Then verify Seller can see "This Language is already added to your language list" in the Language section of Profile page

Scenario: Validate if seller Edits with MaxLength value in Language field in Languages
	Given Seller has Languages in Language section
	When Seller Edits with MaxLength value in Language field in Languages
	Then verify Seller can see the appropriate message in the Language section of Profile page


Scenario: Validate if seller Edits with Null value in Language field in Languages
	Given Seller has Languages in Language section
	When Seller Edits with Null value in Language field in Languages
	Then verify Seller can see "Please enter language and level" in the language section of Profile page  

Scenario: Validate if seller Edits with Null value in Choose Language level dropdown in Languages
	Given Seller has Languages in Language section
	When Seller Edits with Null value in Choose Language level dropdown in Languages
	Then verify Seller can see "Please enter language and level" in the language section of Profile page

Scenario: Validate if seller can Delete Edited Languages
	Given Seller has Languages in Language section
	When Seller Deletes Edited Languages
	Then verify Seller can see "........ has been deleted from your languages" in the Language section of Profile page

Scenario: Validate if seller can View Skills
	Given Seller visits Profile page
	When there is any Skill for Seller
	Then verify Seller can view the Skills

Scenario: Validate if seller can't View Skills
	Given Seller visits Profile page
	When there is no Skill for Seller
	Then verify Seller has to enter the Skills

Scenario: Validate if seller can View the copy in Skills section
	Given Seller visits Profile page
	When Seller clicks Skills tab
	Then verify Seller can view "Do you have any skills?..." is displayed with an option to Add New Skills

Scenario: Validate if seller can Add Skills
	Given Seller visits Profile page
	When Seller inputs Skill and Level
	And clicks Add button
	Then verify Seller can see the added Skills in the Skill section of Profile page

Scenario: Validate if seller inputs MaxLength in Add Skill field in Skills section
	Given Seller has skills in Skills section
	When Seller Adds MaxLength value in Add Skill field in Skills
	Then verify Seller can see the appropriate message in the Skills section of Profile page

Scenario: Validate if seller inputs Null value in Add Skill field in Skills section
	Given Seller has skills in Skills section
	When Seller Adds Null value in Add Skill field in Skills
	Then verify Seller can see "Please enter skill and experience level" in the Skills section of Profile page

Scenario: Validate if seller inputs Null value in Choose Skill Level dropdown in Skills section
	Given Seller has skills in Skills section
	When Seller Adds Null value in Choose Skill Level dropdown in Skills
	Then verify Seller can see "Please enter skill and experience level" in the Skills section of Profile page

Scenario: Validate if seller inputs same value in Skills section of Profile page
	Given Seller has skills in Skills section
	When Seller Adds same value in Add Skill and Choose Skill Level dropdown in Skills section
	Then verify Seller can see "Duplicate Data" in the Skills section of Profile page

Scenario: Validate if Seller can Cancel the form while adding a Skill
	Given Seller visits Profile page
	When Seller inputs Add Skill and Choose Skill Level in Skills section
	And clicks Cancel button
	Then verify Seller can't see the added skills in the Skills section of Profile page 

Scenario: Validate if seller can Update Skills
	Given Seller visits Profile page
	And Seller has Skills
	When Seller Edits Skills
	Then verify seller can see the updated Skills in the Skill section of Profile page


Scenario: Validate if Seller can Cancel the form while Updating a Skill
	Given Seller visits Profile page
	And Seller has a Skill
	When Seller Edits Add Skill and Choose Skill Level
	And clicks Cancel button
	Then verify Seller can't see the Updated Skills in the Skills section of Profile page

Scenario: Validate if seller can Update with same value in Skills section
	Given Seller has skills in Skills section
	When Seller Edits same value in Add Skill and Choose Skill Level dropdown in Skills section
	Then verify Seller can see "This skill is already added to your skill list" in the Skills section of Profile page

Scenario: Validate if seller Edits with Null value in Add Skill field in Skills section
	Given Seller has skills in Skills section
	When Seller Edits with Null value in Add Skill field in Skills
	Then verify Seller can see "Please enter skill and experience level" in the Skills section of Profile page

Scenario: Validate if seller Edits Null value in Choose Skill Level dropdown in Skills section
	Given Seller has skills in Skills section
	When Seller Edits Null value in Choose Skill Level dropdown in Skills
	Then verify Seller can see "Please enter skill and experience level" in the Skills section of Profile page

Scenario: Validate if seller can Delete Skills
	Given Seller has skills in Skills section
	When Seller Deletes Skills
	Then verify Seller can see "........ has been deleted from your Skills" in the Skills section of Profile page

Scenario: Validate if seller can View Education
	Given Seller visits Profile page
	When there is any Education for Seller
	Then verify Seller can view the Education

Scenario: Validate if seller can't View Education
	Given Seller visits Profile page
	When there is no Education for Seller
	Then verify Seller has to enter the Education

Scenario: Validate if seller can View the copy in Education section
	Given Seller visits Profile page
	When Seller clicks Education tab
	Then verify Seller can view "Did you attend a college or university?..."with an option to Add New Education

Scenario: Validate if seller can Add Education
	Given Seller visits Profile page
	When Seller inputs College/University, Country of College/University, Title, Degree, Year of Graduation
	And clicks Add button
	Then verify Seller can see the added Education in the Education section of Profile page

Scenario: Validate if seller inputs MaxLength in College/University name field in Education section
	Given Seller has Education in Education section
	When Seller Adds MaxLength value in College/ University name field in Education
	Then verify Seller can see the appropriate message in the Education section of Profile page

Scenario: Validate if seller inputs Null value in College/ University name field in Education section
	Given Seller has education in Education section
	When Seller Adds Null value in College/ University name field in Education
	Then verify Seller can see "Please enter all the fields" in the Education section of Profile page

Scenario: Validate if seller inputs Null value in Country of College/University dropdown in Education section
	Given Seller has Education in Education section
	When Seller Adds Null value in College/University dropdown in Education
	Then verify Seller can see "Please enter all the fields" in the Education section of Profile page

Scenario: Validate if seller inputs Null value in Title dropdown in Education section
	Given Seller has Education in Education section
	When Seller Adds Null value in Title dropdown in Education
	Then verify Seller can see "Please enter all the fields" in the Education section of Profile page

Scenario: Validate if seller inputs Null value in Degree field in Education section
	Given Seller has education in Education section
	When Seller Adds Null value in Degree field in Education
	Then verify Seller can see "Please enter all the fields" in the Education section of Profile page

Scenario: Validate if seller inputs Null value in Year of Graduation dropdown in Education section
	Given Seller has Education in Education section
	When Seller Adds Null value in Year of Graduation dropdown in Education
	Then verify Seller can see "Please enter all the fields" in the Education section of Profile page

Scenario: Validate if seller inputs same value in Education section of Profile page
	Given Seller has Education in Education section
	When Seller Adds same value in College, Country, Title, Degree, Year fields in Education section
	Then verify Seller can see "This information already exists" in the Education section of Profile page

Scenario: Validate if Seller can Cancel the form while adding Education
	Given Seller visits Profile page
	When Seller inputs College/University, Country of College/University, Title, Degree, Year of Graduation
	And clicks Cancel button
	Then verify Seller can't see the added Education in the Education section of Profile page

Scenario: Validate if seller can Edit Education
	Given Seller visits Profile page
	And Seller has Education
	When Seller Edits College/University, Country of College/University, Title, Degree, Year of Graduation
	Then verify seller can see the updated Education in the Education section of Profile page


Scenario: Validate if Seller can Cancel the form while Updating Education
	Given Seller visits Profile page
	And Seller has Education
	When Seller Edits College/University, Country of College/University, Title, Degree, Year of Graduation
	And clicks Cancel button
	Then verify Seller can't see the Updated Education in the Education section of Profile page

Scenario: Validate if seller sees a message if Education is updated
	Given Seller visits Profile page
	And Seller has Education
	When Seller Edits College/University, Country of College/University, Title, Degree, Year of Graduation
	And clicks Update button
	Then verify Seller sees "Education has been Updated" in the Education section of Profile page

Scenario: Validate if seller can Edit with same value in Education section
	Given Seller has Education in Education section
	When Seller Edits same value in College/University, Country of College/University, Title, Degree, Year of Graduation
	Then verify Seller can see "This information already exists" in the Education section of Profile page

Scenario: Validate if seller Edits with Null value in Education section
	Given Seller has Education in Education section
	When Seller Edits with Null value in College/University, Country of College/University, Title, Degree, Year of Graduation
	Then verify Seller can see "Please enter all the fields" in the Education section of Profile page

Scenario: Validate if seller can Delete Education
	Given Seller has Education in Education section
	When Seller Deletes Education
	Then verify Seller can see "Education entry successfully removed" in the Education section of Profile page 

Scenario: Validate if seller can View Certification
	Given Seller visits Profile page
	When there is any Certification for Seller
	Then verify Seller can view the Certification

Scenario: Validate if seller can't View Certification
	Given Seller visits Profile page
	When there is no Certification for Seller
	Then verify Seller has to enter the Certification

Scenario: Validate if seller can View the copy in Certification section
	Given Seller visits Profile page
	When Seller clicks Certification tab
	Then verify Seller can view "Do you have any certifications?..."with an option to Add New Certification

Scenario: Validate if seller can Add Certification
	Given Seller visits Profile page
	When Seller inputs Certificate/Award, Certified from, Year fields in Certification section
	And clicks Add button
	Then verify Seller can see the added Certification in the Certification section of Profile page

Scenario: Validate if seller inputs MaxLength in Certificate/Award field in Certification section
	Given Seller has Certification in Certification section
	When Seller Adds MaxLength value in Certificate/Award field in Certification
	Then verify Seller can see the appropriate message in the Certification section of Profile page

Scenario: Validate if seller inputs MaxLength in Certified from field in Certification section
	Given Seller has Certification in Certification section
	When Seller Adds MaxLength value in Certified from field in Certification
	Then verify Seller can see "Please enter all the fields" in the Certification section of Profile page

Scenario: Validate if seller inputs Null value in Certificate/Award field in Certification section
	Given Seller has Certification in Certification section
	When Seller Adds Null value in Certificate/Award field in Certification
	Then verify Seller can see "Please enter Certification Name, Certification From and Certification Year" in the Certification section of Profile page

Scenario: Validate if seller inputs Null value in Certified from field in Certification section
	Given Seller has Certification in Certification section
	When Seller Adds Null value in Certified from field in Certification
	Then verify Seller can see "Please enter Certification Name, Certification From and Certification Year" in the Certification section of Profile page

Scenario: Validate if seller inputs Null value in Year dropdown in Certification section
	Given Seller has Certification in Certification section
	When Seller Adds Null value in Year dropdown field in Certification
	Then verify Seller can see "Please enter Certification Name, Certification From and Certification Year" in the Certification section of Profile page

Scenario: Validate if seller inputs same value in Certification section of Profile page
	Given Seller has Certification in Certification section
	When Seller Adds same value in Certificate/Award, Certified from, Year fields in Certification section
	Then verify Seller can see "This information already exists" in the Certification section of Profile page

Scenario: Validate if Seller can Cancel the form while adding Certification
	Given Seller visits Profile page
	When Seller inputs Certificate/Award, Certified from, Year fields in Certification
	And clicks Cancel button
	Then verify Seller can't see the added Certification in the Certification section of Profile page

Scenario: Validate if seller can Update Certification
	Given Seller visits Profile page
	And Seller has Certification
	When Seller Edits Certificate/Award, Certified from, Year fields in Certification
	Then verify seller can see the updated Certification in the Certification section of Profile page

Scenario: Validate if Seller can Cancel the form while Updating Certification
	Given Seller visits Profile page
	And Seller has Certification
	When Seller Edits Certificate/Award, Certified from, Year fields in Certification
	And clicks Cancel button
	Then verify Seller can't see the Updated Certification in the Certification section of Profile page

Scenario: Validate if seller sees a message if Certification is updated
	Given Seller visits Profile page
	And Seller has Certification
	When Seller Edits Certificate/Award, Certified from, Year fields in Certification
	And clicks Update button
	Then verify Seller sees "Certification has been Updated" in the Certification section of Profile page

Scenario: Validate if seller can Update with same value in Certification section
	Given Seller has Certification in Certification section
	When Seller Edits same value in Certificate/Award, Certified from, Year fields in Certification
	Then verify Seller can see "This information already exists" in the Certification section of Profile page

Scenario: Validate if seller Edits with Null value in Certificate/Award field in Certification section
	Given Seller has Certification in Certification section
	When Seller Edits with Null value in Certificate/Award field in Certification
	Then verify Seller can see "Please enter Certification Name, Certification From and Certification Year" in the Certification section of Profile page

Scenario: Validate if seller Edits with Null value in Certified from field in Certification section
	Given Seller has Certification in Certification section
	When Seller Edits with Null value in Certified from field in Certification
	Then verify Seller can see "Please enter Certification Name, Certification From and Certification Year" in the Certification section of Profile page

Scenario: Validate if seller Edits with Null value in Certification Year field in Certification section
	Given Seller has Certification in Certification section
	When Seller Edits with Null value in Certification Year field in Certification
	Then verify Seller can see "Please enter Certification Name, Certification From and Certification Year" in the Certification section of Profile page

Scenario: Validate if seller can Delete Certification
	Given Seller has Certification in Certification section
	When Seller Deletes Certification
	Then verify Seller can see "Certification entry successfully removed" in the Certification section of Profile page 


	



