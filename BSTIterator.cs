using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class BSTIterator
    {
        Stack<TreeNode> s = new Stack<TreeNode>();
        bool up = false;

        public BSTIterator(TreeNode root)
        {
            TreeNode current = root;
            while (current != null)
            {
                s.Push(current);
                current = current.left;
            }
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (s.Count == 0)
                return -1;

            if (s.Count > 0)
            {
                if (!up)
                {
                    while (s.Peek().left != null)
                    {
                        s.Push(s.Peek().left);
                    }
                }
                var current = s.Pop();

                up = true;
                if (current.right != null)
                {
                    s.Push(current.right);
                    up = false;
                }
                return current.val;
            }
            else
                return -1;


            return -1;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return s.Count > 0;
        }

        public TreeNode InsertIntoBST(TreeNode root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }

            if(value<=root.val)
                InsertIntoBST(root.left,value);
            InsertIntoBST(root.right, value);
            return root;
        }

        public TreeNode CreateBSTFromSortedList(List<int> sortedValues,int start, int end)
        {
            if (start>end == null)
            {
                return null;
            }
            int middle = (start + end) / 2;
            var root = new TreeNode(sortedValues[middle])
            {
                left = CreateBSTFromSortedList(sortedValues, start, middle - 1),
                right = CreateBSTFromSortedList(sortedValues, middle + 1, end)
            };
            return root;
        }
    }

    /**
     * Your BSTIterator object will be instantiated and called as such:
     * BSTIterator obj = new BSTIterator(root);
     * int param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */

}