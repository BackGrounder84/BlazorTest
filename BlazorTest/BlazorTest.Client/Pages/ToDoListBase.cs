using BlazorTest.Client.DataAccess.Interfaces;
using BlazorTest.Client.Models;
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
    public class ToDoListBase : PageBase
    {
        protected PagedTableConfig PagedTableConfig { get; private set; }

        [Inject]
        private IWebServiceDA WebServiceDA { get; set; }

        protected override async Task OnInitAsync()
        {
            this.PagedTableConfig = new PagedTableConfig("/api/SampleData/todoitem");
            this.PagedTableConfig.EditUrl = "todoitem/edit/";
            this.PagedTableConfig.EditText = "Edit";
            this.PagedTableConfig.DeleteUrl = "todoitem/do/";
            this.PagedTableConfig.DeleteText = "Do";
            this.PagedTableConfig.Columns.Add(new TableColumn("Created", nameof(ToDoItem.Created)));
            this.PagedTableConfig.Columns.Add(new TableColumn("Title", nameof(ToDoItem.Title)));
        }

        public void Do(int id)
        {
            Debug.WriteLine("Done");
            
        }

        public void OpenCreate()
        {
            this.UriHelper.NavigateTo("/todoitem/create");
        }
    }
}
