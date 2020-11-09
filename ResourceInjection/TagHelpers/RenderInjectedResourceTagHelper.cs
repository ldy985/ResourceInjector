using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ldy985.ResourceInjection.TagHelpers
{
    [HtmlTargetElement("render-injected-resource", TagStructure = TagStructure.WithoutEndTag)]
    public class RenderInjectedResourceTagHelper : TagHelper
    {
        private readonly IResourceService _resourceService;

        /// <inheritdoc />
        public RenderInjectedResourceTagHelper(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public string Name { get; set; } = Constants.DefaultRenderName;

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