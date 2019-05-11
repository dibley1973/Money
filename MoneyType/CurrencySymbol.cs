//-----------------------------------------------------------------------
// <copyright file="CurrencySymbol.cs" company="MoneyType">
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
    /// Encapsulates currency symbol data and behaviour.
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class CurrencySymbol : ValueObject<CurrencySymbol>
    {
        /// <summary>
        /// The maximum symbol length
        /// </summary>
        public const int MaximumSymbolLength = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencySymbol"/> class.
        /// </summary>
        /// <param name="value">The currency symbol.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if currency symbol value is null, empty or white space.
        /// </exception>
        internal CurrencySymbol(string value)
        {
            EnsureNotNullOrWhiteSpace(value);
            EnsureMaximumLengthIsNotExceeded(value);

            Value = value;
        }

        /// <summary>
        /// Gets the currency symbol.
        /// </summary>
        /// <value>
        /// The currency symbol.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="Currency"/>.
        /// </summary>
        /// <param name="currencySymbol">The currency symbol.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator CurrencySymbol(string currencySymbol)
        {
            return new CurrencySymbol(currencySymbol);
        }

        /// <summary>
        /// Instance specific implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(CurrencySymbol other)
        {
            return SymbolsMatch(other);
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
                int hashCode = Value.GetHashCode();

                hashCode = hashCode * 383;

                return hashCode;
            }
        }

        /// <summary>
        /// Ensures the maximum length of the value is not exceeded.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the length of the specified symbol length was incorrect,
        /// and exceeds the maximum length of <see cref="MaximumSymbolLength"/>
        /// </exception>
        private static void EnsureMaximumLengthIsNotExceeded(string value)
        {
            var symbolLength = value.Length;
            if (symbolLength > MaximumSymbolLength)
            {
                throw new ArgumentException(
                    $"Specified symbol length was incorrect. Maximum length of {MaximumSymbolLength}, actual length of {symbolLength}",
                    value);
            }
        }

        /// <summary>
        /// Ensures value is not null or white space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">value</exception>
        private static void EnsureNotNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        /// Determines if the currency symbol for the current instance and the
        /// currency symbol for the specified <see cref="CurrencySymbol"/> match.
        /// </summary>
        /// <param name="other">The other <see cref="CurrencySymbol"/> to check.</param>
        /// <returns>
        ///   <c>true</c> if the currency symbols match; otherwise, <c>false</c>.
        /// </returns>
        private bool SymbolsMatch(CurrencySymbol other)
        {
            return Equals(other.Value, Value);
        }
    }
}