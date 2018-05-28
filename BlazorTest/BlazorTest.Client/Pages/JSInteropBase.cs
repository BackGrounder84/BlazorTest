using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Client.Pages
{
    public class JSInteropBase : BlazorComponent
    {
        protected string CombinedString { get; private set; } = string.Empty;

        protected string FirstString { get; set; } = string.Empty;

        protected string SecondString { get; set; } = string.Empty;

        protected void SayHello()
        {
            RegisteredFunction.Invoke<bool>("say");
        }

        protected void Combine()
        {
            this.CombinedString = RegisteredFunction.Invoke<string>("combine", new { firstString = FirstString, secondString = SecondString});
        }
    }
}
