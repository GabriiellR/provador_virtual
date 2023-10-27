namespace ProvadorVirtual.Aplicacao.Interfaces
{
    public interface IApplicationServiceBase<TDTO, Tentity>
    {
        List<TDTO> GetAll();
        TDTO GetById(int id);
        TDTO AddOrUpdate(TDTO dto);
        void Remove(TDTO dto);
    }
}