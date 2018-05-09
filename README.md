## Specs

* Program should allow users to log on/off
 * Input: Identity authentication
 * Output: User is returned to the Index/Blog page to browse
* Program should include a landing page with a picture of me
  * Input: Home page and img of me
  * Output: When user lands on Home page, they see a picture of me or that represents me
* Program should allow admin to post blog posts
  * Input: Blog post properties (Author, BodyText, Date)
  * Output: Blog post is created
* Program should include additional CRUD functionality for blog posts (List, Update, Delete - use AJAX for GET methods.)
  * Input: Options to Delete or Update posts for Admin, List for all
  * Output: Deleted post, Updated post, List of posts
* Users should be allowed to comment on blog posts (but not post blog posts)
 * Input: User roles and Authorize routes for blog posts
 * Output: Users are able to comment on posts but not post new blog posts. Output data is a comment and list of comments.
* Users should be able to Delete/Update their own comments
* Admin should be able to Delete/Update all comments
* Program should include additional sections: Work Experience, Education, Skills, Personal Story/How I got into coding, Context info, Projects
