using Amazon;

var builder = DistributedApplication.CreateBuilder(args);

var awsConfig = builder.AddAWSSDKConfig()
                        .WithProfile("dev")
                        .WithRegion(RegionEndpoint.USWest2);

var ddbLocal = builder.AddAWSDynamoDBLocal("ddblocal"); 
var messaging = builder.AddRabbitMQ("RabbitMQConnection");
var awsResources = builder.AddAWSCloudFormationTemplate("AspireAWSDevResources", "aws-resources.template")
                          .WithParameter("DefaultVisibilityTimeout", "30")
                          .WithReference(awsConfig);

var apiService = builder.AddProject<Projects.aspire_dotnet_ApiService>("apiservice")
                        .WithReference(ddbLocal)
                        .WithReference(messaging);
                        // .WithReference(awsConfig)
                        // .WithReference(awsResources);

builder.AddNpmApp("react", "../aspire-react")
    .WithReference(apiService)
    .WithEnvironment("BROWSER", "none") 
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

       

builder.Build().Run();
