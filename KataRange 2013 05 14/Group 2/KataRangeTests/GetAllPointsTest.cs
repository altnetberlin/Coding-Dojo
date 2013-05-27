using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using KataRange;
using NUnit.Framework;

namespace KataRangeTests
{
    [TestFixture]
    public class GetAllPointsTest
    {
        [TestCase(1, 1, new[] { 1 })]
        [TestCase(1, 2, new[] { 1, 2 })]
        public void ClosedRange(int left, int right, int[] expected)
        {
            var sut = Range.Closed(left, right);
            var result = sut.GetAllPoints();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(1, 1, new int[0])]
        [TestCase(1, 3, new[] { 2 })]
        public void OpenRange(int left, int right, int[] expected)
        {
            var sut = Range.Open(left, right);
            var result = sut.GetAllPoints();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(1, 3, new[] { 2, 3 })]
        public void LeftOpenRange(int left, int right, int[] expected)
        {
            var sut = Range.LeftOpen(left, right);
            var result = sut.GetAllPoints();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}