using AutoMapper;
using ProvadorVirtual.Aplicacao.Interfaces;
using ProvadorVirtual.Nucleo.Interfaces.Services;

namespace ProvadorVirtual.Aplicacao.Services
{
    public abstract class ApplicationServiceBase<TDTO, TEntity> : IApplicationServiceBase<TDTO, TEntity>, IDisposable
    {
        readonly IMapper _mapper;
        readonly IServiceBase<TEntity> _serviceBase;
        public ApplicationServiceBase(IMapper mapper, IServiceBase<TEntity> serviceBase)
        {
            _mapper = mapper;
            _serviceBase = serviceBase;
        }

        public virtual TDTO AddOrUpdate(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _serviceBase.AddOrUpdate(entity);
            return _mapper.Map<TDTO>(entity); 
        }

        public List<TDTO> GetAll()
        {
            var entityList = _serviceBase.GetAll();
            return _mapper.Map<List<TDTO>>(entityList);
        }

        public TDTO GetById(int id)
        {
            var entity = _serviceBase.GetById(id);
            return _mapper.Map<TDTO>(entity);
        }

        public void Remove(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _serviceBase.Remove(entity);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
