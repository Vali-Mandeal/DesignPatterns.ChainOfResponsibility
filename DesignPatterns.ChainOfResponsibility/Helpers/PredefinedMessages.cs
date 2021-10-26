using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility.Helpers
{
    public static class PredefinedMessages
    {
        public static string InitialMessage => @"This app will mimic a resilient API Request. 
Requests can fail randomly in any stage. We assume it's due to a 5xx error and retry until it works.

Choose an option:
    1) Make an insecure request (directly to cache and database)
    2) Make a secure request 
";
    }
}   
    