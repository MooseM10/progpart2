using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    public class AVLTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public Node(T data)
            {
                Data = data;
                Height = 1;
            }
        }

        private Node root;

        /// <summary>
        /// Add a new item to the AVL tree.
        /// </summary>
        public void Insert(T data)
        {
            root = Insert(root, data);
        }

        private Node Insert(Node node, T data)
        {
            if (node == null)
                return new Node(data);

            if (data.CompareTo(node.Data) < 0)
                node.Left = Insert(node.Left, data);
            else if (data.CompareTo(node.Data) > 0)
                node.Right = Insert(node.Right, data);
            else
                return node; // Duplicate values are not allowed

            // Update height and balance the node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            return Balance(node);
        }

        /// <summary>
        /// Remove an item from the AVL tree.
        /// </summary>
        public void Remove(T data)
        {
            root = Remove(root, data);
        }

        private Node Remove(Node node, T data)
        {
            if (node == null)
                return null;

            if (data.CompareTo(node.Data) < 0)
                node.Left = Remove(node.Left, data);
            else if (data.CompareTo(node.Data) > 0)
                node.Right = Remove(node.Right, data);
            else
            {
                // Node with only one child or no child
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

                // Node with two children
                Node temp = GetMinValueNode(node.Right);
                node.Data = temp.Data;
                node.Right = Remove(node.Right, temp.Data);
            }

            // Update height and balance the node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            return Balance(node);
        }

        private Node GetMinValueNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        /// <summary>
        /// Get all items in the AVL tree (in-order traversal).
        /// </summary>
        public List<T> GetRequests()
        {
            List<T> requests = new List<T>();
            InOrderTraversal(root, requests);
            return requests;
        }

        private void InOrderTraversal(Node node, List<T> result)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Data);
                InOrderTraversal(node.Right, result);
            }
        }

        /// <summary>
        /// Balance the AVL tree node.
        /// </summary>
        private Node Balance(Node node)
        {
            int balanceFactor = GetBalanceFactor(node);

            // Left Heavy
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.Left) < 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right Heavy
            if (balanceFactor < -1)
            {
                if (GetBalanceFactor(node.Right) > 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        /// <summary>
        /// Perform a right rotation.
        /// </summary>
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        /// <summary>
        /// Perform a left rotation.
        /// </summary>
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            // Update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        /// <summary>
        /// Get the height of the node.
        /// </summary>
        private int GetHeight(Node node)
        {
            return node == null ? 0 : node.Height;
        }

        /// <summary>
        /// Get the balance factor of the node.
        /// </summary>
        private int GetBalanceFactor(Node node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }
    }
}
