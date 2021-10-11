using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Upload.API.Infrastructure.ActionResults
{
    public class InternalServerErrorObjectResult: ObjectResult
    {
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
