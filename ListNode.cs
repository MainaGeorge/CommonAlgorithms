namespace CommonAlgorithms
{
    public class ListNode
    {
        public ListNode Next { get; set; }
        public int Value { get; set; }

        public ListNode(int value = 0, ListNode next = null)
        {
            Next = next;
            Value = value;
        }
    }
}
