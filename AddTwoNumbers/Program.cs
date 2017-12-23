using System;
using System.Collections.Generic;

namespace AddTwoNumbers
{
    internal class Program
    {   
        public static void Main(string[] args)
        {
            var sol = new Solution();
            var k =Solution.AddTwoNumbers(new ListNode(2)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(3)
                    }
                }, new ListNode(5)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(4)
                    }
                }
            );
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        
        public class Solution
        {
            public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                return Sum(l1, l2, 0);
            }

            private static ListNode Sum(ListNode l1, ListNode l2, int f)
            {
                int v = (l1?.val ?? 0) + (l2?.val ?? 0) + f;
                f = v / 10;
                v %= 10;
                l1 = l1?.next;
                l2 = l2?.next;
                var node = new ListNode(v);
                if (f > 0)
                    node.next = Sum(l1, l2, f);
                else if (l1 != null && l2 != null)
                    node.next = Sum(l1, l2, f);
                else if (l1 != null)
                    node.next = l1;
                else if (l2 != null)
                    node.next = l2;
                return node;
            }
        }
    }
}