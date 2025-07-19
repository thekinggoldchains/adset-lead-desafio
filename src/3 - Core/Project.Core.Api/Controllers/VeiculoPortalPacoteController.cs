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
    public class VeiculoPortalPacoteController : ApiController
    {
        private readonly VeiculoPortalPacoteService _veiculoPortalPacoteService;

        public VeiculoPortalPacoteController(VeiculoPortalPacoteService veiculoPortalPacoteService,  ValidationContract validation)
            : base(validation)
        {
            this._veiculoPortalPacoteService = veiculoPortalPacoteService;
        }

        [Authorize("Administrator")]
        [HttpGet]
        public async Task<dynamic> Get([FromQuery] VeiculoPortalPacoteFilter filters)
        {
            try
            {
                var result = await _veiculoPortalPacoteService.GetData(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetOne")]
        public async Task<dynamic> GetOne([FromQuery] VeiculoPortalPacoteFilter filters)
        {
            try
            {
                var result = await _veiculoPortalPacoteService.GetOne(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpGet("GetDataItem")]
        public async Task<dynamic> GetDataItem([FromQuery] VeiculoPortalPacoteFilter filters)
        {
            try
            {
                var result = await _veiculoPortalPacoteService.GetDataItem(filters);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] VeiculoPortalPacoteDto model)
        {
            try
            {
                var result = await _veiculoPortalPacoteService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpPut]
        public async Task<dynamic> Put([FromBody] VeiculoPortalPacoteDto model)
        {
            try
            {
                var result = await _veiculoPortalPacoteService.Save(model);
                return ReturnResponse(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [Authorize("Administrator")]
        [HttpDelete]
        public async Task<dynamic> Remove([FromQuery] VeiculoPortalPacoteDto model)
        {
            try
            {
                await _veiculoPortalPacoteService.Remove(model);
                return ReturnResponse(true);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
