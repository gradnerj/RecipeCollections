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


### TODO List -Deliverable 2 - Last Updated 10/06/2020 9:00 AM
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
- [ ] Custom site styling
