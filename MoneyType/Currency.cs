//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Dewe">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyType
{
    /// <summary>
    /// Encapsulates currency data and behaviour.
    /// </summary>
    /// <seealso cref="Currency" />
    public sealed class Currency : IEquatable<Currency>, IEqualityComparer<Currency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified ISO currency code appears to be invalid.
        /// </exception>
        internal Currency(string isoCode)
        {
            if (IsNotOnWhiteList(isoCode))
            {
                throw new ArgumentException("Invalid ISO Currency Code");
            }

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
        public static implicit operator Currency(string isoCode)
        {
            return new Currency(isoCode);
        }

        /// <summary>
        /// <see cref="Currency"/> specific implementation of the == operator.
        /// </summary>
        /// <param name="left">The left hand <see cref="Currency"/> to compare.</param>
        /// <param name="right">The right <see cref="Currency"/> to compare.</param>
        /// <returns>
        /// The result of the operator; <c>true</c> if the currencies are equal; otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// <see cref="Currency"/> specific implementation of the != operator.
        /// </summary>
        /// <param name="left">The left hand <see cref="Currency"/> to compare.</param>
        /// <param name="right">The right <see cref="Currency"/> to compare.</param>
        /// <returns>
        /// The result of the operator; <c>true</c> if the currencies are NOT equal; otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// Returns <c>true</c> if the specified objects are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool Equals(Currency x, Currency y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Currency"/>, is equal to this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Currency"/>.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Equals(other.IsoCode, IsoCode);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Currency)) return false;

            return Equals((Currency)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Currency"/> objects are equal.
        /// </summary>
        /// <param name="x">The first <see cref="Currency"/> to compare.</param>
        /// <param name="y">The second <see cref="Currency"/> to compare.</param>
        /// <returns>
        /// Returns <c>true</c> if the specified objects are equal; otherwise, <c>false</c>.
        /// </returns>
        bool IEqualityComparer<Currency>.Equals(Currency x, Currency y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Returns a hash code for the specified <see cref="Currency"/> instance.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="Currency"/> instance to get the hash-code for.
        /// </param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public int GetHashCode(Currency obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return IsoCode.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified three letter ISO code is not on the white list.
        /// </summary>
        /// <param name="isoCode">The iso code.</param>
        /// <returns>
        ///   <c>true</c> if the ISO code is not on white list; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNotOnWhiteList(string isoCode)
        {
            return !KnownCurrencies.Whitelist.Contains<string>(isoCode);
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