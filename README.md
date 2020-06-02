# Assessment
## How to run the program
For the Catalogue service you need to go into the root of the Assessment.Catalogue.Api project and inside your cmd window type

 - dotnet run
 - To view swagger : [http://localhost:5015/swagger/index.html](http://localhost:5015/swagger/index.html)
 
**For Subscription Service**
 - folder path : Assessment.Subscription.Api 
 - command to run : dotnet run
 - swagger url : [http://localhost:5020/swagger/index.html](http://localhost:5020/swagger/index.html)
 - 
 **Identity server**
 - in the root folder of the service run : dotnet run
 - To register a new user : [http://localhost:5010/](http://localhost:5010/)
 - 
**Api Gateway**
 - in the root folder of the service run : dotnet run
 - The Api Gateway runs from :http://localhost:5005

I followed a microservice type of architecture having resulting in 4 services.
 

 - Catalogue Service : this is meant to be internal service, to be hosted behind a firewall and hold the details of the books.  
 - Subscription Service: this is also meant to be an internal service also to be hosted behind a firewall and it caters for when are user wants to subscribe or unsubscribe.
 - Api GateWay : this is how the outside world can talk to our internal service and it checks if the user has been authenticated before letting them proceed.
 - Identity Server : This caters for the all our authentication needs.
 - 
## Concepts and patterns used
 - I made use of DDD, which has the benefit of having all your logic sit
   in one place rather than scatted through out your system.
   
 - Also made use of CQRS, the repository pattern and the Unit of Work.
 
 ### Other Details
 For our IdentityServer I made use of IdentityServer4 and for the ApiGateWay I made use of Ocelot.
 Also in the folder placed high level over view of the how the system is layed out.
 
### Where Improvements can be made
 - The subscription services goes and queries the catalogue, when a new subscription is made. In future we can improve the design by making use of a queue as well as event sourcing, to trigger an event which says am now waiting for the book name since I now have the ID and this will not impact the user experience if the catalogue service was to go down.