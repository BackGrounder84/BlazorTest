using BlazorTest.Client.DataAccess.Interfaces;
using BlazorTest.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Client.Pages
{
    public class DoToDoItemBase : PageBase
    {
        [Inject]
        private IWebServiceDA WebServiceDA { get; set; }

        [Parameter]
        string ItemId { get; set; }

        public ToDoItem Item { get; private set; }

        protected override async Task OnInitAsync()
        {
            this.Item = await this.WebServiceDA.GetToDoItemAsync(this.ItemId);
        }

        public async void Do()
        {
            await this.WebServiceDA.DeleteToDoItemAsync(this.Item);
            this.UriHelper.NavigateTo("/todoitem");
        }

        public void Cancel()
        {
            this.UriHelper.NavigateTo("/todoitem");
        }
    }
}
