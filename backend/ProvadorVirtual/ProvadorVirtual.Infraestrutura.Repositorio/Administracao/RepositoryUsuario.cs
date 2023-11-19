using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;

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

        public Usuario GetUsuarioByEmailAndSenha(string email)
        {
            return _contex.Usuario.FirstOrDefault(prop => prop.Email.Equals(email));
        }

        public void SaveChanges()
        {
            _contex.SaveChanges();
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
            usuario.Senha = entity.Senha;

            _contex.SaveChanges();
        }
    }
}
