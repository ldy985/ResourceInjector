using System.Collections.Generic;
using Microsoft.AspNetCore.Html;

namespace ldy985.ResourceInjection
{
    public interface IResourceService
    {
        void AddResource(string name, string rendererName, IHtmlContent resource);
        IEnumerable<IHtmlContent> GetAllResources(string rendererName);
    }
}