using BlazorTest.Client.DataAccess;
using BlazorTest.Client.DataAccess.Interfaces;
using BlazorTest.Client.Pages;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorTest.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // Add any custom services here
                services.Add(ServiceDescriptor.Singleton<IWebServiceDA, WebServiceDA>());
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
