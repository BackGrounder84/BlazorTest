using BlazorTest.Client.DataAccess.Interfaces;
using BlazorTest.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Client.Pages
{
    public class EditToDoItemBase : PageBase
    {
        public string Title { get; private set; }

        public ToDoItem ToDoItem { get; set; }

        [Inject]
        public IWebServiceDA WebServiceDA { get; set; }

        [Parameter]
        string ItemId { get; set; }

        protected async override Task OnInitAsync()
        {
            if (string.IsNullOrEmpty(ItemId))
            {
                Title = "Create new item";
                this.ToDoItem = new ToDoItem() { Created = DateTime.Now };
            }
            else
            {
                Title = "Edit item";
                Debug.WriteLine("Id = " + ItemId);
                this.ToDoItem = await this.WebServiceDA.GetToDoItemAsync(ItemId);
            }
        }

        public async void Save()
        {
            if (this.ToDoItem.Id == 0)
            {
                await this.WebServiceDA.SaveToDoItemAsync(this.ToDoItem);
            }
            else
            {
                await this.WebServiceDA.UpdateToDoItemAsync(this.ToDoItem);
            }

            this.UriHelper.NavigateTo("/todoitem");
        }

        public void Cancel()
        {
            this.UriHelper.NavigateTo("/todoitem");
        }
    }
}
