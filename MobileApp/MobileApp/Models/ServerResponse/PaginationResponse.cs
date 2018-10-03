using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.ServerResponse
{
    public class PaginationResponse
    {
        public string TotalCount { get; set; }

        public int? PageCount { get; set; }
    }
}
