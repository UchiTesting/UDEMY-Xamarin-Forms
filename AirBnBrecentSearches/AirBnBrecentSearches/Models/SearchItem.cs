using System;
using System.Collections.Generic;
using System.Text;

namespace AirBnBrecentSearches.Models
{
    class SearchItem
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

        public string Dates { get  => $"{CheckIn} - {CheckOut}";}
    }
}
