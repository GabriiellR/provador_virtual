namespace ProvadorVirtual.Nucleo.Interfaces.Repositorio
{
    public interface IRepositoryBase<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void AddOrUpdate(TEntity entity);
        void Remove(TEntity entity);
        void Dispose();
    }
}
