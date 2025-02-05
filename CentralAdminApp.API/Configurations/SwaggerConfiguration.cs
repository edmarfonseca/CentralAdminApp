using Microsoft.OpenApi.Models;

namespace CentralAdminApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para a geração da documentação do Swagger
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Método para definir as configurações / preferências do Swagger
        /// </summary>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                // Definindo informações da API
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Central Admin - API para gerenciamento de sistemas",
                    Description = "API desenvolvida pela Facto Soluções (www.factoti.com.br) para gerenciamento de sistemas.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Facto Soluções",
                        Email = "factoti@factoti.com.br",
                        Url = new Uri("https://www.factoti.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                // Configurando esquema de autenticação JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT no formato: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }

                });
            });
        }

        /// <summary>
        /// Método para executar e aplicar as configurações do Swagger
        /// </summary>
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Customizando o título e o tema do SwaggerUI
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CentralAdminApp API v1");
                c.DocumentTitle = "CentralAdminApp - Gerenciamento de Sistemas";
            });
        }
    }
}