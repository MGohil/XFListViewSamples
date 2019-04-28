using System;
using System.Collections.Generic;
using System.Text;

namespace XFListViewSamples.Models
{
    public class PageableResponse<T>
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public T Items { get; set; }
    }
}
