using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.DelphITService
{
    public class DelphITService : IDelphITService
    {
        private readonly IAmazonDynamoDB _ddbClient;
        private readonly string _delphiTableName;

        public DelphITService(IAmazonDynamoDB ddbClient, IConfiguration configuration)
        {
            _ddbClient = ddbClient;
            _delphiTableName = configuration["AWS:Resources:DelphITable"] ?? throw new ArgumentNullException(nameof(configuration), "DelphITable configuration value is missing or null.");
        }

        public async Task<IEnumerable<DelphIT>> GetAllAsync()
        {
            var scanRequest = new ScanRequest
            {
                TableName = _delphiTableName
            };

            var response = await _ddbClient.ScanAsync(scanRequest);

            return response.Items.Select(ConvertItemToDelphIT).ToList();
        }
        public async Task AddAsync(DelphIT newItem)
        {
            var request = new PutItemRequest
            {
                TableName = _delphiTableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"Id", new AttributeValue {N = newItem.Id.ToString()}},
                    {"Name", new AttributeValue {S = newItem.Name}},
                    {"Bio", new AttributeValue {S = newItem.Bio}}
                }
            };

            await _ddbClient.PutItemAsync(request);
        }
        private DelphIT ConvertItemToDelphIT(Dictionary<string, AttributeValue> item)
        {
            return new DelphIT
            {
                Id = int.Parse(item["Id"].N),
                Name = item.ContainsKey("Name") ? item["Name"].S : null,
                Bio = item.ContainsKey("Bio") ? item["Bio"].S : null
            };
        }
    }
}
