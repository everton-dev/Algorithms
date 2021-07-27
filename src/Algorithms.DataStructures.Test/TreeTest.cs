using FluentAssertions;
using Xunit;

namespace Algorithms.DataStructures.Test
{
    public class TreeTest
    {
        private int[] ArrNodes = new int[] { 1, 2, 3, 4, 5, 6 };

        [Fact]
        public void CreateTree()
        {
            var tree = CreateTreeMock();
            tree.CountNodes.Should().Equals(7);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void ExistsNodeValue(int findValue)
        {
            var tree = CreateTreeMock();
            var exists = tree.Exists(findValue);
            exists.Should().BeTrue();
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        public void NotExistsNodeValue(int findValue)
        {
            var tree = CreateTreeMock();
            var exists = tree.Exists(findValue);
            exists.Should().BeFalse();
        }

        [Fact]
        public void RemoveNodeTree()
        {
            var tree = CreateTreeMock();

            tree.Remove(4);

            tree.CountNodes.Should().Equals(5);
        }

        [Fact]
        public void ReadNode()
        {
            var tree = CreateTreeMock();
            var nodeTree = tree.Read();

            nodeTree.Should().Equals(new int[] { 1, 2, 3 });
        }

        [Fact]
        public void ReadTree()
        {
            var tree = CreateTreeMock();
            var nodeTree = tree.ReadAll();

            nodeTree.Should().Equals(new int[] { 1, 2, 3, 4, 5, 6 });
        }

        private Node CreateTreeMock()
        {
            var tree = new Node(ArrNodes[0]);

            for (var i = 1; i < ArrNodes.Length; i++)
                tree.Add(ArrNodes[i]);

            return tree;
        }
    }
}