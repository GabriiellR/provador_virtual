﻿namespace ProvadorVirtual.Dominio.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        
    }
}
