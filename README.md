# .NET aspire with AWS
## Aspire dashboard
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
