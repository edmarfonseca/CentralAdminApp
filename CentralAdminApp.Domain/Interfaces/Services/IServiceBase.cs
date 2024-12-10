namespace CentralAdminApp.Domain.Interfaces.Services
{
    public interface IServiceBase<T, Y> where T : class where Y : class
    {
        T Add(Y dto);
        T Update(int id, Y dto);
        T Delete(int id);
        List<T> Get();
        T Get(int id);
    }
}