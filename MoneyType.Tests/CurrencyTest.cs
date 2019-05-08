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
        /// <summary>
        /// Given the constructor when supplied null iso code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullIsoCode_ThenThrowsException()
        {
            // ARRANGE
            const string nullIsoCode = null;

            // ACT
            Action actual = () => new Currency(nullIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied empty iso code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedEmptyIsoCode_ThenThrowsException()
        {
            // ARRANGE
            const string emptyIsoCode = "";

            // ACT
            Action actual = () => new Currency(emptyIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because an empty ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied whitespace iso code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedWhitespaceIsoCode_ThenThrowsException()
        {
            // ARRANGE
            var emptyIsoCode = new string(' ', 3);

            // ACT
            Action actual = () => new Currency(emptyIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a whitespace ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied iso code too short then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedIsoCodeTooShort_ThenThrowsException()
        {
            // ARRANGE
            var tooShortIsoCode = "GB";

            // ACT
            Action actual = () => new Currency(tooShortIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentException>("because a too short an ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied iso code too long then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedIsoCodeTooLong_ThenThrowsException()
        {
            // ARRANGE
            var tooLongIsoCode = "SPAM";

            // ACT
            Action actual = () => new Currency(tooLongIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentException>("because a too long an ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var gbpIsoCode = "GBP";
            var currency1 = new Currency(gbpIsoCode);
            var currency2 = new Currency(gbpIsoCode);

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
            var gbpIsoCode = "GBP";
            var usdIsoCode = "USD";
            var currency1 = new Currency(gbpIsoCode);
            var currency2 = new Currency(usdIsoCode);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse("because the money structures have differing values");
        }

        ///// <summary>
        ///// Givens the implicit casting from iso code when called then can correctly cast to currency.
        ///// </summary>
        ///// <remarks>
        ///// TODO: Reinstate once we have an ISO code value object
        ///// </remarks>
        //[Test]
        //public void GivenImplicitCastingFromIsoCode_WhenCalled_ThenCanCorrectlyCastToCurrency()
        //{
        //    Currency sek = "SEK";
        //    Assert.AreEqual("SEK", sek.IsoCode);
        //}

        /// <summary>
        /// Givens the explicit casting from string operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenExplicitCastingFromStringOperator_WhenCalledWithValidValue_ThenCorrectlyCastsValueToCurrency()
        {
            // ARRANGE
            const string validIsoCode = "SEK";

            // ACT
            var actual = (Currency)validIsoCode;

            // ASSERT
            actual.IsoCode.Should().Be(validIsoCode, "because the cast should have been successful");
        }

        /// <summary>
        /// Givens the explicit casting from string operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenCastingFromStringOperator_WhenCalledWithInvalidValue_ThenCorrectlyCastsValueToCurrency()
        {
            // ARRANGE
            const string validIsoCode = "SPAM";
            object currency = null;

            // ACT
            Action actual = () =>
            {
                currency = (Currency)validIsoCode;
            };

            // ASSERT
            actual.Should().Throw<ArgumentException>(validIsoCode, "because the cast should NOT have been successful");
            currency.Should().BeNull("because the currency should never be assigned.");
        }

        /// <summary>
        /// Given the is equal to when supplied with equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var currency1 = new Currency("DKK");
            var currency2 = new Currency("DKK");

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
            var currency1 = new Currency("DKK");
            var currency2 = new Currency("SEK");

            // ACT
            var actual = currency1 == currency2;

            // ASSERT
            actual.Should().BeFalse("because both values were NOT equal.");
        }

        [Ignore("Ignoring this test while we refactor the nesting of the known currencies")]
        [Test]
        public void Detects_invalid_iso_codes()
        {
            Assert.Throws<ArgumentException>(() => { var invalid = (Currency)"INVALID"; });
        }

        /// <summary>
        /// Given the known currencies has all instances.
        /// </summary>
        [Test]
        public void GivenKnownCurrencies_HasAllInstances()
        {
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.GBP);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.DKK);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.EUR);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.NOK);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.SEK);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.USD);
        }
    }
}