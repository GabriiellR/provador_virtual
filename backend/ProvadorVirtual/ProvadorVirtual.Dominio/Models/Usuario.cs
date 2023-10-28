namespace ProvadorVirtual.Dominio.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string cep { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }       
    }
}
