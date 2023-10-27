using ProvadorVirtual.Nucleo.Interfaces.Repositorio;
using ProvadorVirtual.Nucleo.Interfaces.Services;

namespace ProvadorVirtual.Servicos.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>, IDisposable
    {
        readonly IRepositoryBase<TEntity> _repositoryBase;
        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void AddOrUpdate(TEntity entity)
        {
            _repositoryBase.AddOrUpdate(entity);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public List<TEntity> GetAll()
        {
           return _repositoryBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Remove(TEntity dto)
        {
            _repositoryBase.Remove(dto);
        }
    }
}
