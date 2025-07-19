using AutoMapper;
using Common.Base;
using Common.Orm;
using Common.Orm.Extensions;
using Project.Core.Application.Dtos;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;
using Project.Core.Infraestructure.Repositories;
using Project.Core.Infraestructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Common.Validation;

namespace Project.Core.Application.Services
{
    public class FornecedorContatoService : ServiceBase<FornecedorContato>
    {
        private readonly FornecedorContatoRepository _fornecedorContatoRepository;
        public FornecedorContatoService(FornecedorContatoRepository fornecedorContatoRepository, IUnitOfWork uow, IMapper mapper, ValidationContract validation)
            : base(uow, validation, mapper)
        {
            _fornecedorContatoRepository = fornecedorContatoRepository;
        }

        public async Task<dynamic> GetDataItem(FornecedorContatoFilter filters)
        {
            return await _fornecedorContatoRepository.GetDataItem(filters);
        }

        public async Task<dynamic> GetOne(FornecedorContatoFilter filters)
        {
            return await _fornecedorContatoRepository.GetOne(filters);
        }

        public async Task<dynamic> GetData(FornecedorContatoFilter filters)
        {
            return await _fornecedorContatoRepository.GetData(filters);
        }

        public async Task<dynamic> Save(FornecedorContatoDto entity)
        {

            var model = await MapperDtoToDomain(entity);

            if (model.Id.IsSent())
                model = _fornecedorContatoRepository.Update(model);
            else
            {
                
                model = _fornecedorContatoRepository.Add(model);
            }

            await _fornecedorContatoRepository.CommitAsync();

            return model;
        }

        public async Task Remove(FornecedorContatoDto entity)
        {
            var model = await MapperDtoToDomain(entity);
            _fornecedorContatoRepository.Remove(model);
            await _fornecedorContatoRepository.CommitAsync();
        }
    }
}
