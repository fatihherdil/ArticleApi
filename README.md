# ArticleApi
.Net Core WebApi Sample

# Before RUN ! 
Run Database Scripts From Documents for Your Database Provider

##### Naming Conventions of Database Scripts:
Database[DbProvider].sql

ASPNETCORE_ENVIRONMENT variable in ArticleApi.Web.Api Properties -> Debug


## Url's For Accessing Articles and Authors
http://localhost:5000/Articles

http://localhost:5000/Authors

## Database
Database creation scripts are Under Documents Folder.

##### Selecting Database Provider
We have 2 Providers for Database Connection
- MySql
- MsSql

You can change Database Provider in ```appsettings.json``` file and there are Connection Strings for each Database Provider please change them with Provider.

# Answers

I used Null Object and Data Transfer Object Design Patterns because it was needed in the project.

I didn't use MySql with Entity Framework Core, I used MsSql, SqlLite, Postgresql. I didn't use any third party Library or Framework.

If i had more time i would do More Testing And Write Tests and Make a Good Expession Predicate Builder.
 