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
    public class VeiculoCorService : ServiceBase<VeiculoCor>
    {
        private readonly VeiculoCorRepository _veiculoCorRepository;
        public VeiculoCorService(VeiculoCorRepository veiculoCorRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _veiculoCorRepository = veiculoCorRepository;
        }

        public async Task<dynamic> GetDataItem(VeiculoCorFilter filters)
        {
            return await _veiculoCorRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(VeiculoCorFilter filters)
        {
            return await _veiculoCorRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(VeiculoCorFilter filters)
        {
            return await _veiculoCorRepository.GetData(filters);
        }

        public async Task<dynamic> Save(VeiculoCorDto entity)
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
                model = _veiculoCorRepository.Update(model);
            else
            {
                
                model = _veiculoCorRepository.Add(model);
            }

            await _veiculoCorRepository.CommitAsync();

            return model;
        }

        public async Task Remove(VeiculoCorDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _veiculoCorRepository.Remove(model);
            await _veiculoCorRepository.CommitAsync();
        }
    }
}
