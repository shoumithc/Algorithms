using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class LevelOrderTraversal
    {
        /*
  Binary Tree Level Order Traversal - LeetCode:
  https://leetcode.com/problems/binary-tree-level-order-traversal/
  This code passes all Leetcode test cases as of Feb. 3 2019
  Runtime: 1 ms, faster than 82.85% of Java online submissions for Binary Tree Level Order Traversal.
  Memory Usage: 26.5 MB, less than 64.46% of Java online submissions for Binary Tree Level Order Traversal.
  The video to explain this code is here: https://www.youtube.com/watch?v=gcR28Hc2TNQ
*/

        

        public List<List<int>> levelOrder(TreeNode root)
        {

            if (root == null)
            {
                return new List<List<int>>();
            }

            /*
              The list to hold the level by level layers of the tree
            */
            List<List<int>> levelsList = new List<List<int>>();

            /*
              Our queue to enforce a traversal in a breadth-first manner
            */
            Queue<TreeNode> queue = new Queue<TreeNode>();

            /*
              Add the root node to start the breadth first search
            */
            queue.Enqueue(root);

            /*
              We will continue the breadth first search as long as
              there are nodes to process.

              We do not need a hashtable to track nodes already
              visited since a tree is an acyclic connected graph.
              Each iteration will process a layer of the tree.
            */
            while (queue.Count>0)
            {

                /*
                  The list to hold all the node's values in the
                  layer we are about to process
                */
                List<int> currentLayer = new List<int>();

                /*
                  We will get the size of the layer in the queue
                  that we need to process so that we know how
                  many nodes our for loop needs to process
                */
                int layerSize = queue.Count;

                for (int i = 0; i < layerSize; i++)
                {

                    /*
                      Remove the nodes so that we can process it
                    */
                    TreeNode currentNode = queue.Dequeue();

                    /*
                      Add the node's value to the current layer list
                    */
                    currentLayer.Add(currentNode.val);

                    /*
                      If this node has a left add it to be
                      processed for the next layer
                    */
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }

                    /*
                      If this node has a right add it to be
                      processed for the next layer
                    */
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }

                }

                /*
                  Notice how currentLayer is a new list on each iteration
                  of the while loop. We do not need to worry about deep
                  copying anything here.
                */
                levelsList.Add(currentLayer);

            }

            return levelsList;
        }



        public List<List<int>> LevelOrder(TreeNode root)
        {

            if (root == null)
            {
                return new List<List<int>>();
            }
            List<List<int>> levelsList = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            /*
              We will continue the breadth first search as long as
              there are nodes to process.

              We do not need a hashtable to track nodes already
              visited since a tree is an acyclic connected graph.
              Each iteration will process a layer of the tree.
            */
            while (queue.Count > 0)
            {             
                List<int> currentLayer = new List<int>();
                int layerSize = queue.Count;

                for (int i = 0; i < layerSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    currentLayer.Add(currentNode.val);
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }

                }
                levelsList.Add(currentLayer);
            }

            return levelsList;
        }


    }
}
