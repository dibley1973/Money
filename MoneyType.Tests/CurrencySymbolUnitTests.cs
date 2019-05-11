//-----------------------------------------------------------------------
// <copyright file="CurrencySymbolUnitTests.cs" company="MoneyType">
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
    /// Unit tests for the <see cref="CurrencySymbol"/>
    /// </summary>
    public class CurrencySymbolUnitTests
    {
        /// <summary>
        /// Given the <see cref="CurrencySymbol.MaximumSymbolLength"/>, when accessed then should have value of four.
        /// </summary>
        [Test]
        public void GivenMaximumSymbolLength_WhenAccessed_ThenShouldHaveValueOfFour()
        {
            // ARRANGE
            const int expected = 4;

            // ACT
            var actual = CurrencySymbol.MaximumSymbolLength;

            // ASSERT
            actual.Should().Be(expected, "because the value should be the maximum length of a currency symbol");
        }

        /// <summary>
        /// Given the constructor when supplied null currency symbol then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullCurrencySymbol_ThenThrowsException()
        {
            // ARRANGE
            const string nullCurrencySymbol = null;

            // ACT
            Action actual = () => new CurrencySymbol(nullCurrencySymbol);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null currency symbol is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied empty currency symbol then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedEmptyCurrencySymbol_ThenThrowsException()
        {
            // ARRANGE
            const string emptyCurrencySymbol = "";

            // ACT
            Action actual = () => new CurrencySymbol(emptyCurrencySymbol);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because an empty currency symbol is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied whitespace currency symbol then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedWhitespaceCurrencySymbol_ThenThrowsException()
        {
            // ARRANGE
            var emptyCurrencySymbol = new string(' ', 3);

            // ACT
            Action actual = () => new CurrencySymbol(emptyCurrencySymbol);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a whitespace currency symbol is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied currency symbol too long then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedCurrencySymbolTooLong_ThenThrowsException()
        {
            // ARRANGE
            var tooLongCurrencySymbol = "SPOONS";

            // ACT
            Action actual = () => new CurrencySymbol(tooLongCurrencySymbol);

            // ASSERT
            actual.Should().Throw<ArgumentException>("because a too long an currency symbol is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied valid currency symbol then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedValidCurrencySymbol_ThenDoesNotThrowException()
        {
            // ARRANGE
            const string currencySymbol1 = "£";
            const string currencySymbol2 = "$";
            const string currencySymbol3 = "Дин.";
            const string currencySymbol4 = "лв";
            const string currencySymbol5 = "﷼";

            // ACT
            Action actual1 = () => new CurrencySymbol(currencySymbol1);
            Action actual2 = () => new CurrencySymbol(currencySymbol2);
            Action actual3 = () => new CurrencySymbol(currencySymbol3);
            Action actual4 = () => new CurrencySymbol(currencySymbol4);
            Action actual5 = () => new CurrencySymbol(currencySymbol5);

            // ASSERT
            actual1.Should().NotThrow("because a valid currency symbol is permitted for construction");
            actual2.Should().NotThrow("because a valid currency symbol is permitted for construction");
            actual3.Should().NotThrow("because a valid currency symbol is permitted for construction");
            actual4.Should().NotThrow("because a valid currency symbol is permitted for construction");
            actual5.Should().NotThrow("because a valid currency symbol is permitted for construction");
        }

        /// <summary>
        /// Given the Value, when accessed after construction with valid currency symbol then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenAccessedAfterConstructionWithValidCurrencySymbol_ThenReturnsConstructedValue()
        {
            // ARRANGE
            const string currencySymbol1 = "£";
            const string currencySymbol2 = "$";
            const string currencySymbol3 = "Дин.";
            const string currencySymbol4 = "лв";
            const string currencySymbol5 = "﷼";
            var currencyCurrencySymbol1 = new CurrencySymbol(currencySymbol1);
            var currencyCurrencySymbol2 = new CurrencySymbol(currencySymbol2);
            var currencyCurrencySymbol3 = new CurrencySymbol(currencySymbol3);
            var currencyCurrencySymbol4 = new CurrencySymbol(currencySymbol4);
            var currencyCurrencySymbol5 = new CurrencySymbol(currencySymbol5);

            // ACT
            var actual1 = currencyCurrencySymbol1.Value;
            var actual2 = currencyCurrencySymbol2.Value;
            var actual3 = currencyCurrencySymbol3.Value;
            var actual4 = currencyCurrencySymbol4.Value;
            var actual5 = currencyCurrencySymbol5.Value;

            // ASSERT
            actual1.Should().Be(currencySymbol1, "because the property should hold the constructed value");
            actual2.Should().Be(currencySymbol2, "because the property should hold the constructed value");
            actual3.Should().Be(currencySymbol3, "because the property should hold the constructed value");
            actual4.Should().Be(currencySymbol4, "because the property should hold the constructed value");
            actual5.Should().Be(currencySymbol5, "because the property should hold the constructed value");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var gbpCurrencySymbol = "£";
            var currency1 = new CurrencySymbol(gbpCurrencySymbol);
            var currency2 = new CurrencySymbol(gbpCurrencySymbol);

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
            var gbpCurrencySymbol = "£";
            var usdCurrencySymbol = "$";
            var currency1 = new CurrencySymbol(gbpCurrencySymbol);
            var currency2 = new CurrencySymbol(usdCurrencySymbol);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse("because the money structures have differing values");
        }

        /// <summary>
        /// Given the explicit casting from string operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenExplicitCastingFromStringOperator_WhenCalledWithValidValue_ThenCorrectlyCastsValueToCurrencySymbol()
        {
            // ARRANGE
            const string validCurrencySymbol = "£";

            // ACT
            var actual = (CurrencySymbol)validCurrencySymbol;

            // ASSERT
            actual.Value.Should().Be(validCurrencySymbol, "because the cast should have been successful");
        }

        /// <summary>
        /// Given the explicit casting from string operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenCastingFromStringOperator_WhenCalledWithInvalidValue_ThenCorrectlyCastsValueToCurrencySymbol()
        {
            // ARRANGE
            const string validCurrencySymbol = "SPOONS";
            object currency = null;

            // ACT
            Action actual = () =>
            {
                currency = (CurrencySymbol)validCurrencySymbol;
            };

            // ASSERT
            actual.Should().Throw<ArgumentException>(validCurrencySymbol, "because the cast should NOT have been successful");
            currency.Should().BeNull("because the currency should never be assigned.");
        }

        /// <summary>
        /// Given the is equal to when supplied with equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var currency1 = new CurrencySymbol("DKK");
            var currency2 = new CurrencySymbol("DKK");

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
            var currency1 = new CurrencySymbol("DKK");
            var currency2 = new CurrencySymbol("SEK");

            // ACT
            var actual = currency1 == currency2;

            // ASSERT
            actual.Should().BeFalse("because both values were NOT equal.");
        }
    }
}