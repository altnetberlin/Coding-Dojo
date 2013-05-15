using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KataRange
{
    public class Range
    {
        private readonly int _left;
        private readonly int _right;

        private Range(int left, int right)
        {
            _left = left;
            _right = right;
        }

        public bool Contains(int element)
        {
            return element >= _left && element <= _right;
        }

        public bool Contains(int[] elements)
        {
            return elements.All(Contains);
        }

        public static Range Closed(int left, int right)
        {
            if (right < left)
                throw new ArgumentException("Right bla ...");

            return GetRange(left, right, false, false);
        }

        public static Range Open(int left, int right)
        {
            if (right < left)
                throw new ArgumentException("Right bla ...");

            return GetRange(left, right, true, true);
        }

        private static Range GetRange(int left, int right, bool isLeftOpen, bool isRightOpen)
        {
            var l = isLeftOpen ? GetOpenLeft(left) : left;
            var r = isRightOpen ? GetOpenRight(right) : right;

            return new Range(l, r);
        }

        private static int GetOpenRight(int right)
        {
            var r = right;
            if (right != int.MinValue)
                r--;
            return r;
        }

        private static int GetOpenLeft(int left)
        {
            var l = left;

            if (left != int.MaxValue)
                l++;
            return l;
        }

        public static Range LeftOpen(int left, int right)
        {
            if (right < left)
                throw new ArgumentException("Right bla ...");

            return GetRange(left, right, true, false);
        }

        public static Range RightOpen(int left, int right)
        {
            if (right < left)
                throw new ArgumentException("Right bla ...");

            return GetRange(left, right, false, true);
        }

        public bool Contains(Range other)
        {
            return Contains(other._left) && Contains(other._right);
        }

        public bool Overlaps(Range other)
        {
            return Contains(other._left) || Contains(other._right) || other.Contains(_left);
        }

        public IEnumerable<int> GetAllPoints()
        {
            for (var i = _left; i <= _right; i++)
            {
                yield return i;
            }
        }

        public IEnumerable<int> GetEndPoints()
        {
            if (IsEmpty)
                yield break;
            yield return _left;
            if (_left == _right)
                yield break;
            yield return _right;
        }

        private bool IsEmpty
        {
            get { return _left > _right; }
        }
    }
}