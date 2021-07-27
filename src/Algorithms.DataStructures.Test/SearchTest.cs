using FluentAssertions;
using System;
using Xunit;

namespace Algorithms.DataStructures.Test
{
    public class SearchTest
    {
        //The list need to sorted
        int[] list = new int[] { 4, 9, 12, 18, 30, 47, 72 };

        [Theory]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(30)]
        [InlineData(47)]
        [InlineData(72)]
        public void LinearLeftRightSearch(int searchElement)
        {
            var result = Search.LinearLeftRight(list, searchElement);

            result.Should().BeGreaterThan(-1);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(30)]
        [InlineData(47)]
        [InlineData(72)]
        public void LinearSearch(int searchElement)
        {
            var result = Search.Linear(list, searchElement);

            result.Should().BeGreaterThan(-1);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(30)]
        [InlineData(47)]
        [InlineData(72)]
        public void BinarySearch(int searchElement)
        {
            var result = Search.Binary(list, searchElement);

            result.Should().BeGreaterThan(-1);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(30)]
        [InlineData(47)]
        [InlineData(72)]
        public void TernarySearch(int searchElement)
        {
            var result = Search.Ternary(list, searchElement);

            result.Should().BeGreaterThan(-1);
        }
    }
}