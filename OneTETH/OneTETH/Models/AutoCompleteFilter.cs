using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTETH.Models
{ 
    public class Where
    {
        public bool IsComplex { get; set; }
        public string Field { get; set; }
        public string @Operator { get; set; }
        public string Value { get; set; }
        public bool IgnoreCase { get; set; }
        public string AnyCondition { get; set; }
    }

    public class Sorted
    {
        public string Name { get; set; }
        public string Direction { get; set; }
    }

    public class AutoCompleteFilter
    {
        public List<Where> Where { get; set; }
        public List<Sorted> Sorted { get; set; }
    }
}