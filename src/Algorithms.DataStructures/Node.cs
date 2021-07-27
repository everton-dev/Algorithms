using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public bool IsSingle
        {
            get
            {
                return Left == null && Right == null;
            }
        }
        public int Count
        {
            get
            {
                return 1 + (Left != null ? 1 : 0) + (Right != null ? 1 : 0);
            }
        }

        private int _countNodesTree;
        public int CountNodes
        {
            get
            {
                return _countNodesTree;
            }
        }

        public Node(int value)
            : this(value, null, null)
        {
        }

        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
            _countNodesTree++;
        }

        public bool Add(int valueNode)
        {
            if (valueNode < 0)
                throw new ArgumentException("Invalid value.");

            return Add(new Node(valueNode));
        }

        public bool Add(Node node)
        {
            if (node.Value < 0)
                throw new ArgumentException("Invalid value.");

            bool ReturnTrue()
            {
                _countNodesTree++;
                return true;
            }

            if (Left == null)
            {
                Left = node;
                return ReturnTrue();
            }
            else if (Right == null)
            {
                Right = node;
                return ReturnTrue();
            }
            else
            {
                if (Left.Add(node))
                    return ReturnTrue();

                if (Right.Add(node))
                    return ReturnTrue();

                if (Add(Left))
                    return ReturnTrue();

                if (Add(Right))
                    return ReturnTrue();
            }

            return false;
        }

        public bool Remove(int value)
        {
            bool ReturnTrue()
            {
                _countNodesTree--;
                return true;
            }

            if (Left != null && Left.Value == value)
            {
                Left = null;
                return ReturnTrue();
            }
            else if (Right != null && Right.Value == value)
            {
                Right = null;
                return ReturnTrue();
            }
            if (Left == null && Right == null)
            {
                return false;
            }
            else
            {
                if (!Left.Remove(value))
                    return Right.Remove(value);
                else
                {
                    return ReturnTrue();
                }
            }
        }

        public bool Exists(int value)
        {
            if (Value == value)
                return true;
            else if (Left != null && Exists(Left))
                return true;
            else if (Right != null && Exists(Right))
                return true;
            else
                return false;
        }

        public bool Exists(Node node) => Exists(node.Value);

        public int[] Read()
        {
            var result = new int[Count];

            if (Count == 3)
            {
                result[1] = Left.Value;
                result[2] = Right.Value;
            }
            else if (Count == 2)
            {
                result[1] = Left != null ? Left.Value : Right.Value;
            }

            result[0] = Value;

            return result;
        }

        public int[] ReadChild()
        {
            var countChildren = (Left != null ? 1 : 0) + (Right != null ? 1 : 0);
            if (countChildren == 0)
                return null;
            
            var result = new int[countChildren];

            if (countChildren == 2)
            {
                result[0] = Left.Value;
                result[1] = Right.Value;
            }
            else
            {
                result[0] = Left != null ? Left.Value : Right.Value;
            }
            
            return result;
        }

        public int[] ReadAll()
        {
            return ReadNodes(this).ToArray();
        }

        private List<int> ReadNodes(Node node = null)
        {
            var result = new List<int>();

            if (node == null)
            {
                return result;
            }
            else
            {
                result.Add(node.Value);
                
                if (node.Left != null)
                {
                    result.AddRange(ReadNodes(node.Left));
                }

                if (node.Right != null)
                {
                    result.AddRange(ReadNodes(node.Right));
                }
            }

            return result;
        }
    }
}