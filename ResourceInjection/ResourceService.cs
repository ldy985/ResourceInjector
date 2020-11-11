using System.Collections.Generic;
using ldy985.ResourceInjection.Abstracts;
using Microsoft.AspNetCore.Html;

namespace ldy985.ResourceInjection
{
    /// <inheritdoc />
    public class ResourceService : IResourceService
    {
        private readonly Dictionary<string, Dictionary<string, IHtmlContent>> _store = new Dictionary<string, Dictionary<string, IHtmlContent>>();

        /// <inheritdoc />
        public void AddResource(string name, string rendererName, IHtmlContent resource)
        {
            if (_store.TryGetValue(rendererName, out Dictionary<string, IHtmlContent> rendererContent))
            {
#if NETSTANDARD2_1
                rendererContent.TryAdd(name, resource);
#else
                if (!rendererContent.ContainsKey(name))
                    rendererContent.Add(name, resource);
#endif
            }
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