using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms.DataStructures.Test
{
    public class SortTest
    {
        private int[] list = new int[] { 25, 16, 30, 3, 20 };

        [Fact]
        public void SelectionSort()
        {
            var listSorted = Sort.Selection(list);
            listSorted.Should().Equal(new int[] { 3, 16, 20, 25, 30 });
        }

        [Fact]
        public void BubbleSort()
        {
            var listSorted = Sort.Bubble(list);
            listSorted.Should().Equal(new int[] { 3, 16, 20, 25, 30 });
        }

        [Fact]
        public void QuickSort()
        {
            var listSorted = Sort.Quick(list);
            listSorted.Should().Equal(new int[] { 3, 16, 20, 25, 30 });
        }
    }
}