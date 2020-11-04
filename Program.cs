using System;

namespace CommonAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new ListNode(1){Next = new ListNode(2){Next = new ListNode(3){Next = new ListNode(4){Next = new ListNode(5)}}}};

            var node1 = new ListNode(9){Next = new ListNode(9){Next = new ListNode(9)}};
            var node2 = new ListNode(9){Next = new ListNode(9){Next = new ListNode(9){Next = new ListNode(9){Next = new ListNode(9)}}}};

            // var added = Algorithms.AddTwoNumbersAsLists(node1, node2);
            var added1 = Algorithms.AddTwoNumbersAsListsBetter(node1, node2);
        }
    }
}
