# Simple Database for Visual Studio C# projects using JSON

Otago Polytechnic Auckland International Campus Studio 2 projects often need a simple database to persist data such as customer and product information.

This project demonstrates how to build a class to manage each database table in a way similiar to how an SQL client might manage a database. However, the tables are stored as separate Java Script Object Notation (JSON) format text files.  

JSON is an open standard file format that uses human-readable text to store information as data objects consisting of attribute–value pairs and arrays. You can read more about the JSON standard on Wikipedia: https://en.wikipedia.org/wiki/JSON

![Customer UML Class Diagram](https://github.com/user-attachments/assets/d8940a89-5521-4302-9a78-5208d2686ab0)

![Product UML Class Diagram](https://github.com/user-attachments/assets/ee693453-e239-423f-9e81-3c05f97c7d91)

## Installing the JSON Serializer components into Visual Studio
The application reads and writes JSON-format files using a Visual Studio package called _System.Text.Json -Version 4.7.2_ that is not installed automatically.

- Open your Database_using_JSON project in Visual Studio.
- Use the menu to access Tools > NuGet Package Manager > Package Manager Console to open the Package Manager Console window.
- Paste this command into the Package Manager Console Window beside the prompt PM>

  NuGet\Install-Package System.Text.Json -Version 4.7.2
          
- The Package Manager should say this after the package has been downloaded and installed:

  Successfully installed 'System.Text.Json -Version 4.7.2' to Simple_Database

When running the Simple_Database application, you may see a security vunerability warning about this package in the Console window. Do not be concerned. The vunerability relates to an issue if the Serializer is used in C# Web applications, not Windows Desktop Forms applications.

## Creating the Database folders

GitHub does not store example database folders for this project. They need to be created individually on each developers computer and shared separately between the team members if you wish to. The application creates a new Database folder automatically when it detects that the database does not exit.

The program will then let you create and edit new customer and product records inside the customer and products folder. These can be examined and changed manually using a text editor like NotePad++
