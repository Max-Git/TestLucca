using NUnit.Framework;
using System;
using Shouldly;
using TestTechniqueLuccaV2;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class ConsoleParserShould
	{
		[Test]
		public void have_3_elements_when_first_line_is_read ()
		{
			Tuple<string, int, string> firstLineElements = ConsoleParser.ReadFirstLine ("EUR;550;JPY");

			firstLineElements.ShouldSatisfyAllConditions
			(
				() => firstLineElements.Item1.ShouldBe("EUR"),
				() => firstLineElements.Item2.ShouldBe(550),
				() => firstLineElements.Item3.ShouldBe("JPY")
			);
		}

		[Test]
		public void return_null_when_first_line_is_read_is_empty ()
		{
			Tuple<string, int, string> firstLineElements = ConsoleParser.ReadFirstLine ("");

			firstLineElements.ShouldBe (null);
		}

		[Test]
		public void return_null_when_first_line_is_read_does_not_contain_3_elements ()
		{
			Tuple<string, int, string> firstLineElements = ConsoleParser.ReadFirstLine ("ZZZ;333");

			firstLineElements.ShouldBe (null);
		}

		[Test]
		public void return_null_when_first_line_is_read_and_amount_not_an_integer ()
		{
			Tuple<string, int, string> firstLineElements = ConsoleParser.ReadFirstLine ("ZZZ;aaa;XXX");

			firstLineElements.ShouldBe (null);
		}


		[Test]
		public void have_an_integer_when_second_line_is_read ()
		{
			int nbrExchangeRates = ConsoleParser.ReadSecondLine ("6");

			nbrExchangeRates.ShouldSatisfyAllConditions
			(
				() => nbrExchangeRates.ShouldBeOfType(typeof(Int32)),
				() => nbrExchangeRates.ShouldBeGreaterThan(0)

			);
		}

		[Test]
		public void return_minus_1_when_second_line_is_read_and_the_number_is_not_an_integer ()
		{
			int nbrExchangeRates = ConsoleParser.ReadSecondLine ("a");

			nbrExchangeRates.ShouldBe (-1);
		}

		[Test]
		public void have_3_elements_when_third_line_is_read ()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine ("AUD;CHF;0.9661");

			exchangeRateLineElements.ShouldSatisfyAllConditions
			(
				() => exchangeRateLineElements.Item1.ShouldBe("AUD"),
				() => exchangeRateLineElements.Item2.ShouldBe("CHF"),
				() => exchangeRateLineElements.Item3.ShouldBe(0.9661m)
			);
		}

		[Test]
		public void return_null_when_third_line_is_read_is_empty ()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine ("");

			exchangeRateLineElements.ShouldBe (null);
		}

		[Test]
		public void return_null_when_third_line_is_read_does_not_contain_3_elements ()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine ("AUD;CHF");

			exchangeRateLineElements.ShouldBe (null);
		}

		[Test]
		public void return_null_when_third_line_is_read_and_amount_not_an_decimal ()
		{
			Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine ("AUD;CHF;aaa");

			exchangeRateLineElements.ShouldBe (null);
		}

        [Test]
        public void return_null_when_third_line_is_read_and_amount_equals_0()
        {
            Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine("AUD;CHF;0");

            exchangeRateLineElements.ShouldBe(null);
        }

        [Test]
        public void return_null_when_third_line_is_read_and_amount_is_lower_than_0()
        {
            Tuple<string, string, decimal> exchangeRateLineElements = ConsoleParser.ReadExchangeRatesLine("AUD;CHF;-1.3");

            exchangeRateLineElements.ShouldBe(null);
        }



	}
}

