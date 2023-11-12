using Microsoft.EntityFrameworkCore;
using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio.Models;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;

namespace ProvadorVirtual.Repositorio.Administracao
{
    public class RepositoryFavoritos : RepositoryBase<Favoritos>, IRepositoryFavoritos
    {
        readonly Context _context;
        public RepositoryFavoritos(Context context) : base(context)
        {
            _context = context;
        }

        public override void AddOrUpdate(Favoritos entity)
        {
            var favorito = _context.Favoritos
                                   .FirstOrDefault(f => f.UsuarioId.Equals(entity.UsuarioId)
                                                        && f.ProdutoId.Equals(entity.ProdutoId));

            if (favorito is null)
            {
                _context.Favoritos.Update(entity);
                _context.SaveChanges();
            }
        }

        public List<Favoritos> GetByUsuario(int usuarioId)
        {
            return _context.Favoritos.Where(prop => prop.UsuarioId.Equals(usuarioId)).Include(prop=>prop.Produto).ToList();
        }
    }
}
