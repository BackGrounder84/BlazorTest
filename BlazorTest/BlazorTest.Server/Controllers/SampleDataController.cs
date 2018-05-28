using BlazorTest.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<ToDoItem> itemList;

        [HttpGet("weatherforecast")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("todoitem")]
        public IEnumerable<ToDoItem> ToDoItems()
        {
            if (itemList == null)
            {
                itemList = new List<ToDoItem>();

                itemList.Add(new ToDoItem() { Id = 1, Created = DateTime.Now, Title = "Test 1" });
                itemList.Add(new ToDoItem() { Id = 2, Created = DateTime.Now.AddDays(-2), Title = "Test 2" });
                itemList.Add(new ToDoItem() { Id = 3, Created = DateTime.Now.AddDays(-1), Title = "Test 3" });
                itemList.Add(new ToDoItem() { Id = 4, Created = DateTime.Now, Title = "Test 4" });
                itemList.Add(new ToDoItem() { Id = 5, Created = DateTime.Now.AddDays(-5), Title = "Test 5" });
            }

            return itemList.Where(e => !e.IsDone).OrderByDescending(e => e.Created);
        }

        [HttpGet("todoitem/{id}")]
        public ToDoItem ToDoItem([FromRoute]int id)
        {
            return itemList.Where(e => e.Id == id).OrderByDescending(e => e.Created).FirstOrDefault();
        }

        [HttpPost("todoitem")]
        public ActionResult SaveItem([FromBody]ToDoItem item)
        {
            int id = itemList.Max(e => e.Id) + 1;

            item.Id = id;
            itemList.Add(item);

            return this.Ok(id);
        }

        [HttpPut("todoitem/{id}")]
        public ActionResult UpdateItem([FromBody]ToDoItem item)
        {
            var olditem = itemList.First(e => e.Id == item.Id);

            olditem.Title = item.Title;

            return this.Ok(olditem);
        }

        [HttpDelete("todoitem/{id}")]
        public ActionResult DeleteItem([FromRoute] string id)
        {
            var itemId = int.Parse(id);

            itemList.First(e => e.Id == itemId).IsDone = true;

            return this.Ok();
        }
    }
}
