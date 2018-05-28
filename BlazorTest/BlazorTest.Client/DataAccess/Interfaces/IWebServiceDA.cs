using BlazorTest.Shared;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Client.DataAccess.Interfaces
{
    public interface IWebServiceDA
    {
        Task<WeatherForecast[]> GetWeatherForecastsAsync();

        Task<ToDoItem[]> GetToDoItemsAsync();

        Task<ToDoItem> GetToDoItemAsync(string itemId);

        Task SaveToDoItemAsync(ToDoItem item);

        Task UpdateToDoItemAsync(ToDoItem item);
        Task DeleteToDoItemAsync(ToDoItem item);

        Task<List<JObject>> GetItems(string url);
    }
}
