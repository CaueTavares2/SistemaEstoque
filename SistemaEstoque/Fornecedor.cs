// Arquivo: Fornecedor.cs (NOVO)
namespace SistemaEstoque
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
    }
}