using System;
using System.Collections.Generic;
using System.Text;

namespace AirBnBrecentSearches.Models
{
    class SearchItem
    {
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Dates { get  => $"{StartDate} - {EndDate}";}
    }
}
