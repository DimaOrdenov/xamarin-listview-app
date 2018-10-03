using MobileApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.Helpers
{
    public static class CurrencyHelper
    {
        public static string CurrencyString(this CurrencyEnum currencyEnum)
        {
            switch (currencyEnum)
            {
                default:
                    return "р.";
            }
        }
    }
}
