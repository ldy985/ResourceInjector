using System.Collections.Generic;
using ldy985.ResourceInjection.Abstracts;
using Microsoft.AspNetCore.Html;

namespace ldy985.ResourceInjection
{
    /// <inheritdoc />
    public class StrictResourceService : IResourceService
    {
        private readonly Dictionary<string, Dictionary<string, IHtmlContent>> _store = new Dictionary<string, Dictionary<string, IHtmlContent>>();

        /// <inheritdoc />
        public void AddResource(string name, string rendererName, IHtmlContent resource)
        {
            if (_store.TryGetValue(rendererName, out Dictionary<string, IHtmlContent> rendererContent))
                rendererContent.Add(name, resource);
            else
            {
                _store.Add(rendererName, new Dictionary<string, IHtmlContent>
                {
                    { name, resource }
                });
            }
        }

        /// <inheritdoc />
        public IEnumerable<IHtmlContent> GetAllResources(string rendererName)
        {
            return _store[rendererName].Values;
        }
    }
}