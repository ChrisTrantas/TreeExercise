using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Binary tree and give it a default starting value
            Tree MyTree;
            int startingValue = 1; // Change this to change the starting value of the tree
            MyTree = new Tree(startingValue);

            #region Pascal Formula
            System.Console.WriteLine("Pascal Triangle Program");
            System.Console.Write("Enter the number of rows: ");

            // Figure out how many levels and nodes there are
            string levels = System.Console.ReadLine();
            int lvl = Convert.ToInt32(levels);
            int totalNodes = (int)Math.Pow(2, (lvl + 1)) - 1; // 2^(k + 1) - 1

            // Pascal Formula to get right numbers
            for (int y = 0; y <= lvl; y++)
            {
                // Starting Level
                int c = 1;
                // Pascal Formula
                for (int x = 0; x <= y; x++)
                {
                    System.Console.Write(c);
                    c = c * (y - x) / (x + 1);
                   // MyTree.Add(c);
                }
                System.Console.WriteLine();
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            #endregion
            Console.WriteLine("There should be a total of " + totalNodes + " Nodes");
        }
    }

    // Node class
    public class Node
    {
        // Data we need to traverse and keep track of chilren and parents
        public int value;
        public Node left;
        public Node right;
        public Node previous;

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;
            previous = null;
        }
    }

    // Binary Search Tree
    public class Tree
    {
        Node top;
        Node previous;
        Node current;

        public Tree()
        {
            top = null;
            previous = null;
            current = null;
        }

        public Tree(int initial)
        {
            top = new Node(initial);
            current = top;
            previous = null;
        }

        public void Add(int value)
        {
            // Non- recursive Add
            if (top == null) // the tree is empty
            {
                // Add item as the base node
                Node NewNode = new Node(value);
                top = NewNode;
                return;
            }

            bool added = false;
            do
            {
               // if (current.left == null)
               // {
               //     Node NewNode = new Node(value);
               //     current.left = NewNode;
               //     current.left.value = current.left.value + previous.right.value;
               //     previous = current;
               //     current = current.left;
               //     added = true;
               // }
               // if (current.right == null)
               // {
               //     Node NewNode = new Node(value);
               //     current.right = NewNode;
               //     current.right.value = current.right.value + previous.left.value;
               //     previous = current;
               //     current = current.right;
               //     added = true;
               // }
                // // go left
                // if (current.left == null)
                // {
                //     // Add the item
                //     Node NewNode = new Node(value);
                //     current.left = NewNode;
                //     NewNode.value += previous.right.value;
                //     current.right = NewNode;
                //     added = true;
                // }
                // // go left
                // if (current.right == null)
                // {
                //     // Add the item
                //     Node NewNode = new Node(value);
                //     current.right = NewNode;
                //     NewNode.value += current.left.value;
                //     current.right = NewNode;
                //     added = true;
                // }

            } while (!added);

        }

        // Add recursively with the pascal formula using AddRecursive
        public void AddRC(int value)
        {
            // Recursive add
            AddRecursive(ref top, value);

        }

        private void AddRecursive(ref Node Node, int value)
        {
            // Private recursive search for where to add the new node
            if (Node == null)
            {
                // Node doesn't exist add it here
                Node NewNode = new Node(value);
                Node = NewNode; // Set the old node reference to the newly created node thus attaching it to the tree
                return; // End the function and fall back
            }
            if (current.left == null)
            {
                AddRecursive(ref Node.left, value);
                return;
            }
            if (current.right == null)
            {
                AddRecursive(ref Node.right, value);
                return;
            }

        }
    }
}
