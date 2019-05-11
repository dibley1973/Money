//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="MoneyType">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using MoneyType.BaseClasses;

// ReSharper disable InconsistentNaming
namespace MoneyType
{
    /// <summary>
    /// Encapsulates currency data and behaviour.
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class Currency : ValueObject<Currency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <param name="symbol">The currency symbol.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if isoCode or symbol is null.
        /// </exception>
        internal Currency(CurrencyIsoCode isoCode, CurrencySymbol symbol)
        {
            IsoCode = isoCode ??
                throw new ArgumentNullException(nameof(isoCode));

            Symbol = symbol ??
                throw new ArgumentNullException(nameof(symbol));
        }

        /// <summary>
        /// Gets the three letter ISO 4217 code.
        /// </summary>
        /// <value>
        /// The three letter ISO 4217 code.
        /// </value>
        public CurrencyIsoCode IsoCode { get; }

        /// <summary>
        /// Gets the currency symbol.
        /// </summary>
        /// <value>
        /// The currency symbol.
        /// </value>
        public CurrencySymbol Symbol { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Currency"/> to <see cref="CurrencyIsoCode"/>.
        /// </summary>
        /// <param name="currency">The three letter ISO 4217 code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CurrencyIsoCode(Currency currency)
        {
            return currency.IsoCode;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Currency"/> to <see cref="CurrencySymbol"/>.
        /// </summary>
        /// <param name="currency">The currency symbol.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CurrencySymbol(Currency currency)
        {
            return currency.Symbol;
        }

        /// <summary>
        /// Instance specific implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Currency other)
        {
            return IsoCodesMatch(other) && SymbolsMatch(other);
        }

        /// <summary>
        /// Instance specific implementation of `GetHashCode`.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="T:System.Int32" /> representation of the hash code
        /// </returns>
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = IsoCode.GetHashCode();

                hashCode = hashCode * 373;

                return hashCode;
            }
        }

        /// <summary>
        /// Determines if the three letter ISO codes for the current instance and the specified
        /// <see cref="Currency"/> match.
        /// </summary>
        /// <param name="other">The other <see cref="Currency"/> to check.</param>
        /// <returns>
        ///   <c>true</c> if the ISO codes match; otherwise, <c>false</c>.
        /// </returns>
        private bool IsoCodesMatch(Currency other)
        {
            return Equals(other.IsoCode, IsoCode);
        }

        /// <summary>
        /// Determines if the symbol for the current instance and the specified
        /// <see cref="Currency"/> match.
        /// </summary>
        /// <param name="other">The other <see cref="Currency"/> to check.</param>
        /// <returns>
        ///   <c>true</c> if the symbols match; otherwise, <c>false</c>.
        /// </returns>
        private bool SymbolsMatch(Currency other)
        {
            return Equals(other.Symbol, Symbol);
        }

        /// <summary>
        /// Encapsulates known currencies
        /// </summary>
        public static class KnownCurrencies
        {
            /// <summary>
            /// The Pound Sterling currency
            /// </summary>
            public static readonly Currency GBP = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.GBP, new CurrencySymbol("£"));

            /// <summary>
            /// The Danish krone currency
            /// </summary>
            public static readonly Currency DKK = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.DKK, new CurrencySymbol("kr"));

            /// <summary>
            /// The euro currency
            /// </summary>
            public static readonly Currency EUR = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.EUR, new CurrencySymbol("€"));

            /// <summary>
            /// The Norwegian krone currency
            /// </summary>
            public static readonly Currency NOK = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.NOK, new CurrencySymbol("kr"));

            /// <summary>
            /// The Swedish krona/kronor currency
            /// </summary>
            public static readonly Currency SEK = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.SEK, new CurrencySymbol("kr"));

            /// <summary>
            /// The US dollar currency
            /// </summary>
            public static readonly Currency USD = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.USD, new CurrencySymbol("$"));
        }
    }
}