

using Microsoft.AspNetCore.Mvc;

namespace Identity.Administration.Controllers
{
    public class ApiResourcesController : ControllerBase
    {
        private readonly IApiResourceService _apiResourceService;
        private readonly IApiErrorResources _errorResources;

        public ApiResourcesController(IApiResourceService apiResourceService, IApiErrorResources errorResources)
        {
            _apiResourceService = apiResourceService;
            _errorResources = errorResources;
        }
       
    }
}