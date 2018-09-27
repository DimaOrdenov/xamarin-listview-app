using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.Common
{
    public class Result<T>
    {
        public string Error { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public T Value { get; set; }
    }
}
