using KataRange;
using NUnit.Framework;

namespace KataRangeTests
{
    [TestFixture]
    class ContainsRangeTests
    {
        [TestCase(2, 6, 3, 5, true)]
        [TestCase(2, 6, 3, 6, true)]
        [TestCase(2, 6, 2, 5, true)]
        [TestCase(2, 6, 2, 6, true)]
        [TestCase(2, 6, 1, 5, false)]
        [TestCase(2, 6, 3, 7, false)]
        public void OpenRangeContainsOpenRange(int left, int right, int leftOther, int rightOther, bool expected)
        {
            // Arrange
            var range = Range.Open(left, right);
            var otherRange = Range.Open(leftOther, rightOther);

            // Act
            var result = range.Contains(otherRange);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 6, 3, 5, true)]
        [TestCase(2, 6, 3, 6, false)]
        [TestCase(2, 6, 2, 5, false)]
        [TestCase(2, 6, 2, 6, false)]
        [TestCase(2, 6, 1, 5, false)]
        [TestCase(2, 6, 3, 7, false)]
        public void OpenRangeContainsClosedRange(int left, int right, int leftOther, int rightOther, bool expected)
        {
            // Arrange
            var range = Range.Open(left, right);
            var otherRange = Range.Closed(leftOther, rightOther);

            // Act
            var result = range.Contains(otherRange);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 6, 3, 5, true)]
        [TestCase(2, 6, 3, 6, true)]
        [TestCase(2, 6, 2, 5, false)]
        [TestCase(2, 6, 2, 6, false)]
        [TestCase(2, 6, 1, 5, false)]
        [TestCase(2, 6, 3, 7, false)]
        public void OpenRangeContainsRightOpenRange(int left, int right, int leftOther, int rightOther, bool expected)
        {
            // Arrange
            var range = Range.Open(left, right);
            var otherRange = Range.RightOpen(leftOther, rightOther);

            // Act
            var result = range.Contains(otherRange);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 6, 3, 5, true)]
        [TestCase(2, 6, 3, 6, false)]
        [TestCase(2, 6, 2, 5, true)]
        [TestCase(2, 6, 2, 6, false)]
        [TestCase(2, 6, 1, 5, false)]
        [TestCase(2, 6, 3, 7, false)]
        public void OpenRangeContainsLeftOpenRange(int left, int right, int leftOther, int rightOther, bool expected)
        {
            // Arrange
            var range = Range.Open(left, right);
            var otherRange = Range.LeftOpen(leftOther, rightOther);

            // Act
            var result = range.Contains(otherRange);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
