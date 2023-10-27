using ProvadorVirtual.Dominio;
using ProvadorVirtual.Infraestrutura.Data;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio;

namespace ProvadorVirtual.Infraestrutura.Repositorio
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : BaseModel
    {
        readonly Context _context;
        public RepositoryBase(Context context)
        {
            _context = context;
        }

        public void AddOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(prop => prop.Id.Equals(id));
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
