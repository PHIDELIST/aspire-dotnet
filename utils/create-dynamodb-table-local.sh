aws dynamodb create-table \
    --table-name DelphITable \
    --attribute-definitions \
        AttributeName=Id,AttributeType=N \
    --key-schema AttributeName=Id,KeyType=HASH \
    --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1 \
    --table-class STANDARD\
    --endpoint-url http://localhost:54474

