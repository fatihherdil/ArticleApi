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

# Design Patterns
##### Null Object Pattern
Used for When an Entity returns Null project or Api consumer should not throw exception.
##### Data Transfer Object Pattern
Used for StackOverFlow Exception also Adding new Entites.

# Technologies
- Entity Framework Core
Besides Entity Framework Core no third party library or Framework used.
I didn't use MySql with Entity Framework Core, I used MsSql, SqlLite, Postgresql.

# Time Challenge
If i had more time i would do More Testing And Write Tests and Make a Good Expession Predicate Builder.

# Architectural Pattern
I used DDD(Domain Driven Design) for this particular project.
 
