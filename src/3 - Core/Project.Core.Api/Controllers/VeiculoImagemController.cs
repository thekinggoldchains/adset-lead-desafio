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
    public class VeiculoImagemController : ApiController
    {
        private readonly VeiculoImagemService _veiculoImagemService;

        public VeiculoImagemController(VeiculoImagemService veiculoImagemService,  ValidationContract validation)
            : base(validation)
        {
            this._veiculoImagemService = veiculoImagemService;
        }

        [Authorize("Administrator")]
        [HttpGet]
        public async Task<dynamic> Get([FromQuery] VeiculoImagemFilter filters)
        {
            try
            {
                var result = await _veiculoImagemService.GetData(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetOne")]
        public async Task<dynamic> GetOne([FromQuery] VeiculoImagemFilter filters)
        {
            try
            {
                var result = await _veiculoImagemService.GetOne(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetDataItem")]
        public async Task<dynamic> GetDataItem([FromQuery] VeiculoImagemFilter filters)
        {
            try
            {
                var result = await _veiculoImagemService.GetDataItem(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] VeiculoImagemDto model)
        {
            try
            {
                var result = await _veiculoImagemService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPut]
        public async Task<dynamic> Put([FromBody] VeiculoImagemDto model)
        {
            try
            {
                var result = await _veiculoImagemService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpDelete]
        public async Task<dynamic> Remove([FromQuery] VeiculoImagemDto model)
        {
            try
            {
                await _veiculoImagemService.Remove(model);
                return ReturnResponse(true);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
