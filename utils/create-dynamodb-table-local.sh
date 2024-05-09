aws dynamodb create-table \
    --table-name DelphITable \
    --attribute-definitions \
        AttributeName=Id,AttributeType=N \
        AttributeName=Name,AttributeType=S \
    --key-schema AttributeName=Id,KeyType=HASH AttributeName=Name,KeyType=RANGE\
    --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1 \
    --table-class STANDARD\
    --endpoint-url http://localhost:54474

