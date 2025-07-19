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
    public class OpcionalVeiculoController : ApiController
    {
        private readonly OpcionalVeiculoService _opcionalVeiculoService;

        public OpcionalVeiculoController(OpcionalVeiculoService opcionalVeiculoService,  ValidationContract validation)
            : base(validation)
        {
            this._opcionalVeiculoService = opcionalVeiculoService;
        }

        [Authorize("Administrator")]
        [HttpGet]
        public async Task<dynamic> Get([FromQuery] OpcionalVeiculoFilter filters)
        {
            try
            {
                var result = await _opcionalVeiculoService.GetData(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetOne")]
        public async Task<dynamic> GetOne([FromQuery] OpcionalVeiculoFilter filters)
        {
            try
            {
                var result = await _opcionalVeiculoService.GetOne(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetDataItem")]
        public async Task<dynamic> GetDataItem([FromQuery] OpcionalVeiculoFilter filters)
        {
            try
            {
                var result = await _opcionalVeiculoService.GetDataItem(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] OpcionalVeiculoDto model)
        {
            try
            {
                var result = await _opcionalVeiculoService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPut]
        public async Task<dynamic> Put([FromBody] OpcionalVeiculoDto model)
        {
            try
            {
                var result = await _opcionalVeiculoService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpDelete]
        public async Task<dynamic> Remove([FromQuery] OpcionalVeiculoDto model)
        {
            try
            {
                await _opcionalVeiculoService.Remove(model);
                return ReturnResponse(true);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
