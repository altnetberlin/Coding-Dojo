using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KataRange;
using NUnit.Framework;

namespace KataRangeTests
{
    [TestFixture]
    public class ContainsTests
    {
        [Test]
        public void RangeContainsSingleElement()
        {
            // Arrange
            var range = Range.Closed(2, 6);

            // Act
            var result = range.Contains(3);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RangeDoesNotContainSingleElement()
        {
            // Arrange
            var range = Range.Closed(2, 6);

            // Act
            var result = range.Contains(18);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(2, 6, new[] { 3, 4 }, true)]
        [TestCase(2, 6, new[] { 18, 3 }, false)]
        [TestCase(2, 6, new int[0], true)]
        [TestCase(int.MinValue, int.MaxValue, new[] { 3, 4 }, true)]
        public void RangeContainsSet(int left, int right, int[] elements, bool expected)
        {
            // Arrange
            var range = Range.Closed(left, right);

            // Act
            var result = range.Contains(elements);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestCase(2, 6, 2, false)]
        [TestCase(2, 6, 3, true)]
        [TestCase(2, 6, 6, false)]
        [TestCase(int.MinValue, int.MinValue, 9782357, false)]
        [TestCase(int.MaxValue, int.MaxValue, 9782357, false)]
        [TestCase(2, 2, 2, false)]
        public void OpenRangeContainsSingleElement(int left, int right, int element, bool expected)
        {
            // Arrange
            var range = Range.Open(left, right);

            // Act
            var result = range.Contains(element);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(6, 0)]
        [TestCase(int.MaxValue, int.MinValue)]
        [ExpectedException(typeof(ArgumentException))]
        public void OpenRangeIsInvalid(int left, int right)
        {
            // Arrange
            var range = Range.Open(left, right);
        }

        [Test]
        [TestCase(6, 0)]
        [TestCase(int.MaxValue, int.MinValue)]
        [ExpectedException(typeof(ArgumentException))]
        public void ClosedRangeIsInvalid(int left, int right)
        {
            // Arrange
            var range = Range.Closed(left, right);
        }

        [Test]
        [TestCase(6, 0)]
        [TestCase(int.MaxValue, int.MinValue)]
        [ExpectedException(typeof(ArgumentException))]
        public void LeftOpenRangeIsInvalid(int left, int right)
        {
            // Arrange
            var range = Range.LeftOpen(left, right);
        }

        [Test]
        [TestCase(6, 0)]
        [TestCase(int.MaxValue, int.MinValue)]
        [ExpectedException(typeof(ArgumentException))]
        public void RightOpenRangeIsInvalid(int left, int right)
        {
            // Arrange
            var range = Range.RightOpen(left, right);
        }

        [TestCase(2, 6, 2, false)]
        [TestCase(2, 6, 6, true)]
        [TestCase(int.MinValue, int.MinValue, 6, false)]
        [TestCase(2, 2, 2, false)]
        public void LeftOpenRangeContainsSingleElement(int left, int right, int element, bool expected)
        {
            // Arrange
            var range = Range.LeftOpen(left, right);

            // Act
            var result = range.Contains(element);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 6, 2, true)]
        [TestCase(2, 6, 6, false)]
        [TestCase(int.MinValue, int.MinValue, 6, false)]
        [TestCase(int.MaxValue, int.MaxValue, 6, false)]
        [TestCase(2, 2, 2, false)]
        public void RightOpenRangeContainsSingleElement(int left, int right, int element, bool expected)
        {
            // Arrange
            var range = Range.RightOpen(left, right);

            // Act
            var result = range.Contains(element);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
