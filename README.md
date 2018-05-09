# Portfolio

##### A portfolio site built using ASP.NET

## By Kayla Ondracek

# Description
This portfolio includes blog posts. Only admin may post blog posts. Admin may also delete/update posts, and may delete comments left by themselves or other users.

Users may post comments on existing blog posts but may not post new blogs and may not delete/update blogs.

In order to facilitate review, this program allows the user to select whether they register as an admin or a guest.

## Specs

* Program should allow users to log on/off
 * Input: Identity authentication
 * Output: User is returned to the Index/Blog page to browse
* Program should include a landing page with a picture of me
  * Input: Home page and img of me
  * Output: When user lands on Home page, they see a picture of me or that represents me
* Program should allow admin to post blog posts
  * Input: Blog post properties (Author, Body, Date)
  * Output: Blog post is created
* Program should include additional CRUD functionality for blog posts (List, Update, Delete - use AJAX for GET methods.)
  * Input: Options to Delete or Update posts for Admin, List for all
  * Output: Deleted post, Updated post, List of posts
* Users should be allowed to comment on blog posts (but not post blog posts)
 * Input: User roles and Authorize routes for blog posts
 * Output: Users are able to comment on posts but not post new blog posts. Output data is a comment and list of comments.
* Admin should be able to Delete all comments
  * Input: Delete method on comments only available to users logged in as admin
  * Output: Deleted comments, return new list of comments
* Program should include additional sections: Work Experience, Education, Skills, Personal Story/How I got into coding, Context info, Projects

## Technologies Used
* Bootstrap
* C#/ASP.NET
* Entity Framework
* MySql/MAMP

## Setup/Installation Instructions
  * Clone the GitHub repository:
  ```
  $ git clone https://github.com/grepcats/gummi-bear-kingdom
  ```

  * Install the .NET Framework and MAMP

    .NET Core 1.1 SDK (Software Development Kit)
    .NET runtime.
    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* Start the Apache and MySql Servers in MAMP. Make sure you use the default port settings for Apache and MySql (8888 and 8889, respectively)

* `cd dotnet-portfolio/Portfolio-Dotnet`

*  Setup the database

  ```
  $ dotnet ef database update
  ```
### Create the Admin and Guest roles:
* Log into MySQL:
```
$ C:\MAMP\bin\mysql\bin\mysql -uroot -proot -P8889
```
* From your command line once you've logged into MySQL, run the following:
```
INSERT INTO `aspnetroles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`) VALUES
('1', NULL, 'Admin', 'ADMIN'),
('2', NULL, 'Guest', 'GUEST');
```
### Restore dependencies and run the program
```
$ cd ..
$ dotnet restore
$ dotnet run
```

### License

*MIT License*

Copyright (c) 2018 **_Kayla Ondracek_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
