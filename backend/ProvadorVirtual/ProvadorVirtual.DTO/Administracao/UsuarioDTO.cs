﻿namespace ProvadorVirtual.DTO.Administracao
{
    public class UsuarioDTO : BaseDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

    }
}