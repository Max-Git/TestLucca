using NUnit.Framework;
using System;
using Shouldly;
using TestTechniqueLuccaV2;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class CurrenciesPathManagerShould
	{
		[Test]
		public void produce_a_two_way_currency_pairs_when_one_exchange_rate_line_is_read ()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = new Tuple<string, string, decimal> ("AUD","CHF", 0.9661m);

			CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();


			currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

			currencyConversionPaths.ShouldSatisfyAllConditions
			(
				() => currencyConversionPaths.CurrencyPaths.First().ShouldBe("AUD->CHF"),
				() => currencyConversionPaths.CurrencyPaths.Count.ShouldBe(2),
				() => currencyConversionPaths.CurrencyPaths.ElementAt(1).ShouldBe("CHF->AUD")
			);
		}

        [Test]
        public void produce_4_two_way_currency_pairs_when_2_exchange_rate_lines_with_no_common_tail_or_head_are_read()
        {
            Tuple<string, string, decimal> exchangeRateLineElements = new Tuple<string, string, decimal>("AUD", "CHF", 0.9661m);

            CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            exchangeRateLineElements = new Tuple<string, string, decimal>("EUR", "JPY", 2.5487m);

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            currencyConversionPaths.ShouldSatisfyAllConditions
            (
                () => currencyConversionPaths.CurrencyPaths.Count.ShouldBe(4),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("AUD->CHF"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("CHF->AUD"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("EUR->JPY"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("JPY->EUR")
            );
        }

        [Test]
        public void produce_6_currency_pairs_when_2_exchange_rate_lines_with_a_common_head_are_read()
        {
            Tuple<string, string, decimal> exchangeRateLineElements = new Tuple<string, string, decimal>("AUD", "CHF", 0.9661m);

            CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            exchangeRateLineElements = new Tuple<string, string, decimal>("EUR", "AUD", 1.2053m);

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            currencyConversionPaths.ShouldSatisfyAllConditions
            (
                () => currencyConversionPaths.CurrencyPaths.Count.ShouldBe(6),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("AUD->CHF"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("CHF->AUD"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("EUR->AUD"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("AUD->EUR"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("EUR->AUD->CHF"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("CHF->AUD->EUR")
            );
        }

		[Test]
		public void produce_6_currency_pairs_when_2_exchange_rate_lines_with_a_common_tail_are_read()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = new Tuple<string, string, decimal>("AUD", "CHF", 0.9661m);

			CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();

			currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

			exchangeRateLineElements = new Tuple<string, string, decimal>("EUR", "CHF", 1.2053m);

			currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

			currencyConversionPaths.ShouldSatisfyAllConditions
			(
				() => currencyConversionPaths.CurrencyPaths.Count.ShouldBe(6),
				() => currencyConversionPaths.CurrencyPaths.ShouldContain("AUD->CHF"),
				() => currencyConversionPaths.CurrencyPaths.ShouldContain("CHF->AUD"),
				() => currencyConversionPaths.CurrencyPaths.ShouldContain("EUR->CHF"),
				() => currencyConversionPaths.CurrencyPaths.ShouldContain("CHF->EUR"),
				() => currencyConversionPaths.CurrencyPaths.ShouldContain("AUD->CHF->EUR"),
				() => currencyConversionPaths.CurrencyPaths.ShouldContain("EUR->CHF->AUD")
			);
		}

        [Test]
        public void produce_6_two_way_currency_pairs_when_3_exchange_rate_lines_with_no_common_tail_or_head_are_read()
        {
            Tuple<string, string, decimal> exchangeRateLineElements = new Tuple<string, string, decimal>("AUD", "CHF", 0.9661m);

            CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            exchangeRateLineElements = new Tuple<string, string, decimal>("EUR", "JPY", 1.2053m);

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            exchangeRateLineElements = new Tuple<string, string, decimal>("HUF", "USD", 7.5498m);

            currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

            currencyConversionPaths.ShouldSatisfyAllConditions
            (
                () => currencyConversionPaths.CurrencyPaths.Count.ShouldBe(6),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("AUD->CHF"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("CHF->AUD"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("EUR->JPY"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("JPY->EUR"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("HUF->USD"),
                () => currencyConversionPaths.CurrencyPaths.ShouldContain("USD->HUF")
            );
        }

		[Test]
		public void produce_4_currency_rate_pairs_when_2_different_exchange_rate_lines_are_read()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = new Tuple<string, string, decimal>("AUD", "CHF", 0.9661m);

			CurrencyConversionPaths currencyConversionPaths = new CurrencyConversionPaths();

			currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

			exchangeRateLineElements = new Tuple<string, string, decimal>("EUR", "CHF", 1.2053m);

			currencyConversionPaths = CurrenciesPathManager.ConvertToCurrencyConversionPaths(exchangeRateLineElements, currencyConversionPaths);

			currencyConversionPaths.ShouldSatisfyAllConditions
			(
				() => currencyConversionPaths.ExchangeRatePaths.Count.ShouldBe(4),
				() => currencyConversionPaths.ExchangeRatePaths.ShouldContain("AUD->CHF:0,9661"),
				() => currencyConversionPaths.ExchangeRatePaths.ShouldContain("CHF->AUD:1,0351"),
				() => currencyConversionPaths.ExchangeRatePaths.ShouldContain("EUR->CHF:1,2053"),
				() => currencyConversionPaths.ExchangeRatePaths.ShouldContain("CHF->EUR:0,8297")
			);
		}

		[Test]
		public void give_a_list_of_currency_pairs_when_a_path_is_splitted()
		{
			string path = "EUR->CHF->USD->JPY->AUD";
			List<string> pairs = CurrenciesPathManager.splitPathIntoPairs(path);

			pairs.ShouldSatisfyAllConditions
			(
				() => pairs.Count.ShouldBe(4),
				() => pairs.ElementAt(0).ShouldBe("EUR->CHF"),
				() => pairs.ElementAt(1).ShouldBe("CHF->USD"),
				() => pairs.ElementAt(2).ShouldBe("USD->JPY"),
				() => pairs.ElementAt(3).ShouldBe("JPY->AUD")
			);
		}
	}
}

