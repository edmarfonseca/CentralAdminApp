using CentralAdminApp.API.Configurations;
using CentralAdminApp.Infra.Data.Secondary.Settings;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddDependencyInjection();

MongoDBConfiguration.AddMongoDBConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseCorsConfiguration();

app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }