using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfSportsTestTask.Models
{
    public class PaginationModel<T>
    {
        public IEnumerable<T> Objects { get; set; }
        public PagerInfo PagerInfo { get; set; }
    }
}