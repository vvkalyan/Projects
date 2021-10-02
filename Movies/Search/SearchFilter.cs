using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Search
{
    public class SearchFilter
    {
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public List<string> Genres { get; set; }

    }
}
