using System.ComponentModel.DataAnnotations.Schema;

namespace CentralAdminApp.Domain.Dtos
{
    public class SistemaResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Url { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}