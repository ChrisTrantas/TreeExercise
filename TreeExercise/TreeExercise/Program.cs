using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> btree = new BinaryTree<int>();
            btree.Root = new BinaryTreeNode<int>(1);
            btree.Root.Left = new BinaryTreeNode<int>(1);
            btree.Root.Right = new BinaryTreeNode<int>(1);

            btree.Root.Left.Left = new BinaryTreeNode<int>(1);
            btree.Root.Left.Right = new BinaryTreeNode<int>(2);

            btree.Root.Left.Left = new BinaryTreeNode<int>(2);
            btree.Root.Left.Right = new BinaryTreeNode<int>(1);

            Console.WriteLine(btree.Root.Value);
            Console.WriteLine(btree.Root.Left.Value);
            BinaryTreeNode<int> testTree = new BinaryTreeNode<int>(1, btree.Root.Left, btree.Root.Right);
            Console.WriteLine(testTree.Neighbors);
        }

    }

    // Steps to solve Trees
    // 1: Form a Node class to house and store data and neighbors
    // 2: Form a NodeList to form into a way to store connections
    // 3: Form a BinaryTree
    // 4: Make sure all nodes excluding Root have 2 children.
    // 5: Make sure Tree traversal can acess Parent's neighbors.


    // Node Class
    // Contains data of the node and neighbors of the node.
    // Needs a NodeList to contain who all its neighors are
    // T allows us to determine what kind of data to put in
    public class Node<T>
    {
        // Private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        // Generic Constructor
        public Node() { }

        // Constructor for Empty Node
        public Node(T data) : this(data, null) { }

        // Constuctor for Node and neighbors
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        // Getter and Setter for the specific Nodes Data
        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        // Getter and Setter for specific Nodes Neighbors
        public NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }

    // Need to make our own NodeList since C# does not have Tree support
    // using C# collection to help.
    // Collection allows for methods like Add(T), Remove(T), and Clear(T)
    public class NodeList<T> : Collection<Node<T>>
    {
        // Inherits from base
        public NodeList() : base() { }

        // Makes Node list to specific size
        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }
    }

    // Expanded the Node Class to focus on Binary Trees
    public class BinaryTreeNode<T> : Node<T>
    {
        // Default Constructor
        public BinaryTreeNode() : base() { }
        // Constructor with no data or children
        public BinaryTreeNode(T data) : base(data, null) { }
        // Constructor has children

        // Makes a Tree node with children
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = data;
            // Make the list have two spots. Left and Right
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            base.Neighbors = children;
        }


        // Getter and setter for neighbors of Left Child
        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        // Getter and setter for neighbors of Right Child
        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[1] = value;
            }
        }
    }

    // Actual Binary Tree Class.
    // Establishes Root and can have children.
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        
        public BinaryTree()
        {
            root = null;
        }

        // Clears Root
        public virtual void Clear()
        {
            root = null;
        }

        // Makes Binary Tree
        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }
    }
}
// Four levels deep example.
//      1
//     / \
//   1     1
//  / \   / \
//  1  2  2  1
// /\  /\ /\ /\
// 1 3 3 4 4 3 3 1