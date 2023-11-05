using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Repositorio;
using System.Runtime.ConstrainedExecution;

namespace ProvadorVirtual.Repositorio.Administracao
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        readonly Context _contex;
        public RepositoryUsuario(Context context) : base(context)
        {
            _contex = context;
        }

        public Usuario GetUsuarioByEmailAndSenha(string email, string senha)
        {
            return _contex.Usuario
                          .FirstOrDefault(prop => prop.Email.Equals(email) && prop.Senha.Equals(senha));
        }

        public void Update(Usuario entity)
        {
            var usuario = _contex.Usuario.FirstOrDefault(prop => prop.Id.Equals(entity.Id));
            usuario.Nome = entity.Nome;
            usuario.Email = entity.Email;
            usuario.Endereco = entity.Endereco;
            usuario.cep = entity.cep;
            usuario.Cidade = entity.Cidade;
            usuario.Bairro = entity.Bairro;
            usuario.Estado = entity.Estado;

            _contex.SaveChanges();
        }
    }
}
