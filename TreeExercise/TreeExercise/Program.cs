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
        protected NodeList<T> Neighbors
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
}
// Four levels deep example.
//      1
//     / \
//   1     1
//  / \   / \
//  1  2  2  1
// /\  /\ /\ /\
// 1 3 3 4 4 3 3 1