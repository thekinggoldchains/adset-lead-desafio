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
    public class PacoteService : ServiceBase<Pacote>
    {
        private readonly PacoteRepository _pacoteRepository;
        public PacoteService(PacoteRepository pacoteRepository,  IUnitOfWork uow, ValidationContract validation, IMapper mapper)
            : base(uow, validation, mapper)
        {
            _pacoteRepository = pacoteRepository;
        }

        public async Task<dynamic> GetDataItem(PacoteFilter filters)
        {
            return await _pacoteRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(PacoteFilter filters)
        {
            return await _pacoteRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(PacoteFilter filters)
        {
            return await _pacoteRepository.GetData(filters);
        }

        public async Task<dynamic> Save(PacoteDto entity)
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
                model = _pacoteRepository.Update(model);
            else
            {
                
                model = _pacoteRepository.Add(model);
            }

            await _pacoteRepository.CommitAsync();

            return model;
        }

        public async Task Remove(PacoteDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _pacoteRepository.Remove(model);
            await _pacoteRepository.CommitAsync();
        }
    }
}
