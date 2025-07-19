using AutoMapper;
using Common.Base;
using Common.Orm;
using Common.Orm.Extensions;
using Common.Validation;
using Project.Core.Application.Dtos;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;
using Project.Core.Infraestructure.Repositories;

namespace Project.Core.Application.Services
{
    public class OpcionalVeiculoService : ServiceBase<OpcionalVeiculo>
    {
        private readonly OpcionalVeiculoRepository _opcionalVeiculoRepository;
        public OpcionalVeiculoService(OpcionalVeiculoRepository opcionalVeiculoRepository, IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _opcionalVeiculoRepository = opcionalVeiculoRepository;
        }

        public async Task<dynamic> GetDataItem(OpcionalVeiculoFilter filters)
        {
            return await _opcionalVeiculoRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(OpcionalVeiculoFilter filters)
        {
            return await _opcionalVeiculoRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(OpcionalVeiculoFilter filters)
        {
            return await _opcionalVeiculoRepository.GetData(filters);
        }

        public async Task<dynamic> Save(OpcionalVeiculoDto entity)
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
                model = _opcionalVeiculoRepository.Update(model);
            else
            {
                
                model = _opcionalVeiculoRepository.Add(model);
            }

            await _opcionalVeiculoRepository.CommitAsync();

            return model;
        }

        public async Task Remove(OpcionalVeiculoDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _opcionalVeiculoRepository.Remove(model);
            await _opcionalVeiculoRepository.CommitAsync();
        }
    }
}
