using MobileApp.Models.Enums;
using MobileApp.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Money
    {
        public Money(int amount)
        {
            Amount = amount;
            Currency = CurrencyEnum.RUB;
        }

        public int? Amount { get; set; }

        public CurrencyEnum Currency { get; set; }

        [JsonIgnore]
        public string FormattedString
        {
            get
            {
                return String.Format("{0} {1}", Amount ?? 0, Currency.CurrencyString());
            }
        }
    }
}
