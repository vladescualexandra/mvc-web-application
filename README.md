# mvc-web-application

## Project Topic
- Create an application using ASP.NET Core 6.X on a topic of your choice, allowing users to perform CRUD operations on two related classes (ex: Product-Category). The application will be accessible only to authenticated users. The operations that the users will be able to perform will depend on their associated role(s).

## Authentication
- [Optional] extend the default user class with at least one additional field;
- change the minimum length of the password;
- lock the user out for 30 minutes after 5 unsuccessful attempts;
- the application will not allow unauthenticated users to register. The only users available in the application will be the ones that you are going to create in the "SeedDataIdentity" class (or in a class with another name, but with a similar purpose);

## Authorization
- implement role-based authorization;
- use both imperative and declarative authorization;
- note: your application should use at least two different roles;

## SSL
- redirect HTTP requests to HTTPS;
- send HTTP Strict Transport Security Protocol (HSTS) headers to clients;

## Other
- your forms should be protected against Cross-Site Request Forgery (CSRF) attacks;

## [Optional]
- deploy your application on Microsoft Azure (or on any other cloud computing platform). Note: please specify the address and provide a user account for accessing the application.
