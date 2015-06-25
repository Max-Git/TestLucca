using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTechniqueLuccaV2
{
    public class CurrencyConversionPaths
    {
       
        public CurrencyConversionPaths()
        {
            CurrencyPaths = new List<string>();
            ExchangeRatePaths = new List<string>();
        }

        public List<string> CurrencyPaths { get; set; }
        public List<string> ExchangeRatePaths { get; set; }

		public List<string> FindShortestPath (string startCurrency, string endCurrency)
		{
			var shortestPath =
				from path in CurrencyPaths
					where path.StartsWith(startCurrency) && path.EndsWith(endCurrency)
				orderby path.Length ascending
				select path;

			return shortestPath.ToList();
		}

		public List<string> GetRate (string currencyPair)
		{
			var rate =
				from exchangeRate in ExchangeRatePaths
					where exchangeRate.StartsWith(currencyPair)
				select exchangeRate.Substring(exchangeRate.IndexOf(':') + 1);

			return rate.ToList();
		}
    }


}
