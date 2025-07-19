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
    public class VeiculoPortalPacoteService : ServiceBase<VeiculoPortalPacote>
    {
        private readonly VeiculoPortalPacoteRepository _veiculoPortalPacoteRepository;
        public VeiculoPortalPacoteService(VeiculoPortalPacoteRepository veiculoPortalPacoteRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _veiculoPortalPacoteRepository = veiculoPortalPacoteRepository;
        }

        public async Task<dynamic> GetDataItem(VeiculoPortalPacoteFilter filters)
        {
            return await _veiculoPortalPacoteRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(VeiculoPortalPacoteFilter filters)
        {
            return await _veiculoPortalPacoteRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(VeiculoPortalPacoteFilter filters)
        {
            return await _veiculoPortalPacoteRepository.GetData(filters);
        }

        public async Task<dynamic> Save(VeiculoPortalPacoteDto entity)
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
                model = _veiculoPortalPacoteRepository.Update(model);
            else
            {
                
                model = _veiculoPortalPacoteRepository.Add(model);
            }

            await _veiculoPortalPacoteRepository.CommitAsync();

            return model;
        }

        public async Task Remove(VeiculoPortalPacoteDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _veiculoPortalPacoteRepository.Remove(model);
            await _veiculoPortalPacoteRepository.CommitAsync();
        }
    }
}
