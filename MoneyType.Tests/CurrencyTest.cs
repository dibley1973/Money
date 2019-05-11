//-----------------------------------------------------------------------
// <copyright file="CurrencyTest.cs" company="MoneyType">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace MoneyType.Tests
{
    /// <summary>
    ///  Tests for the <see cref="Currency"/> object.
    /// </summary>
    [TestFixture]
    public class CurrencyTest
    {
        private static readonly CurrencySymbol SterlingCurrencySymbol = new CurrencySymbol("£");
        private static readonly CurrencyIsoCode SterlingCurrencyIsoCode = new CurrencyIsoCode("GBP");

        /// <summary>
        /// Given the constructor when supplied null <see cref="CurrencyIsoCode"/> then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullIsoCode_ThenThrowsException()
        {
            // ARRANGE
            const CurrencyIsoCode nullCurrencyIsoCode = null;

            // ACT
            Action actual = () => new Currency(nullCurrencyIsoCode, SterlingCurrencySymbol);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied null <see cref="CurrencySymbol"/> then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullCurrencySymbol_ThenThrowsException()
        {
            // ARRANGE
            const CurrencySymbol nullCurrencySymbol = null;

            // ACT
            Action actual = () => new Currency(SterlingCurrencyIsoCode, nullCurrencySymbol);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var currency1 = new Currency(SterlingCurrencyIsoCode, SterlingCurrencySymbol);
            var currency2 = new Currency(SterlingCurrencyIsoCode, SterlingCurrencySymbol);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeTrue("because the money structures have identical values");
        }

        /// <summary>
        /// Given the get hash code, when different values then returns false.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenDifferentValues_ThenReturnsFalse()
        {
            // ARRANGE
            var currency1 = new Currency(SterlingCurrencyIsoCode, SterlingCurrencySymbol);
            var isoCode2 = "USD";
            var currencyIsoCode2 = new CurrencyIsoCode(isoCode2);
            var currencySymbol2 = new CurrencySymbol("$");
            var currency2 = new Currency(currencyIsoCode2, currencySymbol2);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse("because the money structures have differing values");
        }

        /// <summary>
        /// Given the narrowing conversion from currency to currenc iso code when called then correctly casts to currency iso code.
        /// </summary>
        [Test]
        public void GivenNarrowingConversionFromCurrencyToCurrencIsoCode_WhenCalled_ThenCorrectlyCastsToCurrencyIsoCode()
        {
            // ARRANGE
            var currency = new Currency(SterlingCurrencyIsoCode, SterlingCurrencySymbol);

            // ACT
            CurrencyIsoCode actual = currency;

            // ASSERT
            actual.Value.Should().Be("GBP", "because the cast should result in the encapsulated value");
        }

        /// <summary>
        /// Given the narrowing conversion from currency to currency symbol when called then correctly casts to currency symbol.
        /// </summary>
        [Test]
        public void GivenNarrowingConversionFromCurrencyToCurrencySymbol_WhenCalled_ThenCorrectlyCastsToCurrencySymbol()
        {
            // ARRANGE
            var currency = new Currency(SterlingCurrencyIsoCode, SterlingCurrencySymbol);

            // ACT
            CurrencySymbol actual = currency;

            // ASSERT
            actual.Value.Should().Be("£", "because the cast should result in the encapsulated value");
        }

        /// <summary>
        /// Given the is equal to when supplied with equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var currencyIsoCode1 = new CurrencyIsoCode("DKK");
            var currencySymbol1 = new CurrencySymbol("kr");
            var currency1 = new Currency(currencyIsoCode1, currencySymbol1);
            var currencyIsoCode2 = new CurrencyIsoCode("DKK");
            var currencySymbol2 = new CurrencySymbol("kr");
            var currency2 = new Currency(currencyIsoCode2, currencySymbol2);

            // ACT
            var actual = currency1 == currency2;

            // ASSERT
            actual.Should().BeTrue("because both values were equal.");
        }

        /// <summary>
        /// Given the is equal to when supplied with non equal values then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithNonEqualValues_ThenReturnsFalse()
        {
            // ARRANGE
            var currencyIsoCode1 = new CurrencyIsoCode("DKK");
            var currencySymbol1 = new CurrencySymbol("kr");
            var currency1 = new Currency(currencyIsoCode1, currencySymbol1);
            var currencyIsoCode2 = new CurrencyIsoCode("SEK");
            var currencySymbol2 = new CurrencySymbol("kr");
            var currency2 = new Currency(currencyIsoCode2, currencySymbol2);

            var currencyIsoCode3 = new CurrencyIsoCode("SEK");
            var currencySymbol3 = new CurrencySymbol("kr1");
            var currency3 = new Currency(currencyIsoCode3, currencySymbol3);

            // ACT
            var actual1 = currency1 == currency2;
            var actual2 = currency2 == currency3;

            // ASSERT
            actual1.Should().BeFalse("because both values were NOT equal.");
            actual2.Should().BeFalse("because both values were NOT equal.");
        }
    }
}