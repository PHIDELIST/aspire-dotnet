# .NET aspire with AWS
### initializing new aspire project
+ Here is the link to official .NET aspire docs with step by step configuraion. [.NET Aspire Docs](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
## Aspire dashboard
![image](https://github.com/PHIDELIST/aspire-dotnet/assets/64526896/003b7179-3b79-4aa0-be6f-bad71f373272)

### Aspire AWS hosting docs
https://www.nuget.org/packages/Aspire.Hosting.AWS

## RabbitMQ
+ To install aspire rabbitMQ client run ``` dotnet add package Aspire.RabbitMQ.Client --prerelease```
+ To learn more about using rabbitMQ with aspire dotnet: [AspireRabbitMQ](https://learn.microsoft.com/en-us/dotnet/aspire/messaging/rabbitmq-client-component?tabs=dotnet-cli)
### Aspire.Hosting.RabbitMQ library
#### Install the package

In your AppHost project, install the .NET Aspire RabbitMQ Hosting library with:

```dotnetcli
dotnet add package Aspire.Hosting.RabbitMQ
```
#### Usage example

Then, in the _Program.cs_ file of `AppHost`, add a RabbitMQ resource and consume the connection using the following methods:

```csharp
var rmq = builder.AddRabbitMQ("rmq");

var myService = builder.AddProject<Projects.MyService>()
                       .WithReference(rmq);
```
### DynamoDb
Dynamodb local with aspire dotnet is still under preview.

 ```aws dynamodb list-tables --endpoint-url http://localhost:{PORT}/```

 + If you get credentials not found error just do ```aws configure``` and provide fake secret key and fake access key id dynamodb local does not validate them.
## Dynamodb create table 
``` aws dynamodb create-table \
        --table-name DelphITable \
        --attribute-definitions \
            AttributeName=Id,AttributeType=N \
        --key-schema AttributeName=Id,KeyType=HASH \
        --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1 \
        --table-class STANDARD\
        --endpoint-url http://localhost:62643
```

### API swagger UI
![image](https://github.com/PHIDELIST/aspire-dotnet/assets/64526896/be922401-d4d2-469d-8768-598b4b9e3895)
