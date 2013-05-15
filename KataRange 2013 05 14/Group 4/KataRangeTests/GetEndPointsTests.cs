using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KataRange;
using NUnit.Framework;

namespace KataRangeTests
{
    [TestFixture]
    class GetEndPointsTests
    {
        [TestCase(2, 3, new int [] { })]
        [TestCase(2, 6, new[] { 3, 5 })]
        public void OpenRangeGetsCorrectAllPoints(int left, int right, int[] expected)
        {
            var range = Range.Open(left, right);

            var result = range.GetEndPoints();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(2, 2, new[] { 2 })]
        [TestCase(2, 6, new[] { 2, 6 })]
        public void ClosedRangeGetsCorrectAllPoints(int left, int right, int[] expected)
        {
            var range = Range.Closed(left, right);

            var result = range.GetEndPoints();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(2, 2, new int [] { })]
        [TestCase(2, 3, new[] { 3 })]
        [TestCase(2, 6, new[] { 3, 6 })]
        public void LeftOpenRangeGetsCorrectAllPoints(int left, int right, int[] expected)
        {
            var range = Range.LeftOpen(left, right);

            var result = range.GetEndPoints();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(2, 2, new int[] { })]
        [TestCase(2, 3, new[] { 2 })]
        [TestCase(2, 6, new[] { 2, 5 })]
        public void RightOpenRangeGetsCorrectAllPoints(int left, int right, int[] expected)
        {
            var range = Range.RightOpen(left, right);

            var result = range.GetEndPoints();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
