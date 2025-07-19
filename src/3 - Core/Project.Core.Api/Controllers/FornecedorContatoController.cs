using Common.Api;
using Common.Base;
using Common.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Application.Dtos;
using Project.Core.Application.Services;
using Project.Core.Infraestructure.Filters;
using System.Net;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorContatoController : ApiController
    {
        private readonly FornecedorContatoService _fornecedorContatoService;

        public FornecedorContatoController(FornecedorContatoService fornecedorContatoService, ValidationContract validation)
            :base(validation)
        {
            this._fornecedorContatoService = fornecedorContatoService;
        }

        [Authorize("Administrator")]
        [HttpGet]
        public async Task<dynamic> Get([FromQuery] FornecedorContatoFilter filters)
        {
            try
            {
                var result = await _fornecedorContatoService.GetData(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetOne")]
        public async Task<dynamic> GetOne([FromQuery] FornecedorContatoFilter filters)
        {
            try
            {
                var result = await _fornecedorContatoService.GetOne(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetDataItem")]
        public async Task<dynamic> GetDataItem([FromQuery] FornecedorContatoFilter filters)
        {
            try
            {
                var result = await _fornecedorContatoService.GetDataItem(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] FornecedorContatoDto model)
        {
            try
            {
                var result = await _fornecedorContatoService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPut]
        public async Task<dynamic> Put([FromBody] FornecedorContatoDto model)
        {
            try
            {
                var result = await _fornecedorContatoService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpDelete]
        public async Task<dynamic> Remove([FromQuery] FornecedorContatoDto model)
        {
            try
            {
                await _fornecedorContatoService.Remove(model);
                return ReturnResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
