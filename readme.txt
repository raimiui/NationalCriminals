I have not worked with EF before, so did not investigate various scenarios of using it (i.e. auto seeding with data, deployment).

Microsoft unity as DI.
Types registering moved to Configurations project so that Web project would not have direct dependencies on Repository project.


I would consider launching separate thread from web app, so that user gets 200 response instantly.
Web app is simple currently. Its just a proxy 


Return validation messages from WCF?

Autommaper added for WCF contract mapping
Should add tests for mappings, search (without sending email, just check if data from PersonRepository matches search parameters).
Tests for search query.
Introduce queueing.

Spent 3 hours trying to run WCF on Local IIS, did not succeed, continued with Express IIS (metadata issue).

Deployment configs?..
Consider extracting interfaces to separate libs.

Logging for web, wcf....
Localization support: Email body, subject to resource files.
Retry email send.

Configurable settings can be set in appSettings of the application configuration file.

MVC search form: say successfully/not request was sent

Check for sql injection possibilities.


Liko:
Validacijos WCF
Login

Diagramas paslifuot

Video




----------------
Presentation: 
Can search by part name
