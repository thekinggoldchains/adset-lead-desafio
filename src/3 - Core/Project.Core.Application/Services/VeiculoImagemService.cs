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
    public class VeiculoImagemService : ServiceBase<VeiculoImagem>
    {
        private readonly VeiculoImagemRepository _veiculoImagemRepository;
        public VeiculoImagemService(VeiculoImagemRepository veiculoImagemRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _veiculoImagemRepository = veiculoImagemRepository;
        }

        public async Task<dynamic> GetDataItem(VeiculoImagemFilter filters)
        {
            return await _veiculoImagemRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(VeiculoImagemFilter filters)
        {
            return await _veiculoImagemRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(VeiculoImagemFilter filters)
        {
            return await _veiculoImagemRepository.GetData(filters);
        }

        public async Task<dynamic> Save(VeiculoImagemDto entity)
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
                model = _veiculoImagemRepository.Update(model);
            else
            {
                
                model = _veiculoImagemRepository.Add(model);
            }

            await _veiculoImagemRepository.CommitAsync();

            return model;
        }

        public async Task Remove(VeiculoImagemDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _veiculoImagemRepository.Remove(model);
            await _veiculoImagemRepository.CommitAsync();
        }
    }
}
