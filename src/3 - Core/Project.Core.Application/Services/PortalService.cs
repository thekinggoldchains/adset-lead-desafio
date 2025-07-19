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
    public class PortalService : ServiceBase<Portal>
    {
        private readonly PortalRepository _portalRepository;
        public PortalService(PortalRepository portalRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _portalRepository = portalRepository;
        }

        public async Task<dynamic> GetDataItem(PortalFilter filters)
        {
            return await _portalRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(PortalFilter filters)
        {
            return await _portalRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(PortalFilter filters)
        {
            return await _portalRepository.GetData(filters);
        }

        public async Task<dynamic> Save(PortalDto entity)
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
                model = _portalRepository.Update(model);
            else
            {
                
                model = _portalRepository.Add(model);
            }

            await _portalRepository.CommitAsync();

            return model;
        }

        public async Task Remove(PortalDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _portalRepository.Remove(model);
            await _portalRepository.CommitAsync();
        }
    }
}
