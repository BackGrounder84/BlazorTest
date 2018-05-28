using BlazorTest.Client.DataAccess.Interfaces;
using BlazorTest.Client.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorTest.Client.Shared
{
    public class PagedTableBase : BlazorComponent
    {
        [Parameter]
        PagedTableConfig Config { get; set; }

        [Inject]
        private IWebServiceDA webServiceDA { get; set; }

        protected List<JObject> Items { get; set; }

        protected RenderFragment DynamicTableContent { get; set; }

        protected RenderFragment DynamicTableHeader { get; set; }

        protected override async Task OnInitAsync()
        {
            this.Items = await this.webServiceDA.GetItems(this.Config.Url);

            this.DynamicTableHeader = builder =>
            {
                if (!string.IsNullOrEmpty(Config.EditUrl) || !string.IsNullOrEmpty(Config.DeleteUrl))
                {
                    builder.OpenElement(1, "th");
                    builder.CloseElement();
                }

                foreach (var column in this.Config.Columns)
                {
                    builder.OpenElement(1, "th");
                    builder.AddContent(2,column.Header);
                    builder.CloseElement();
                }
            };

            this.DynamicTableContent = builder =>
            {
                foreach (JObject obj in this.Items)
                {
                    builder.OpenElement(1, "tr");

                    //Add navigation
                    if (!string.IsNullOrEmpty(Config.EditUrl) || !string.IsNullOrEmpty(Config.DeleteUrl))
                    {
                        builder.OpenElement(1, "td");

                        if (!string.IsNullOrEmpty(Config.EditUrl))
                        {
                            builder.OpenElement(1, "a");
                            builder.AddAttribute(2, "href", $"{Config.EditUrl}+{obj["Id"]}");
                            builder.AddContent(3, this.Config.EditText);
                            builder.CloseElement();
                        }
                        if (!string.IsNullOrEmpty(Config.DeleteUrl))
                        {
                            if (!string.IsNullOrEmpty(this.Config.EditUrl))
                            {
                                builder.AddContent(1," | ");
                            }

                            builder.OpenElement(2, "a");
                            builder.AddAttribute(3, "href", $"{Config.DeleteUrl}+{obj["Id"]}");
                            builder.AddContent(4, this.Config.DeleteText);
                            builder.CloseElement();
                        }

                        builder.CloseElement();
                    }

                    //Add content
                    foreach (var column in this.Config.Columns)
                    {
                        builder.OpenElement(1, "td");
                        builder.AddContent(2, obj[column.PropertyName].ToString());
                        builder.CloseElement();
                    }

                    builder.CloseElement();
                }
            };
        }
    }
}
