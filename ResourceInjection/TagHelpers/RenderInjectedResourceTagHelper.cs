using ldy985.ResourceInjection.Abstracts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ldy985.ResourceInjection.TagHelpers
{
    /// <summary>Renders the content captured in an <see cref="InjectResourceTagHelper" />.</summary>
    [HtmlTargetElement("render-injected-resource", TagStructure = TagStructure.WithoutEndTag)]
    public class RenderInjectedResourceTagHelper : TagHelper
    {
        private readonly IResourceService _resourceService;

        /// <inheritdoc />
        public RenderInjectedResourceTagHelper(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        /// <summary>The name of the renderer.</summary>
        public string Name { get; set; } = Constants.DefaultRenderName;

        /// <inheritdoc />
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            foreach (IHtmlContent resource in _resourceService.GetAllResources(Name))
            {
                output.Content.AppendHtml(resource);
            }
        }
    }
}