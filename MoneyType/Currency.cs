//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="MoneyType">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MoneyType.BaseClasses;

namespace MoneyType
{
    /// <summary>
    /// Encapsulates currency data and behaviour.
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class Currency : ValueObject<Currency>
    {
        private const int ExpectedIso4217CodeLength = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if isoCode is null, empty or white space.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified ISO currency code appears to be invalid.
        /// </exception>
        internal Currency(string isoCode)
        {
            if (string.IsNullOrWhiteSpace(isoCode))
            {
                throw new ArgumentNullException(nameof(isoCode));
            }

            if (isoCode.Length != ExpectedIso4217CodeLength)
            {
                throw new ArgumentException(
                    $"Specified ISO code length was incorrect. Expected length of {ExpectedIso4217CodeLength}",
                    isoCode);
            }

            //if (IsNotOnWhiteList(isoCode))
            //{
            //    throw new ArgumentException($"The value of {nameof(isoCode)} is an invalid ISO currency code");
            //}
            IsoCode = isoCode;
        }

        /// <summary>
        /// Gets the three letter ISO 4217 code.
        /// </summary>
        /// <value>
        /// The three letter ISO 4217 code.
        /// </value>
        public string IsoCode { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="Currency"/>.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator Currency(string isoCode)
        {
            return new Currency(isoCode);
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
            return IsoCodesMatch(other);
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
        /// Encapsulates known currencies
        /// </summary>
        public static class KnownCurrencies
        {
            public static readonly Currency GBP = new Currency("GBP");
            public static readonly Currency DKK = new Currency("DKK");
            public static readonly Currency EUR = new Currency("EUR");
            public static readonly Currency NOK = new Currency("NOK");
            public static readonly Currency SEK = new Currency("SEK");
            public static readonly Currency USD = new Currency("USD");

            internal static readonly HashSet<string> Whitelist = new HashSet<string> { "GBP", "DKK", "EUR", "NOK", "SEK", "USD" };
        }
    }
}