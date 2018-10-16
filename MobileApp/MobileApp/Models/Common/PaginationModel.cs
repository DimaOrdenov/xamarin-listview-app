using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.Common
{
    public class PaginationModel<T>
    {
        public int Page { get; set; }

        public int Total { get; set; }

        public IList<T> Entities { get; set; }
    }
}
