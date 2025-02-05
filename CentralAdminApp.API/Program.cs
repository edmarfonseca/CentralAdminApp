using CentralAdminApp.API.Configurations;
using CentralAdminApp.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

// Configuração da Sessão
builder.Services.AddDistributedMemoryCache(); // Necessário para SessionStore
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
app.UseSession(); // Sessão antes do middleware de acesso
app.UseMiddleware<AccessControlMiddleware>(); // Agora a sessão já está disponível
app.UseSwaggerConfiguration();

app.MapControllers();
app.Run();

public partial class Program { }