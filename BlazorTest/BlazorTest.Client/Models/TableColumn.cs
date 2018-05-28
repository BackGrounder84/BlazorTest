using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorTest.Client.Models
{
    public class TableColumn
    {
        public string Header { get; private set; }

        public TableColumn(string header, string propName)
        {
            this.Header = header;
            this.PropertyName = propName;
        }

        public string PropertyName { get; set; }

        
    } 
}
