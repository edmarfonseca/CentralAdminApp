namespace CentralAdminApp.Domain.Dtos
{
    public class UfResponse
    {
        public int Id { get; set; }
        public string? Sigla { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}