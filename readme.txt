Preconditions
You should work on your local machine.
You may use Visual Studio 2010, 2012 or 2013.
You may use SQL Server 2008 to 2014 (Main or Express edition).
Requirements
Objective

Create a web application and a service to facilitate search in the National Criminals Database.

Functional Specifications

Create a web application:

Users could register themselves. Users should be able to log in.
Users could submit search along with their email address to receive the results (No immediate online results).
Shows errors if parameters fail basic validations at the service call (data type, range, etc.).
Create a web service:

The service exposes a method to submit search with the following parameters.
Person search parameters like (names, age range, sex, height range, weight range, nationality, etc.)
Maximum number of results to produce.
Email address of the results recipient.
Prepares found criminal profiles as PDF files (one person per file)
Email the files to the recipient (maximum 10 files per email, so could be multiple emails).
Technical Specifications

The following list of technical specifications should be adhered to:

For the web service
Create a WCF web service.
Create a database with any required tables to keep criminal details. Insert some test data.
Use LINQ to SQL for database queries.
The service exposed method only validates the parameters and immediately returns true/false. After that it launches a background thread to process and mail the results.
For PDF generation use a library like iTextSharp or PdfSharp. Keep the PDF file simple with only one page.
For the web application
Create an ASP.NET MVC4+ application.
Choose any authentication provider, even a custom one.
Apply input validations and constraints wherever necessary to create a stable application.
Even if you are not able to complete all the tasks, try to achieve a working application.
Add missing requirements to the implementation, according to your experience.
Deliverables
Application Demo

Record the video demonstration of the web application using Wink or any other tool. Do not upload the video. Save it to your local machine.

Database script

Create a single SQL script file to create the database, its schema, any stored procedure and any test data you may use.

Readme

Create a txt file with the following information

Steps to create and initialize the database
Steps to prepare the source code to build properly
Any assumptions made and missing requirements that are not covered in the requirements
Any feedback you may wish to give about improving the assignment.
Design diagrams

Create a doc file containing the following information and diagrams

List of technologies and design patterns used
An overall activity diagram
A sequence diagram for the search process
To be evaluated
The quality of the output (functionality)
Code quality and completeness
Technologies and design applied
Extra validations and assumptions which are not described
Proper documentation and demonstration video
Delivery / What to submit
Please, read and follow this section carefully. Any delivery that does not follow this section will score much less or simply won't be evaluated.

Delivery for this assignment should consist of an archive named <your_name> - CSharpAssignment.zip containing the following

Source code/project including SQL scripts if any
Wink recording, download version 2 from Wink, render the video to swf format
Readme.txt containing the instructions to configure and run the application, notes and feedback
Design.doc with needed diagrams
Structure of the resulting zip file should be of the following format

<your_name> - CSharpAssignment.zip 
<your_name> - CSharpAssignment.zip \Readme.txt 
<your_name> - CSharpAssignment.zip \Design.doc 
<your_name> - CSharpAssignment.zip \Wink\   <<< this folder should contain the wink recording 
<your_name> - CSharpAssignment.zip \Source\   <<< this folder should contain the complete source code for the project(s)

*************************** Readme.txt: ********************************************

****** Setup: ****** 
To run locally:

- Set multiple startup projects (Web and MVC)
- Run.
- In web app, register user in.
- When logged in enter url http://localhost:56513/PersonSearch/ReSeedDb?count=20 
  This will populate database with test data.

****** Considerations/suggestions: ****** 

I would consider launching separate thread from web app, so that user gets 200 response instantly.
Return validation messages from WebService.
Introduce message queueing for search. Send search message to message queue then read and process it. More reliability could be achieved.
Localization support: Email body, subject to resource files.
Email send with retry.
Check for sql injection possibilities.
Option to select user's email as default.

****** Was out of time for: ****** 
Introduce logging.
Validation implementation in WCF.
Unit testing. Should add tests for common work flow, mappings, search (without sending email, just check if data from PersonRepository matches search parameters).




