using Common.Api;
using Common.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Application.Dtos;
using Project.Core.Application.Services;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoMarcaController : ApiController
    {
        private readonly VeiculoMarcaService _veiculoMarcaService;

        public VeiculoMarcaController(VeiculoMarcaService veiculoMarcaService,  ValidationContract validation)
            : base(validation)
        {
            this._veiculoMarcaService = veiculoMarcaService;
        }

        [Authorize("Administrator")]
        [HttpGet]
        public async Task<dynamic> Get([FromQuery] VeiculoMarcaFilter filters)
        {
            try
            {
                var result = await _veiculoMarcaService.GetData(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetOne")]
        public async Task<dynamic> GetOne([FromQuery] VeiculoMarcaFilter filters)
        {
            try
            {
                var result = await _veiculoMarcaService.GetOne(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetDataItem")]
        public async Task<dynamic> GetDataItem([FromQuery] VeiculoMarcaFilter filters)
        {
            try
            {
                var result = await _veiculoMarcaService.GetDataItem(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] VeiculoMarcaDto model)
        {
            try
            {
                var result = await _veiculoMarcaService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPut]
        public async Task<dynamic> Put([FromBody] VeiculoMarcaDto model)
        {
            try
            {
                var result = await _veiculoMarcaService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpDelete]
        public async Task<dynamic> Remove([FromQuery] VeiculoMarcaDto model)
        {
            try
            {
                await _veiculoMarcaService.Remove(model);
                return ReturnResponse(true);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
