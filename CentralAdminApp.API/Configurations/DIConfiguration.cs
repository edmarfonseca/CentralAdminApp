using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Domain.Interfaces.Security;
using CentralAdminApp.Domain.Interfaces.Services;
using CentralAdminApp.Domain.Services;
using CentralAdminApp.Infra.Data.Repositories;
using CentralAdminApp.Infra.Security.Services;

namespace CentralAdminApp.API.Configurations
{
    public static class DIConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<ISistemaService, SistemaService>();
            services.AddTransient<ISistemaRepository, SistemaRepository>();
        }
    }
}