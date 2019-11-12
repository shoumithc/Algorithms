
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int value)
        {
            data = value;
            left = right = null;
        }
    }

    public class LowestCommonAncestorInBinaryTree
    {
        public Node root { get; set; }
        private List<int> path1 = new List<int>();
        private List<int> path2 = new List<int>();

        public Node lca(Node root, Node n1, Node n2)
        {
            if (root == null)
            {
                return null;
            }
            if (root == n1 || root == n2)
            {
                return root;
            }

            Node left = lca(root.left, n1, n2);
            Node right = lca(root.right, n1, n2);

            if (left != null && right != null)
            {
                return root;
            }
            return left != null ? left : right;
        }


        public Node LowestCommonAncester(Node root, Node n1, Node n2)
        {
            if (root == null)
                return null;
            if (root.data == n1.data || root.data == n2.data)
                return root;

            Node left = LowestCommonAncester(root.left, n1, n2);
            Node right = LowestCommonAncester(root.right, n1, n2);
            if (left != null && right != null)
                return root;
            return left ?? right;

        }



        //public static void Main(String[] args)
            //{
            //    LowestCommonAncestorInBinaryTree tree = new LowestCommonAncestorInBinaryTree();
            //    tree.root = new Node(1);
            //    tree.root.left = new Node(2);
            //    tree.root.right = new Node(3);
            //    var four = new Node(4);
            //    tree.root.left.left = four;
            //    tree.root.left.right = new Node(5);
            //    tree.root.right.left = new Node(6);
            //    var seven = new Node(7);
            //    tree.root.right.right = seven;

            //    Console.WriteLine("LCA(4, 5): " + tree.lca(tree.root, four, seven).data);
            //    //Console.WriteLine("LCA(4, 6): " + tree.findLCA(4, 6));
            //    //Console.WriteLine("LCA(3, 4): " + tree.findLCA(3, 4));
            //    //Console.WriteLine("LCA(2, 4): " + tree.findLCA(2, 4));

            //    //}
            //}
        }

    public class LowestCommonAncester
    {

        public Node root { get; set; }
        private List<int> path1 = new List<int>();
        private List<int> path2 = new List<int>();

        // Finds the path from root node to given root of the tree. 
        int findLCA(int n1, int n2)
        {
            path1.Clear();
            path2.Clear();
            return findLCAInternal(root, n1, n2);
        }

        private int findLCAInternal(Node root, int n1, int n2)
        {

            if (!findPath(root, n1, path1) || !findPath(root, n2, path2))
            {
                Console.WriteLine((path1.Count > 0) ? "n1 is present" : "n1 is missing");
                Console.WriteLine((path2.Count > 0) ? "n2 is present" : "n2 is missing");
                return -1;
            }

            int i;
            for (i = 0; i < path1.Count && i < path2.Count; i++)
            {

                // System.out.println(path1.get(i) + " " + path2.get(i)); 
                if (!path1[i].Equals(path2[i]))
                    break;
            }

            return path1[i - 1];
        }

        // Finds the path from root node to given root of the tree, Stores the 
        // path in a vector path[], returns true if path exists otherwise false 
        private bool findPath(Node root, int n, List<int> path)
        {
            // base case 
            if (root == null)
            {
                return false;
            }

            // Store this node . The node will be removed if 
            // not in path from root to n. 
            path.Add(root.data);

            if (root.data == n)
            {
                return true;
            }

            if (root.left != null && findPath(root.left, n, path))
            {
                return true;
            }

            if (root.right != null && findPath(root.right, n, path))
            {
                return true;
            }

            // If not present in subtree rooted with root, remove root from 
            // path[] and return false 
            path.Remove(path.Count - 1);

            return false;
        }
        //public static void main(String[] args)
        //{
        //    LowestCommonAncester tree = new LowestCommonAncester();
        //    tree.root = new Node(1);
        //    tree.root.left = new Node(2);
        //    tree.root.right = new Node(3);
        //    tree.root.left.left = new Node(4);
        //    tree.root.left.right = new Node(5);
        //    tree.root.right.left = new Node(6);
        //    tree.root.right.right = new Node(7);

        //    Console.WriteLine("LCA(4, 5): " + tree.findLCA(4, 5));
        //    Console.WriteLine("LCA(4, 6): " + tree.findLCA(4, 6));
        //    Console.WriteLine("LCA(3, 4): " + tree.findLCA(3, 4));
        //    Console.WriteLine("LCA(2, 4): " + tree.findLCA(2, 4));

        //}
        // Driver code 

    }
}
