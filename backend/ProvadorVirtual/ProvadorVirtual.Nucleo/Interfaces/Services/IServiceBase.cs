namespace ProvadorVirtual.Nucleo.Interfaces.Services
{
    public interface IServiceBase<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void AddOrUpdate(TEntity dto);
        void Remove(TEntity dto);
        void Dispose();
    }
}