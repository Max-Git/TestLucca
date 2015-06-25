using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestTechniqueLuccaV2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();
            decimal convertedAmount = 0;

			Console.WriteLine ("Welcome to this brilliant currency converter! ;-)");
            Console.WriteLine ("=================================================");
            Tuple<string, int, string> firstLineElements = ConsoleParser.ReadFirstLine(Console.ReadLine());
            Decimal.TryParse(firstLineElements.Item2.ToString(CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out convertedAmount);

            if (firstLineElements != null)
            {
                int nbrExchangeRates = ConsoleParser.ReadSecondLine(Console.ReadLine());

                if (nbrExchangeRates > 0)
                { 
                    for (int i = 0; i < nbrExchangeRates; i++)
                    {
                        Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine(Console.ReadLine());

                        if (exchangeRateLineElements != null)
                        {
                            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect exchange rate input!");
                            Console.ReadLine();
                            return;
                        }
                    } 

					List<string> shortestPath = currencyConversionPaths.FindShortestPath (firstLineElements.Item1, firstLineElements.Item3);

                    if (shortestPath.Count() > 0)
                    {
                        List<string> shortestPathPairs = CurrenciesPathManager.splitPathIntoPairs(shortestPath.First());

                        var rates =
                            from pair in shortestPathPairs
                            let rate = currencyConversionPaths.GetRate (pair)
                            let pairRate = Decimal.Parse(rate.First(), NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("fr-FR"))
                            select pairRate;

                        convertedAmount = rates.Aggregate(convertedAmount, (x, y) => x * y);

                        Console.WriteLine("" + (int)decimal.Round(convertedAmount, MidpointRounding.AwayFromZero));
                    }
                    else
                    {
                        Console.WriteLine("No enough rates to convert! :-(");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect number of exchange rates!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect first line input!");
            }

            Console.ReadLine();
		}

        
	}
}
