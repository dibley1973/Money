//-----------------------------------------------------------------------
// <copyright file="CurrencyTest.cs" company="MoneyType">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using MoneyType;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CurrencyTest
    {
        [Test]
        public void Can_be_assigned_from_string()
        {
            Currency sek = "SEK";
            Assert.AreEqual("SEK", sek.IsoCode);
        }

        [Test]
        public void Can_be_casted_from_string()
        {
            var sek = (Currency)"SEK";
            Assert.AreEqual("SEK", sek.IsoCode);
        }

        [Test]
        public void Can_be_compared()
        {
            var sek1 = Currency.KnownCurrencies.SEK;
            var sek2 = (Currency)"SEK";
            Assert.IsTrue(sek1.Equals(sek2));
        }

        [Ignore("Ignoring this test while we refactor the nesting of the known currencies")]
        [Test]
        public void Detects_invalid_iso_codes()
        {
            Assert.Throws<ArgumentException>(() => { var invalid = (Currency)"INVALID"; });
        }

        /// <summary>
        /// Givens the known currencies has all instances.
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