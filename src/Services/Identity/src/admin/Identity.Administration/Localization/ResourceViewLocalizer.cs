using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Localization;

namespace Identity.Administration.Localization;

public class ResourceViewLocalizer : IViewLocalizer, IViewContextAware
{
    public LocalizedString GetString(string name)
    {
        throw new NotImplementedException();
    }

    public LocalizedString GetString(string name, params object[] arguments)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        throw new NotImplementedException();
    }

    public LocalizedHtmlString this[string name] => throw new NotImplementedException();

    public LocalizedHtmlString this[string name, params object[] arguments] => throw new NotImplementedException();

    public void Contextualize(ViewContext viewContext)
    {
        throw new NotImplementedException();
    }
}