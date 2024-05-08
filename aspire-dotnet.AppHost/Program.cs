using Amazon;

var builder = DistributedApplication.CreateBuilder(args);

var awsConfig = builder.AddAWSSDKConfig()
                        .WithProfile("dev")
                        .WithRegion(RegionEndpoint.USWest2);

var ddbLocal = builder.AddAWSDynamoDBLocal("ddblocal"); 

var apiService = builder.AddProject<Projects.aspire_dotnet_ApiService>("apiservice")
                        .WithReference(ddbLocal)
                        .WithReference(awsConfig);


var awsResources = builder.AddAWSCloudFormationTemplate("AspireSampleDevResources", "aws-resources.template")
                          .WithParameter("DefaultVisibilityTimeout", "30")
                          .WithReference(awsConfig);

builder.AddNpmApp("react", "../aspire-react")
    .WithReference(apiService)
    .WithReference(awsResources)
    .WithReference(awsConfig)
    .WithEnvironment("BROWSER", "none") 
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();


builder.Build().Run();
