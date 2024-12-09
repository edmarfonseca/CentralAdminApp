using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Interfaces.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(Usuario usuario);

        DateTime GenerateExpirationDate();
    }
}