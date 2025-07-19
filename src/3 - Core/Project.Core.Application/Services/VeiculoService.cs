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
    public class VeiculoService : ServiceBase<Veiculo>
    {
        private readonly VeiculoRepository _veiculoRepository;
        public VeiculoService(VeiculoRepository veiculoRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<dynamic> GetDataItem(VeiculoFilter filters)
        {
            return await _veiculoRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(VeiculoFilter filters)
        {
            return await _veiculoRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(VeiculoFilter filters)
        {
            return await _veiculoRepository.GetData(filters);
        }

        public async Task<dynamic> Save(VeiculoDto entity)
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
                model = _veiculoRepository.Update(model);
            else
            {
                
                model = _veiculoRepository.Add(model);
            }

            await _veiculoRepository.CommitAsync();

            return model;
        }

        public async Task Remove(VeiculoDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _veiculoRepository.Remove(model);
            await _veiculoRepository.CommitAsync();
        }
    }
}
