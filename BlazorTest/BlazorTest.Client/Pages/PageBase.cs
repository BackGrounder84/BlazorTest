using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Client.Pages
{
    public class PageBase : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }
    }
}
