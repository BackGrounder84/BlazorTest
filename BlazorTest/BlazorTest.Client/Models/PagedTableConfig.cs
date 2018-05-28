using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Client.Models
{
    public class PagedTableConfig
    {
        public PagedTableConfig(string url)
        {
            this.Url = url;
        }

        public string EditUrl { get; set; }
        public string EditText { get; set; }

        public string DeleteUrl { get; set;}
        public string DeleteText { get; set; }

        public string Url { get; private set; }

        public List<TableColumn> Columns { get; set; } = new List<TableColumn>();
    }
}
