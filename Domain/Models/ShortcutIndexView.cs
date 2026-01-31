using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class ShortcutIndexView
    {
        public IEnumerable<Shortcut> Shortcuts { get; set; } = new List<Shortcut>();
        public string? Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
