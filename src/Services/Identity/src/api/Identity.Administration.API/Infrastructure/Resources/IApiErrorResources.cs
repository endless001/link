using Identity.Administration.API.Infrastructure.Exceptions;

namespace Identity.Administration.API.Infrastructure.Resources;

public interface IApiErrorResources
{
    ApiError CannotSetId();
}