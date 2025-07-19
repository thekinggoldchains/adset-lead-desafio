using Common.Validation;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Api
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ValidationContract _validation;

        public ApiController(ValidationContract validation)
        {
            _validation = validation;
        }
        protected IActionResult ReturnException(Exception ex)
        {
            return ReturnResponse(null, new string[] { ex.ToString() });
        }

        protected IActionResult ReturnResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors.Select(_ => _.ErrorMessage)).ToArray();
            return ReturnResponse(null, errors);
        }

        protected IActionResult ReturnResponse(object data = null)
        {
            var result = new HttpResult<object>(data, _validation.Notifications);
            return StatusCode((int)result.StatusCode, result);
        }

        protected IActionResult ReturnResponse(object data, string[] errors)
        {
            var result = new HttpResult<object>(data, errors);
            return StatusCode((int)result.StatusCode, result);
        }


    }

}
