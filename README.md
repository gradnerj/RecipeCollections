# Recipe Collections by Jeff Gradner - a Capstone Project for CS4790 at Weber State University

## This project is a web application using ASP.NET 3.1 Core Razor Pages. This app will be a place for users to sign-up and post recipes publicly. 

### There will be two types of users. 
1. Administrator 
2. Creators

### Planned Features

|   Feature  | Creators | Admin |
| ---- | ---- | ---- |
| Sign-up and login |  :heavy_check_mark:   |  :heavy_check_mark:  |
| Post recipes  | ✔ | ❌ |
| Edit recipes | ✔ | ❌ |
| View recipes | ✔ | ✔ |
| Comment on recipes | ✔ | ❌ |
| Review recipes (1-5 stars) | ✔ | ❌ |
| Send recipe via email | ✔ | ❌ |
| Remove recipes | ✔ | ✔ |


### TODO List -Deliverable 2
- [x] SendGrid
- [x] Admin login
- [x] Change "User" role type to "Creator"
- [x] Admin Lock of Users
- [x] User login
- [x] At least 1 of the UI screens should support dropdowns lists 
- [x] Admin CRUD of Recipes
  - [x] Update Photo input type in Edit page
  - [x] Create: Saves Photo to server and path to object
  - [x] Index: View photo not path
  - [x] Edit: If photo exists on server, delete it and save new photo
  - [x] Delete: Delete object and photo from server
- [x] A Public homepage to "browse" the collection
- [x] Recipe Sorting
- [x] Recipe Filtering
- [x] Recipe Paging
- [x] Add default "No Photo Image"
- [x] At least 1 of the Models should support uploading/editing images (demo this)
- [x] At least 1 of the UI screen should support TinyMCE HTML editing
- [x] Custom site styling
- [x] Photo on Details page
- [x] Pagination, Filtering, Sorting for Admin Recipe
- [x] Create, Details, Delete link styling 
- [x] Details instructions
- [x] Add Real Recipes for Demo

### TODO List - Deliverable 3
- [x] Allow creators to post recipes
- [x] Allow creators to view only their recipes
- [x] Use sessions - I'll add a details page and keep track of recipes they've looked at then display them on another Recently Viewed Page
	- [x] Added Details Page
	- [x] Added RecentlyViewed Page
	- [x] When a user clicks a recipe to view details Add to Session
- [x] Add Category CRUD for Admins to work with categories
- [x] Styling
	- [x] Update images for Creator Recipe CRUD
	- [x] Update instructions for Creator Recipe CRUD
### Key Notes about D3
* Sessions are used to track the ID of recipes clicked on by a User.
	- There are two cookies tracked within my sessions, a list of IDs and a count of how many are in the list for quick reference
* The session cookie storing a complex type, list of integers, is serialized to ensure a distributed cache scenario
	- The serialization occurs in a class I added to the Utility project name SessionExtension
* No model or disk space is used for the sessions, the data stored there retrieves "Recently Viewed" recipes on the Recently Viewed Page. (The eye icon in the navbar)
* Added clearing the sessions data in the Identity logout page. 
* The recently view navbar link will pop-up a modal if the user hasn't viewed any recipes in that session.
	- It will also pop up a modal if the user has viewed recipes but is not logged in.
	- After logging in the user will be redirected to their Recently Viewed Page
* True M:M relationship between Recipes and Collections using a pure join table
	- A recipe can have many categories
	- categories can be assigned to many recipies
* When a Creator selects My Recipes in the navbar they will be directed to a page where they can CRUD recipes associated with their ID
* Creators cannot update or delete recipes that were added by other Creators

### TODO List - Deliverable 4
- [ ] Change Feeds Qty. to Servings - everywhere
- [ ] Allow signed in Creators to Post reviews, add average rating and stars for new rating
- [x] Add default image for Recipes if none is uploaded
- [ ] Media query for different screen sizes
- [x] Carousel size
