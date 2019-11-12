using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class SumOfLeftLeaves
    {
        public int sum = 0;
        public int SumOfLeftLeavesInBinaryTree(TreeNode root)
        {
            return SumOfLeft(root, false);
        }

        public int SumOfLeft(TreeNode node, bool isLeft)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.left == null && node.right == null)
            {
                return isLeft ? node.val : 0;
            }

            return SumOfLeft(node.left, true) + SumOfLeft(node.right, false);
        }


        public void CalculateSum(TreeNode root, int L, int R)
        {
            if (root == null)
                return;
            if (root.val >= L && root.val <= R)
                sum += root.val;
            if (L < root.val)
                 CalculateSum(root.left, L, R);
            if (root.val < R)
                 CalculateSum(root.right, L, R);
        }

        
    }
}
