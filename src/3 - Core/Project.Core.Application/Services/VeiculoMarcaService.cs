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
    public class VeiculoMarcaService : ServiceBase<VeiculoMarca>
    {
        private readonly VeiculoMarcaRepository _veiculoMarcaRepository;
        public VeiculoMarcaService(VeiculoMarcaRepository veiculoMarcaRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _veiculoMarcaRepository = veiculoMarcaRepository;
        }

        public async Task<dynamic> GetDataItem(VeiculoMarcaFilter filters)
        {
            return await _veiculoMarcaRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(VeiculoMarcaFilter filters)
        {
            return await _veiculoMarcaRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(VeiculoMarcaFilter filters)
        {
            return await _veiculoMarcaRepository.GetData(filters);
        }

        public async Task<dynamic> Save(VeiculoMarcaDto entity)
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
                model = _veiculoMarcaRepository.Update(model);
            else
            {
                
                model = _veiculoMarcaRepository.Add(model);
            }

            await _veiculoMarcaRepository.CommitAsync();

            return model;
        }

        public async Task Remove(VeiculoMarcaDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _veiculoMarcaRepository.Remove(model);
            await _veiculoMarcaRepository.CommitAsync();
        }
    }
}
