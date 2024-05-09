# .NET aspire with AWS
### initializing new aspire project
+ Here is the link to official .NET aspire docs with step by step configuraion. [.NET Aspire Docs](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
## Aspire dashboard
![image](https://github.com/PHIDELIST/aspire-dotnet/assets/64526896/003b7179-3b79-4aa0-be6f-bad71f373272)

### Aspire AWS hosting docs
https://www.nuget.org/packages/Aspire.Hosting.AWS

### Listing local dynamoDb tables
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

### API swager UI
![image](https://github.com/PHIDELIST/aspire-dotnet/assets/64526896/be922401-d4d2-469d-8768-598b4b9e3895)
