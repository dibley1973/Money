// <copyright file="ValueObjectTests.cs" company="MoneyType">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using FluentAssertions;
using MoneyType.BaseClasses;
using MoneyType.Tests.Fakes;
using MoneyType.Tests.TestData;
using NUnit.Framework;

namespace MoneyType.Tests.BaseClasses
{
    /// <summary>
    /// Provides unit tests for the <see cref="ValueObject{T}"/> class.
    /// </summary>
    [TestFixture]
    public class ValueObjectTests
    {
        /// <summary>
        /// Given the equals when given null object returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateDefaultFakeValueObject();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given null object returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenNullSameType_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            const FakeValueObject other = default(FakeValueObject);

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given different type returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenDifferentType_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            object other = "otherObjectType";

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given same type different reference returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo2();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given same type same reference returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = instance;

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the equals when given same type different reference same values returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo1();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is equal to when given null object returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateDefaultFakeValueObject();

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the is equal to when given same type different reference returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo2();

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the is equal to when given same type same reference returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = instance;

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is equal to when given same type both null reference returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeBothNullReference_ReturnsTrue()
        {
            // ARRANGE
            const FakeValueObject nullValueObject1 = null;
            const FakeValueObject nullValueObject2 = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = nullValueObject1 == nullValueObject2;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is equal to when given same type different reference same values returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo1();

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is not equal to when given null object returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenNullObject_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateDefaultFakeValueObject();

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is not equal to when given same type different reference returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeDifferentReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo2();

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is not equal to when given same type same reference returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeSameReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = instance;

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the is not equal to when given same type different reference same values returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo1();

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}