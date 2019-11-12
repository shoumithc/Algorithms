using System.Collections.Generic;

namespace Algorithms
{
    public class LInkedListIsCycle
    {
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> nodesSeen = new HashSet<ListNode>();
            while (head != null)
            {
                if (nodesSeen.Contains(head))
                {
                    return true;
                }
                else
                {
                    nodesSeen.Add(head);
                }
                head = head.next;
            }
            return false;
        }

        //public static void Main()
        //{
        //    ListNode head = new ListNode(2);
        //    head.next=new ListNode(3);
        //    head.next.next = head;

        //    var linkedListCycle = new LInkedListIsCycle();
        //    linkedListCycle.HasCycle(head);
        //}
    }
}