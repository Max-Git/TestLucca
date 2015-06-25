using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTechniqueLuccaV2
{
    public static class CurrenciesPathManager
    {
        public static CurrencyConversionPaths ConvertToCurrencyConversionPaths(Tuple<string, string, decimal> lineElements, CurrencyConversionPaths currencyConversionPaths)
        {
            string newHeadCurrency = lineElements.Item1;
            string newTailCurrency = lineElements.Item2;
            decimal newExchangeRate = lineElements.Item3;

            if ((!currencyConversionPaths.CurrencyPaths.Contains(newHeadCurrency + "->" + newTailCurrency)) && (!currencyConversionPaths.CurrencyPaths.Contains(newHeadCurrency + "->" + newTailCurrency)))
            {
                List<string> newPaths = new List<string>();

                if (currencyConversionPaths.CurrencyPaths.Count > 0)
                {
                    newPaths.AddRange(
                        from path in currencyConversionPaths.CurrencyPaths
                        where path.StartsWith(newHeadCurrency)
                        select newTailCurrency + "->" + path
                        );

                    newPaths.AddRange(
                       from path in currencyConversionPaths.CurrencyPaths
                       where path.EndsWith(newHeadCurrency)
                       select path + "->" + newTailCurrency
                       );

                    newPaths.AddRange(
                        from path in currencyConversionPaths.CurrencyPaths
                        where path.StartsWith(newTailCurrency)
                        select newHeadCurrency + "->" + path
                        );

                    newPaths.AddRange(
                        from path in currencyConversionPaths.CurrencyPaths
                        where path.EndsWith(newTailCurrency)
                        select path + "->" + newHeadCurrency
                        );

                    currencyConversionPaths.CurrencyPaths.AddRange(newPaths);
                }

                currencyConversionPaths.CurrencyPaths.Add(newHeadCurrency + "->" + newTailCurrency);
                currencyConversionPaths.ExchangeRatePaths.Add(newHeadCurrency + "->" + newTailCurrency + ":" + newExchangeRate);

                currencyConversionPaths.CurrencyPaths.Add(newTailCurrency + "->" + newHeadCurrency);
                currencyConversionPaths.ExchangeRatePaths.Add(newTailCurrency + "->" + newHeadCurrency + ":" + decimal.Round(1 / newExchangeRate, 4));
                
            }

            return currencyConversionPaths;
        }


        public static List<string> splitPathIntoPairs(string path)
        {
            List<string> result = new List<string>();
            string[] elems = path.Split(new string[] { "->" }, StringSplitOptions.None);

            for (int i = 0; i < elems.Length - 1; i++)
            {
                result.Add(elems[i] + "->" + elems[i + 1]);
            }

            return result;
        }
    }
}
