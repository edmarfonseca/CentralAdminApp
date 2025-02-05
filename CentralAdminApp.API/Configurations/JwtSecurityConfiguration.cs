using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CentralAdminApp.API.Configurations
{
    public static class JwtSecurityConfiguration
    {
        public static void AddJwtSecurity(this IServiceCollection services)
        {
            var secretKey = "EB1AB146-C07B-48D0-81FD-C42AF391790F";
            services.AddAuthentication(
            auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //não precisa validar a origem do token
                    ValidateIssuer = false,
                    //não precisa validar o destinatário do token
                    ValidateAudience = false,
                    //verificar o tempo de expiração do TOKEN
                    ValidateLifetime = true,                    
                    //Verificando se o TOKEN está assinado com a chave de identificação
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

    }
}