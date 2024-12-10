using CentralAdminApp.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseCorsConfiguration();

app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }