using NUnit.Framework;
using System;
using Shouldly;
using TestTechniqueLuccaV2;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class CurrencyConversionPathsShould
	{
		[Test]
		public void return_the_shortest_path_among_all_paths_for_given_start_and_end_currencies ()
		{
			CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();

			currencyConversionPaths.CurrencyPaths.Add ("CHF->EUR->USD->JPY->AUD");
			currencyConversionPaths.CurrencyPaths.Add ("CHF->EUR->USD");
			currencyConversionPaths.CurrencyPaths.Add ("CHF->EUR->USD->JPY->BOB->COP->AUD");
			currencyConversionPaths.CurrencyPaths.Add ("EUR->USD->JPY->BOB->COP->AUD");
			currencyConversionPaths.CurrencyPaths.Add ("CHF->EUR->BRL->AUD");

			currencyConversionPaths.FindShortestPath("CHF","AUD").First().ShouldBe("CHF->EUR->BRL->AUD");
		}

		[Test]
		public void return_the_right_rate_among_all_rates_for_given_currency_pair ()
		{
			CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();
		
			currencyConversionPaths.ExchangeRatePaths.Add ("CHF->EUR:0,2522");
			currencyConversionPaths.ExchangeRatePaths.Add ("EUR->USD:1,3456");
			currencyConversionPaths.ExchangeRatePaths.Add ("EUR->CHF:2,4656");
			currencyConversionPaths.ExchangeRatePaths.Add ("EUR->JPY:0,4567");
			currencyConversionPaths.ExchangeRatePaths.Add ("CHF->AUD:1,3876");

			currencyConversionPaths.GetRate("CHF->AUD").First().ShouldBe("1,3876");
		}
	}
}

