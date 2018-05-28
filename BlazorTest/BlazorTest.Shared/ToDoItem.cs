using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class ToDoItem
    {
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public int Id { get; set; }
    }
}
