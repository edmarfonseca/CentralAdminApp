using CentralAdminApp.Domain.Dtos;

namespace CentralAdminApp.Domain.Interfaces.Services
{
    public interface ISistemaService
    {
        SistemaResponse Add(SistemaRequest dto);
        SistemaResponse Update(int id, SistemaRequest dto);
        SistemaResponse Delete(int id);
        List<SistemaResponse> Get();
        SistemaResponse Get(int id);
    }
}