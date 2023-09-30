using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSolutionInterview.Models
{
    public class Root
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Item> items { get; set; }
    }
}