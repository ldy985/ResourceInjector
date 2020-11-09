using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ldy985.ResourceInjection.TagHelpers
{
    [HtmlTargetElement("inject-resource", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class InjectResourceTagHelper : TagHelper
    {
        private readonly IResourceService _resourceService;

        public InjectResourceTagHelper(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public string Name { get; set; }

        //The name of the renderer to output to.
        public string RenderName { get; set; } = Constants.DefaultRenderName;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent content = await output.GetChildContentAsync().ConfigureAwait(false);

            _resourceService.AddResource(Name, RenderName, content);

            output.SuppressOutput();
        }
    }
}