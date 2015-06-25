using System;
using System.Globalization;
using System.Collections.Generic;

namespace TestTechniqueLuccaV2
{
	public static class ConsoleParser
	{
		public static Tuple<string, int, string> ReadFirstLine (string input)
		{
			string[] firstLineElements;
			int amountToConvert;

			if (!string.IsNullOrEmpty (input)) 
			{
				firstLineElements = input.Split (new char[]{ ';' });

				if (firstLineElements.Length == 3) 
				{
					if (int.TryParse (firstLineElements[1], out amountToConvert)) 
					{
						return new Tuple<string, int, string> (firstLineElements[0], amountToConvert, firstLineElements[2]);
					}
					else 
					{
						return null;
					}
				}
				else 
				{
					return null;
				}
			} 
			else 
			{
				return null;
			}
		}

		public static int ReadSecondLine (string input)
		{
			int nbrExchangeRates;
			if (int.TryParse (input, out nbrExchangeRates)) 
			{
				return nbrExchangeRates;
			} 
			else 
			{
				return -1;	
			}
		}

		public static Tuple<string, string, decimal> ReadExchangeRatesLine (string input)
		{
			string[] lineElements;
			decimal exchangeRate;

			if (!string.IsNullOrEmpty (input)) 
			{
				lineElements = input.Split (new char[]{ ';' });

				if (lineElements.Length == 3) 
				{
                    if (Decimal.TryParse(lineElements[2], NumberStyles.Any, CultureInfo.InvariantCulture, out exchangeRate)) 
					{
                        if (exchangeRate > 0)
                            return new Tuple<string, string, decimal>(lineElements[0], lineElements[1], exchangeRate);
                        else
                            return null;
					}
					else 
					{
						return null;
					}
				}
				else 
				{
					return null;
				}
			} 
			else 
			{
				return null;
			}
		}

		

	}

}

