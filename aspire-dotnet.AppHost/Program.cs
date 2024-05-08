var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.aspire_dotnet_ApiService>("apiservice");


builder.AddNpmApp("react", "../aspire-react")
    .WithReference(apiService)
    .WithEnvironment("BROWSER", "none") 
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
