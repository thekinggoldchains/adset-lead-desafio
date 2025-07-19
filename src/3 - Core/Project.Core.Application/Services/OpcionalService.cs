using AutoMapper;
using Common.Base;
using Common.Orm;
using Common.Orm.Extensions;
using Common.Validation;
using Project.Core.Application.Dtos;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;
using Project.Core.Infraestructure.Repositories;
using Project.Core.Infraestructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Project.Core.Application.Services
{
    public class OpcionalService : ServiceBase<Opcional>
    {
        private readonly OpcionalRepository _opcionalRepository;
        public OpcionalService(OpcionalRepository opcionalRepository, IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _opcionalRepository = opcionalRepository;
        }

        public async Task<dynamic> GetDataItem(OpcionalFilter filters)
        {
            return await _opcionalRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(OpcionalFilter filters)
        {
            return await _opcionalRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(OpcionalFilter filters)
        {
            return await _opcionalRepository.GetData(filters);
        }

        public async Task<dynamic> Save(OpcionalDto entity)
        {
            if (entity is null)
            {
                this._validation.Add("Objeto não enviado");
                return entity;
            }
            
            var model = await MapperDtoToDomain(entity);

            if (!ValidationDataAnnotation.Validate(model, this._validation))
                return entity;

            if (model.Id.IsSent())
                model = _opcionalRepository.Update(model);
            else
            {
                
                model = _opcionalRepository.Add(model);
            }

            await _opcionalRepository.CommitAsync();

            return model;
        }

        public async Task Remove(OpcionalDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _opcionalRepository.Remove(model);
            await _opcionalRepository.CommitAsync();
        }
    }
}
