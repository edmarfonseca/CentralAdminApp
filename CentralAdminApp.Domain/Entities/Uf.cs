namespace CentralAdminApp.Domain.Entities
{
    public class Uf : EntityBase
    {
        public string? Sigla { get; set; }
        public string? Descricao { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
    }
}