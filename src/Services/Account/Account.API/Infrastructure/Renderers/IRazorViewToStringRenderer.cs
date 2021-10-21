using System.Threading.Tasks;

namespace Account.API.Infrastructure.Renderers
{
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
