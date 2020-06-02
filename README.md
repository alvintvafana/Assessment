# Assessment
## How to run the program

The entry project for the Catalogue and the Subscription service is the Api project.

**Catalogue Service**
 - Folder to be in : Assessment.Catalogue.Api 
 - On your command window : dotnet run
 - To view swagger : [http://localhost:5015/swagger/index.html](http://localhost:5015/swagger/index.html)
 
**For Subscription Service**
 - folder to be in : Assessment.Subscription.Api 
 - command to run : dotnet run
 - swagger url : [http://localhost:5020/swagger/index.html](http://localhost:5020/swagger/index.html)
 
 **Identity server**
 - in the root folder of the service run : dotnet run
 - To register a new user : [http://localhost:5010/](http://localhost:5010/)
 
**Api Gateway**
 - in the root folder of the service run : dotnet run
 - The Api Gateway runs from :http://localhost:5005

## Microservices architecture
I followed a microservice type of architecture resulting in 4 services.
 

 - **Assessment.Catalogue**: This is an internal service, to be hosted behind a firewall. It holds the details of the books.  
 - **Assessment.Subscription**: This is an internal service, to be hosted behind a firewall and it caters to when the user wants to subscribe or unsubscribe.
 - **Assessment.gateway** : This is how the outside world can talk to our internal service. It checks if the user has been authenticated before letting them proceed.
 - **Assessment.identityserver4** : This caters for all our authentication needs.
 
## Concepts and patterns used
 - I made use of DDD, which has the benefit of having all your logic sit
   in one place rather than scatted throughout your system.
   
 - I also made use of CQRS, the repository pattern, and the Unit of Work.
 
 ### Other Details
 For our IdentityServer, I made use of IdentityServer4 and for the ApiGateWay, I made use of Ocelot. 
 Also in the folder placed a high-level overview of how the system is laid out.
 
### Where Improvements can be made
 - The subscription services goes and queries the catalogue, when a new subscription is made, Which can impact the user experience if the catalogue service goes down during the process. 
 - In future we can improve the design by making use of a queue as well as event sourcing, to trigger an event which says am now waiting for the book name since I now have the bookId, which will result in eventual consistency but a better user experience in case the Catalogue service goes down during the process.
