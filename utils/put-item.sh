aws dynamodb put-item \
    --table-name DelphITable \
    --item '{
        "id": {"N": "1"},
        "Name": {"S": "Delphi"},
        "Bio": {"S": "Cloud has it all"} }' \
    --return-consumed-capacity TOTAL\
    --endpoint-url http://localhost:52874