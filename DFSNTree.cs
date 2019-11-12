using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{

    public class NTreeNode
    {
        public int val;
        public List<NTreeNode> Children;

        public NTreeNode(int x)
        {
            Children = new List<NTreeNode>();
            val = x;
        }
    }

    public class DFSNTree
    {

        public static void DfsPath(NTreeNode root, NTreeNode target, List<int> pathList)
        {
            if (root == null)
            {
                pathList = new List<int>();
                return;
            }
            pathList.Add(root.val);
            if (root.val == target.val)
                return;
            foreach (var child in root.Children)
            {
                DfsPath(child, target, pathList);
            }
        }

    }

    public class BFSNTree
    {

        public static List<string> BfsPathLevelTraversal(NTreeNode root)
        {
            if (root == null)
                return null;
            List<string> levelList = new List<string>();
            Queue<NTreeNode> levelQueue=new Queue<NTreeNode>();
            levelQueue.Enqueue(root);
            while (levelQueue.Count>0)
            {
                int leveLength = levelQueue.Count;
                string levelString = string.Empty;
                for (int i = 0; i < leveLength; i++)
                {
                    var levelItem = levelQueue.Dequeue();
                    levelString += "-" + levelItem.val;
                    if (levelItem.Children != null)
                        levelItem.Children.ForEach(x => { levelQueue.Enqueue(x); });
                }
                levelList.Add(levelString);
            }
            return levelList;
        }

        //public static void Main()
        //{
        //    NTreeNode one = new NTreeNode(1);
        //    NTreeNode two = new NTreeNode(2);
        //    NTreeNode three = new NTreeNode(3);
        //    NTreeNode four = new NTreeNode(4);
        //    NTreeNode five = new NTreeNode(5);
        //    NTreeNode six = new NTreeNode(6);
        //    NTreeNode seven = new NTreeNode(7);
        //   two.Children.AddRange(new List<NTreeNode>{four,five});
        //   three.Children.AddRange(new List<NTreeNode> { six, seven });
        //    one.Children.AddRange(new List<NTreeNode> {two, three});
        //    BfsPathLevelTraversal(one);
        //    List<int> pathList = new List<int>();
        //    DFSNTree.DfsPath(one, seven, pathList);
        //}

    }
}
