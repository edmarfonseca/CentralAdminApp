namespace CentralAdminApp.Domain.Dtos
{
    public class CriarUsuarioResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataInclusao { get; set; }
        public CriarUsuarioClienteResponse? Cliente { get; set; }
    }

    public class CriarUsuarioClienteResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CpfCnpj { get; set; }
    }
}