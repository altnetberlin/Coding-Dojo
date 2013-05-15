using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KataRange;
using NUnit.Framework;

namespace KataRangeTests
{
    [TestFixture]
    public class Class1Test
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

        [TestCase(2, 10, 3, 6, true)]
        [TestCase(2, 10, 0, 11, false)]
        [TestCase(2, 10, 3, 11, false)]
        [TestCase(2, 10, 2, 10, true)]
        public void OpenRangeContainsOpenRange(int left, int right, int otherleft, int otherright, bool expected)
        {
             //Arrange
            var openrange = Range.Open(left, right);
            var otherrange = Range.Open(otherleft, otherright);

            //Act
            var result = openrange.Contains(otherrange);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 10, 2, 10, false)]
        public void OpenRangeContainsClosedRange(int left, int right, int otherleft, int otherright, bool expected)
        {
            //Arrange
            var openrange = Range.Open(left, right);
            var otherrange = Range.Closed(otherleft, otherright);

            //Act
            var result = openrange.Contains(otherrange);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 5, new[]{ 3, 4 })]
        [TestCase(1, 6, new[] { 2, 3, 4, 5 })]
        [TestCase(2, 3, new int[] {})]
        public void AllPointsOfOpenRange(int left, int right, int[] expected)
        {
            // Arrange
            var range = Range.Open(left, right);

            // Act
            var result = range.GetAllPoints();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(2, 5, new[] { 2, 3, 4, 5 })]
        [TestCase(1, 6, new[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(2, 3, new int[] { 2, 3 })]
        public void AllPointsOfClosedRange(int left, int right, int[] expected)
        {
            // Arrange
            var range = Range.Closed(left, right);

            // Act
            var result = range.GetAllPoints();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(2, 5, 3, 4)]
        [TestCase(1, 6, 2, 5)]
        public void EndPointsOfOpenRange(int left, int right, int expectedFirst, int expectedSecond)
        {
            // Arrange
            var range = Range.Open(left, right);

            // Act
            Tuple<int, int> result = range.GetEndPoints();

            // Assert
            Assert.AreEqual(expectedFirst, result.Item1);
            Assert.AreEqual(expectedSecond, result.Item2);
        }

        [TestCase(2, 5, 2, 4)]
        [TestCase(1, 6, 1, 5)]
        [TestCase(int.MinValue, int.MaxValue, int.MinValue, int.MaxValue - 1)]
        [TestCase(1, 2, 1, 1)]
        public void EndPointsOfRightOpenRange(int left, int right, int expectedFirst, int expectedSecond)
        {
            // Arrange
            var range = Range.RightOpen(left, right);

            // Act
            Tuple<int, int> result = range.GetEndPoints();

            // Assert
            Assert.AreEqual(expectedFirst, result.Item1);
            Assert.AreEqual(expectedSecond, result.Item2);
        }

        [TestCase(1, 2)]
        [ExpectedException(typeof(ArgumentException))]
        public void EndPointsOfEmptyRange(int left, int right)
        {
            // Arrange
            var range = Range.Open(left, right);

            // Act
            Tuple<int, int> result = range.GetEndPoints();

            // Assert
            
        }
    }
}
