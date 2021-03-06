﻿using System;
using System.Runtime.CompilerServices;
using Bridge.Test;
using Bridge.ClientTest;

#pragma warning disable 219

namespace Bridge.ClientTest.SimpleTypes
{
    [Category(Constants.MODULE_ENUM)]
    [TestFixture(TestNameFormat = "Enum - {0}")]
    public class EnumTests
    {
        public enum TestEnum
        {
            FirstValue,
            SecondValue,
            ThirdValue
        }

        [Flags]
        public enum FlagsEnum
        {
            None = 0,
            FirstValue = 1,
            SecondValue = 2,
            ThirdValue = 4
        }

        [Test]
        public void TypePropertiesAreCorrect()
        {
            //Assert.AreEqual("System.Enum", typeof(Enum).GetClassName());
            Assert.AreEqual("Bridge.ClientTest.SimpleTypes.EnumTests.TestEnum", typeof(TestEnum).GetClassName());
            Assert.True((object)TestEnum.FirstValue is TestEnum);
        }

        private T GetDefaultValue<T>()
        {
            return default(T);
        }

        [IgnoreTest(Until = Constants.IGNORE_DATE)]
        [Test]
        public void DefaultValueOfEnumClassIsNull()
        {
            Assert.AreStrictEqual(null, GetDefaultValue<Enum>());
        }

        [IgnoreTest(Until = Constants.IGNORE_DATE)]
        [Test]
        public void DefaultValueOfEnumTypeIsFirstValue()
        {
            Assert.AreStrictEqual(TestEnum.FirstValue, GetDefaultValue<TestEnum>());
        }

        [IgnoreTest(Until = Constants.IGNORE_DATE)]
        [Test]
        public void DefaultConstructorOfEnumTypeReturnsZero()
        {
            Assert.AreStrictEqual(0, new TestEnum().ValueOf());
        }

        [Test]
        public void FirstValueOfEnumIsZero()
        {
            Assert.AreStrictEqual(TestEnum.FirstValue, TestEnum.FirstValue);
        }

        [IgnoreTest(Until = Constants.IGNORE_DATE)]
        [Test]
        public void CreatingInstanceOfEnumTypeReturnsZero()
        {
            Assert.AreStrictEqual(TestEnum.FirstValue, Activator.CreateInstance<TestEnum>());
        }

        [IgnoreTest(Until = Constants.IGNORE_DATE)]
        [Test]
        public void DefaultExpressionWithEnumReturnsZero()
        {
            Assert.AreStrictEqual(TestEnum.FirstValue, default(TestEnum));
        }

        [Test]
        public void GetHashCodeWorks()
        {
            Assert.AreEqual(TestEnum.FirstValue.GetHashCode(), TestEnum.FirstValue.GetHashCode());
            Assert.AreNotEqual(TestEnum.SecondValue.GetHashCode(), TestEnum.FirstValue.GetHashCode());
        }

        [Test]
        public void EqualsWorks()
        {
            Assert.True(TestEnum.FirstValue.Equals(TestEnum.FirstValue));
            Assert.False(TestEnum.FirstValue.Equals(TestEnum.SecondValue));
        }

        // Feature #347
        //[Test]
        //public void ParseWorks()
        //{
        //    Assert.AreEqual((TestEnum)Enum.Parse(typeof(TestEnum), "FirstValue"), TestEnum.FirstValue);
        //    Assert.AreEqual((TestEnum)Enum.Parse(typeof(FlagsEnum), "FirstValue | ThirdValue"), FlagsEnum.FirstValue | FlagsEnum.ThirdValue);
        //}

        // Feature #347
        //[Test]
        //public void StaticToStringWorks()
        //{
        //    Assert.AreEqual(Enum.ToString(typeof(TestEnum), TestEnum.FirstValue), "FirstValue");
        //    Assert.AreEqual(Enum.ToString(typeof(FlagsEnum), FlagsEnum.FirstValue | FlagsEnum.ThirdValue), "FirstValue | ThirdValue");
        //}

        // Feature #347
        //[Test]
        //public void ConversionsToEnumAreTreatedAsConversionsToTheUnderlyingType() {
        //    Assert.AreEqual((TestEnum)(object)0, 0);
        //    Assert.Throws(() => { var _ = (TestEnum)(object)0.5; });
        //}

        // Feature #347
        //[Test]
        //public void GetValuesWorks()
        //{
        //    Array values = Enum.GetValues(typeof(TestEnum));
        //    Assert.AreEqual(values.Length, 3);
        //    Assert.AreEqual(values.GetValue(0), TestEnum.FirstValue);
        //    Assert.AreEqual(values.GetValue(1), TestEnum.SecondValue);
        //    Assert.AreEqual(values.GetValue(2), TestEnum.ThirdValue);

        //    values = Enum.GetValues(typeof(FlagsEnum));
        //    Assert.AreEqual(values.Length, 4);
        //    Assert.AreEqual(values.GetValue(0), FlagsEnum.None);
        //    Assert.AreEqual(values.GetValue(1), FlagsEnum.FirstValue);
        //    Assert.AreEqual(values.GetValue(2), FlagsEnum.SecondValue);
        //    Assert.AreEqual(values.GetValue(3), FlagsEnum.ThirdValue);
        //}
    }
}
