using System.Collections.Generic;
using Microsoft.AspNetCore.Html;

namespace ldy985.ResourceInjection.Abstracts
{
    /// <summary>A service that stores the content that should be rendered.</summary>
    public interface IResourceService
    {
        /// <summary>Adds a resource.</summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="rendererName">The name of the renderer that should be rendered to.</param>
        /// <param name="resource"></param>
        void AddResource(string name, string rendererName, IHtmlContent resource);

        /// <summary>Gets all the resources for a given renderer.</summary>
        /// <param name="rendererName"></param>
        /// <returns></returns>
        IEnumerable<IHtmlContent> GetAllResources(string rendererName);
    }
}