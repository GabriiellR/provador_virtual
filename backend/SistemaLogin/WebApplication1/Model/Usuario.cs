using System.Collections.Generic;

namespace WebApplication1.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int YearOfBirth { get; set; } = 2012; //ainda não terminamos o label do front
        public string password { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public int Numero { get; set; } 
        public string Complemento { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

    }
}
