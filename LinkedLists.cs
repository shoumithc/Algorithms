using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

 public class ListNode
{
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
}

    public class LinkedLists
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode addition = new ListNode(0);
            var baseNum = addition;
            bool carryOver = false;
            while (l1!=null || l2!= null)
            {
                int sum = 0;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                sum=carryOver ? sum + 1 : sum + 0;
                if (sum >= 10)
                {
                    addition.next = new ListNode(sum % 10);
                    carryOver = true;
                }
                else
                {
                    addition.next = new ListNode(sum);
                    carryOver = false;
                }
                addition = addition.next;
            }
            if(carryOver)
                addition.next = new ListNode(1);
            return baseNum.next;
        }
    }
}
