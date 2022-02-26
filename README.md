# forum-onnorokom

The project is made for Bluebay IT Limited

Configuration:
1. You need to create database first and then change appsettings.json file with connection string and smtp configuration.
2. Set smtp configuration email and password on MembershipModule.cs file
3. No need to create table. You have to apply migrations. 
    ##### dotnet ef database update --project Demo.Web --context ApplicationDbContext
    ##### dotnet ef database update --project Demo.Web --context MembershipDbContext
	
4. Defaul SuperAdmin email: superadmin@gmail.com and password: Hello@Admin

5. SuperAdmin access permission all area. Only superadmin can create new user. Check email your inbox/Spam folder
6. Manager can only edit product.
7. User only see product table.
