using Identity.Administration.Infrastructure.Exceptions;

namespace Identity.Administration.Infrastructure.Resources;

public interface IApiErrorResources
{
    ApiError CannotSetId();
}