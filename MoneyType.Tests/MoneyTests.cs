//-----------------------------------------------------------------------
// <copyright file="MoneyTests.cs" company="MoneyType">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using MoneyType;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void Can_be_compared()
        {
            var dkk1 = new Money(13, "DKK");
            var dkk2 = new Money(13, Currency.KnownCurrencies.DKK);

            Assert.IsTrue(dkk1 == dkk2);
        }

        [Test]
        public void Can_be_created()
        {
            var sek = new Money(4711, Currency.KnownCurrencies.SEK);
            Assert.AreEqual(4711, sek.Amount);
            Assert.AreEqual("SEK", sek.Currency.IsoCode);
        }

        [Test]
        public void Can_be_created_from_iso_code()
        {
            var eur = new Money(13, "EUR");
            Assert.IsInstanceOf<Money>(eur);
        }
    }
}