using BlazorTest.Client.DataAccess.Interfaces;
using BlazorTest.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Client.DataAccess
{
    public class WebServiceDA : IWebServiceDA
    {
        private HttpClient client;

        private readonly string baseUrl = "/api/SampleData";
        private readonly string toDoItemResource = "todoitem";
        private readonly string weatherForecastResource = "weatherforecast";

        public WebServiceDA(HttpClient client)
        {
            this.client = client;
        }

        public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
        {
            try
            {
                return await client.GetJsonAsync<WeatherForecast[]>($"{this.baseUrl}/{this.weatherForecastResource}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ToDoItem[]> GetToDoItemsAsync()
        {
            try
            {
                return await this.client.GetJsonAsync<ToDoItem[]>($"{this.baseUrl}/{this.toDoItemResource}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"My Error: {ex.Message}");
                throw;
            }
        }

        public async Task<ToDoItem> GetToDoItemAsync(string itemId)
        {
            return await this.client.GetJsonAsync<ToDoItem>($"{this.baseUrl}/{this.toDoItemResource}/{itemId}");
        }

        public async Task SaveToDoItemAsync(ToDoItem item)
        {
            await this.client.PostJsonAsync($"{this.baseUrl}/{this.toDoItemResource}", item);
        }

        public async Task UpdateToDoItemAsync(ToDoItem item)
        {
            await this.client.PutJsonAsync($"{this.baseUrl}/{this.toDoItemResource}/{item.Id}", item);
        }

        public async Task DeleteToDoItemAsync(ToDoItem item)
        {
            await this.client.DeleteAsync($"{this.baseUrl}/{this.toDoItemResource}/{item.Id}");
        }

        public async Task<List<JObject>> GetItems(string url)
        {
            var array = new List<JObject>();
            try
            {
                var jarray = JArray.Parse(await this.client.GetStringAsync(url));

                foreach(var obj in jarray.Children<JObject>())
                {
                    array.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("My Error: " + ex.Message);
            }

            return array;
        }
    }
}
