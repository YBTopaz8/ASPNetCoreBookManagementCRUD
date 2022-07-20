
# Simple Invite Only Document Management System

My First attempt to learn ASP.NET CORE and EF by building a website where users can login ONLY with an invitation code. 

The Admin can send an email to the users which will contain the said invitation code. When the user logs in, the system must be able to recognize the code a code can only be used ONCE.

After which users can add, edit or delete documents (Books, Articles, Research Docs etc...)

This is a C# Version of the ResearchInternship repo that I did with Django, but aimed at being better.

## Features

- Simple CRUD for Categories.

More to come very soon...
## Requirements

This project was built on .NET Core 6 using Entity FrameworeCore 6.0.7 at its time

To install and use THIS project, you would need;
- Visual Studio 2019, 2022 or latest (I used VS 2022)
- SQLServer 2012 upwards (I used SQLServer 2012)
- SSMS 18 would be best.
## Installation

To install the project, please do as follows;
- Clone the project from my GitHub
- Extract the project to your desired location
- Load it in Visual Studio
- Open the appsettings.json file and edit the "DefautConnection" string, set Your server and DataBase
- Open the Package Manager Console (By clicking on the "View" tab up top, then "other windows" and you'll find it)
- Since it will be the first time, go to the package manager and type "add-migration MyFirstMigration" 
- Then simply type "Update-Database"

Once done updating the DataBase, Simple run your app (F5) and that's it!



## Author

- [@Yvan Brunel](https://github.com/YBTopaz8)
- [My Simple Portfolio](https://flowcv.me/ybtopaz)


# Hi, I'm Yvan Brunel! 👋


## 🚀 About Me

I am Currently an MSc graduate Software Engineer, proficient in System Analysis and Design. 

Software programming in various OOP languages is what passions me.

I model and build desktop apps with C# as well as Websites with ASP.NET, or Django or PhP.

## 🛠 Skills
- C# .Net desktop programming with Framework & Core
- C# ASP.NET Core MVC programming with Entity Framework 
- Python's Django Web programming
- PhP programming
- MySQL, SQLServer and T-SQL management 