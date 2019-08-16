using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class GridPager
    {
        public GridPager()
        {
            sort = "Id";
            order = "Desc";
        }
        public string order { get; set; }
        public int page { get; set; }
        public int rows { get; set; }
        public string sort { get; set; }
        public int totalPages { get; set; }
        public int totalRows { get; set; }
    }
}