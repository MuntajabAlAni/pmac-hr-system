using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class ShortcutsIndexViewModel
    {
        public IEnumerable<Shortcut> Shortcuts { get; set; }
        public string Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }


        public int TotalPages => (int)System.Math.Ceiling((double)TotalItems / PageSize);
    }
}