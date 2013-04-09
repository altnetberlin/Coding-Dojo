using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace KataRange
{

    public class Interval
    {
        private readonly int _left;
        private readonly int _right;

        private readonly bool _isEmpty;

        public Interval(int left, bool leftClosed, int right, bool rightClosed)
        {
            if (left == right && (!leftClosed || !rightClosed))
            {
                _isEmpty = true;
            }
            else
            {
                _left = left;
                _right = right;
                if (!leftClosed)
                    _left++;
                if (!rightClosed)
                    _right--;
            }
        }

        public bool Contains(List<int> ints)
        {
            return ints.All(Contains);
        }

        public bool Contains(int i)
        {
            if (_isEmpty)
                return false;

            return !(i > _right || i < _left);
        }

        public List<int> GetAllPoints()
        {
            var allpoints = new List<int> { };

            if (!_isEmpty)
            {
                for (int i = _left; i <= _right; i++)
                {
                    allpoints.Add(i);
                }
            }

            return allpoints;
        }
    }

    [TestFixture]
    public class IntervalTests
    {
        [TestCase(int.MaxValue, false, int.MaxValue, true, new int[] { 2 }, 10, Result = false)]
        [TestCase(0, false, 0, false, new int[] { }, 11, Result = true)]

        [TestCase(2, false, 2, false, new int[] { 2 }, 2, Result = false)]
        [TestCase(2, false, 2, true, new int[] { 2 }, 3, Result = false)]
        [TestCase(2, true, 2, false, new int[] { 2 }, 4, Result = false)]
        [TestCase(2, true, 2, true, new int[] { 2 }, 5, Result = true)]

        [TestCase(2, true, 6, false, new int[] { 1 }, 1, Result = false)]
        [TestCase(2, true, 6, false, new int[] { 2, 6 }, 6, Result = false)]
        [TestCase(2, true, 6, false, new int[] { 2, 4 }, 8, Result = true)]
        [TestCase(2, true, 6, false, new int[] { 2, 7 }, 9, Result = false)]
        [TestCase(2, false, 6, false, new int[] { 1 }, 10, Result = false)]
        public bool IntervalContainsSet(int left, bool leftClosed, int right, bool rightClosed, int[] ints, int dummy)
        {
            var interval = new Interval(left, leftClosed, right, rightClosed);
            var result = interval.Contains(ints.ToList());
            return result;
        }

        [TestCase(2, true, 6, false, new int[] { 2, 3, 4, 5 }, 1)]
        [TestCase(2, true, 5, false, new int[] { 2, 3, 4 }, 2)]
        [TestCase(2, true, 2, false, new int[] { }, 3)]
        public void GetAllPoints(int left, bool leftClosed, int right, bool rightClosed, int[] expected, int dummy)
        {
            var interval = new Interval(left, leftClosed, right, rightClosed);

            var result = interval.GetAllPoints();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
