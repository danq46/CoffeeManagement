using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Utilities
{
    public class FormMessage
    {
        public List<String> Errors { get; set; } = new List<String>();
        public List<String> Warnings { get; set; } = new List<String>();
        public List<String> Successes { get; set; } = new List<String>();
    }
}
