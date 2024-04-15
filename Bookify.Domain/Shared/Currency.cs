﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Shared
{
    public record Currency
    {
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Eur = new("EUR");
        internal static readonly Currency None = new("");
        private Currency(string code) => Code = code;
        public string Code { get; init; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ??
                throw new ApplicationException("The currency code in invalid");
        }
        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            Usd, Eur
        };
    }
}