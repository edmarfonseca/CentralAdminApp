namespace CentralAdminApp.Domain.Dtos
{
    public class ClienteRequest
    {
        public string? Nome { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
    }
}