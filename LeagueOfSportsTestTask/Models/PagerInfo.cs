using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfSportsTestTask.Models
{
    public class PagerInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 
        public int TotalItems { get; set; } 
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}