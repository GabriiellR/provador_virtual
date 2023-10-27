using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Aplicacao.Interfaces.Administracao
{
    public interface IApplicationServiceTokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
