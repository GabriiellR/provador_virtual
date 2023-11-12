using ProvadorVirtual.Data;
using ProvadorVirtual.Dominio;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio;

namespace ProvadorVirtual.Repositorio
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : BaseModel
    {
        readonly Context _context;
        public RepositoryBase(Context context)
        {
            _context = context;
        }

        public virtual void AddOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(prop => prop.Id.Equals(id));
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
