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




