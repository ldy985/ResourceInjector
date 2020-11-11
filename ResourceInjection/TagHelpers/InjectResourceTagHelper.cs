using System.Threading.Tasks;
using ldy985.ResourceInjection.Abstracts;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ldy985.ResourceInjection.TagHelpers
{
    /// <summary>Injects a resource into a resource renderer.</summary>
    [HtmlTargetElement("inject-resource", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class InjectResourceTagHelper : TagHelper
    {
        private readonly IResourceService _resourceService;

        /// <inheritdoc />
        public InjectResourceTagHelper(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        /// <summary>The name of the resource.</summary>
        public string Name { get; set; }

        /// <summary>The name of the <see cref="RenderInjectedResourceTagHelper" /> the content should be rendered in.</summary>
        public string RenderName { get; set; } = Constants.DefaultRenderName;

        /// <inheritdoc />
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent content = await output.GetChildContentAsync().ConfigureAwait(false);

            _resourceService.AddResource(Name, RenderName, content);

            output.SuppressOutput();
        }
    }
}