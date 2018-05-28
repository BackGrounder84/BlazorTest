using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Client.Pages
{
    public class CounterSubBase : BlazorComponent
    {
        protected int currentCount = 0;

        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
