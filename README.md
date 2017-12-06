# ThirdPartyDbWebAPI
Web API project providing read-only functionalities on the third party database.

Its client App is CompanyDbUpdate which uses this Web API to get a daily snapshot of the third party database.
It is also hosted on IIS with a distinct port number from the other Apps and Web API of the whole solution.

The data access is done via Entity framework from an existing database so the necessary entity classes are generated automatically.

