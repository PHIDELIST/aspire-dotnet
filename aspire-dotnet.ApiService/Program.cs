using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Amazon.DynamoDBv2;
using api.Services.DelphITService;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var allowOriginsPolicy = "origin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOriginsPolicy, b =>
    {
        if (builder.Environment.IsDevelopment())
        {
            b.AllowAnyOrigin();
        }

        b.AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed((_) => true);
    });
});

builder.Services.AddControllers();

builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDelphITService, DelphITService>();

builder.Services.AddProblemDetails();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors(allowOriginsPolicy);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.MapGet("/api/healthcheck", () => true);
app.MapGet("/", () => "Delphi API");

app.Run();
