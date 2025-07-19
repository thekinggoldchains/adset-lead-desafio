using AutoMapper;
using Common.Orm;
using Common.Validation;

namespace Common.Base
{
    public abstract class ServiceBase<TClass>
        where TClass : class
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _uow;
        protected readonly ValidationContract _validation;

        public ServiceBase(IUnitOfWork uow, ValidationContract validation, IMapper mapper )
        {
            _uow = uow;
            _mapper = mapper;
            _validation = validation;
        }

        protected async virtual Task<TClass> MapperDtoToDomain<TDS>(TDS dto) where TDS : class
        {
            return await Task.Run(() =>
            {
                var result = _mapper.Map<TDS, TClass>(dto);
                return result;
            });
        }

        protected async virtual Task<TDS> MapperDomainToDto<TDS>(TClass model) where TDS : class
        {
            return await Task.Run(() =>
            {
                return _mapper.Map<TClass, TDS>(model);
            });
        }

        protected async virtual Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<TClass> models) where TDS : class
        {
            return await Task.Run(() =>
            {
                return _mapper.Map<IEnumerable<TClass>, IEnumerable<TDS>>(models);
            });
        }

    }

}
