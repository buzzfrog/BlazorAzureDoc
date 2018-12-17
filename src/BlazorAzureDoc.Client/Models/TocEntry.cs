using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAzureDoc.Client.Models
{
    public class TocEntry
    {
        public string Name { get; set; }
        public string Href { get; set; }
        public bool Expanded { get; set; }
        public List<TocEntry> items { get; set; }
        public int _id { get; set; }
    }
}
