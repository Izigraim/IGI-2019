using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingSystem.TagHelpers
{
    public class VkTagHelper : TagHelper
    {
        private const string address = "https://vk.com/izigraim";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", address);
            output.Content.SetContent("Vkontakte");
        }
    }
    
    public class SocialsTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var target = await output.GetChildContentAsync();
            var content = "<p>Социальные сети: </p>" + target.GetContent();
            output.Content.SetHtmlContent(content);
        }
    }
}
