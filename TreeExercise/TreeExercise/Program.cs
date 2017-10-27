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
            // Prints out the normal sequence
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
            // Gives the right number if it was in a Balanced Binary Tree
            Console.WriteLine("There should be a total of " + totalNodes + " Nodes");
        }
    }

    // Node class
    public class Node
    {
        // Data we need to traverse and keep track of chilren and parents
        public int value; // Value of current node
        public Node left; // Left Child
        public Node right; // Right Child
        public Node previous; // Parent

        // Base Node
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
        Node top; // Top of the Tree
        Node current; // Current Node in the Tree

        // Empty Tree
        public Tree()
        {
            top = null;
            current = null;
        }

        // Initial Tree set up
        public Tree(int initial)
        {
            top = new Node(initial);
            current = top;
        }

        // Add a node to the tree
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
// Comments and Thoughts
//
// Thought Process
// After a bit of refreshing myself on trees I knew it was a Binary Search Tree that is balanced.
// Over all it should be rather quick if I had to search it but it is just outputting Pascal's Triangle
// Once I knew that I found the equation for it so I know how many total nodes I have based on level
// Drew it out on paper to confirm it as well.
// 
// The problem with thinking it as a Binary Search Tree is how to get the values in the right spot
// espeically since the root is 1 and usually lower goes to the left and the higher values go right recursively
// With pascal's triangle that simply is not correct
//
// A good way to chunk it up is into mini trees. The root would be parent, if I stored that nodes parents opposite child it 
// could be used to get the value of correct node for both children
// If it was on the outside I could mark it as so and just have the correct child be "1" since it'll never be higher
// A idea I had was to connect all the nodes on the same level that way it would of been less depth traversal  but it would of added a lot more connections
// Making it become less efficent over time
//
// Solution
// The solution I tried to work out was to have the pascal formula be added to the tree based on the current node.
// That way it would be broken up into triangles
// example
//                      1
//                    /   \
//                   1       1
//
//                    1            1
//                  / \          /  \
//                1    2       2     1
// That way I can recurseivley go through and sort it into proper order while already having the figures
// I also tried to find an equation I can use to determine the value based on level and then change the nodes value to it
//        
