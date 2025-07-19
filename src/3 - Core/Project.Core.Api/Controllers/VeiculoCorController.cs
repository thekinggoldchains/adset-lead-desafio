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
    public class VeiculoCorController : ApiController
    {
        private readonly VeiculoCorService _veiculoCorService;

        public VeiculoCorController(VeiculoCorService veiculoCorService,  ValidationContract validation)
            : base(validation)
        {
            this._veiculoCorService = veiculoCorService;
        }

        [Authorize("Administrator")]
        [HttpGet]
        public async Task<dynamic> Get([FromQuery] VeiculoCorFilter filters)
        {
            try
            {
                var result = await _veiculoCorService.GetData(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetOne")]
        public async Task<dynamic> GetOne([FromQuery] VeiculoCorFilter filters)
        {
            try
            {
                var result = await _veiculoCorService.GetOne(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetDataItem")]
        public async Task<dynamic> GetDataItem([FromQuery] VeiculoCorFilter filters)
        {
            try
            {
                var result = await _veiculoCorService.GetDataItem(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] VeiculoCorDto model)
        {
            try
            {
                var result = await _veiculoCorService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPut]
        public async Task<dynamic> Put([FromBody] VeiculoCorDto model)
        {
            try
            {
                var result = await _veiculoCorService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpDelete]
        public async Task<dynamic> Remove([FromQuery] VeiculoCorDto model)
        {
            try
            {
                await _veiculoCorService.Remove(model);
                return ReturnResponse(true);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
