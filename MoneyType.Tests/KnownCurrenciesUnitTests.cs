﻿//-----------------------------------------------------------------------
// <copyright file="KnownCurrenciesUnitTests.cs" company="Dewe">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using NUnit.Framework;

namespace MoneyType.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="Currency.KnownCurrencies"/> class.
    /// </summary>
    public class KnownCurrenciesUnitTests
    {
        /// <summary>
        /// Given the known currencies, then has all instances.
        /// </summary>
        [Test]
        public void GivenKnownCurrencies_ThenHasAllInstances()
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