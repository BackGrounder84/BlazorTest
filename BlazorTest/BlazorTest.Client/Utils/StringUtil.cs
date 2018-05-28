using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Client.Utils
{
    public static class StringUtil
    {
        public static string Combine(string s1, string s2)
        {
            return string.Concat(s1, s2);
        }
    }
}
