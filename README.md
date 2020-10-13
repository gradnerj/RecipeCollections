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
	- [ ] Added Details Page
	- [ ] Added RecentlyViewed Page
	- [ ] When a user clicks a recipe to view details Add to Session
- [ ] Styling
	- [ ] Update images for Creator Recipe CRUD
	- [ ] Update instructions for Creator Recipe CRUD
	- [ ] Media query for different screen sizes
- [ ] Extra
	- [ ] Allow signed in Creators to Post reviews, add average rating and stars for new rating


