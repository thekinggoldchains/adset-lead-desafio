using Common.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Validation;

namespace Project.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class FileController : ApiController
    {

        public FileController(ValidationContract validation)
            : base(validation)
        {
        }

        [Authorize]
        [HttpGet("{folder}/{fileName}")]
        public async Task<IActionResult> Get(string folder, string fileName)
        {
            try
            {
                //var url = await this._storage.GetUrl(fileName, folder);
                return Redirect("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ReturnException(ex);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<dynamic> Post(IFormFile file, string folder, bool rename = true)
        {
            try
            {
                    var fileName = file.FileName;
                    if (rename) fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));

                    //await this._storage.Upload(file, fileName, folder);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ReturnException(ex);
            }
        }

    }
}
