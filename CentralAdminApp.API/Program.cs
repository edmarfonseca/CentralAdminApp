using CentralAdminApp.API.Configurations;
using CentralAdminApp.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

// Configura��o da Sess�o
builder.Services.AddDistributedMemoryCache(); // Necess�rio para SessionStore
builder.Services.AddSession();

builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddDependencyInjection();
builder.Services.AddJwtSecurity();
builder.Services.AddMongoDBConfiguration();

var app = builder.Build();

// Ordem correta do pipeline de middleware
app.UseAuthentication();
app.UseCorsConfiguration();
app.UseAuthorization();
app.UseSession(); // Sess�o antes do middleware de acesso
app.UseMiddleware<AccessControlMiddleware>(); // Agora a sess�o j� est� dispon�vel
app.UseSwaggerConfiguration();

app.MapControllers();
app.Run();

public partial class Program { }