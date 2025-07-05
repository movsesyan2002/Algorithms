
 public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null) {
          this.val = val;
          this.next = next;
      }
  }

public class Solution
{
    public static ListNode SortList(ListNode head)
    {

        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode right = slow.next;
        ListNode left = head;
        slow.next = null;


        left = SortList(left);
        right = SortList(right);
        left = Merge(left, right);

        return left;
    }

    public static ListNode Merge(ListNode list1, ListNode list2)
    {

        ListNode dummy = new ListNode();
        ListNode ptr = dummy;

        while (list1 != null && list2 != null)
        {

            if (list1.val < list2.val)
            {
                dummy.next = list1;
                list1 = list1.next;
            }

            else
            {
                dummy.next = list2;
                list2 = list2.next;
            }

            dummy = dummy.next;
        }

        if (list1 == null)
        {
            dummy.next = list2;
        }

        if (list2 == null)
        {
            dummy.next = list1;
        }

        return ptr.next;
    }
}

// class Program
// {
//     static void Main(string[] args)
//     {
//         ListNode list = new ListNode(1);
//         ListNode list2 = new ListNode(2, list);
//         ListNode list3 = new ListNode(3, list2);
//         ListNode list4 = new ListNode(4, list3);

//         ListNode head = Solution.SortList(list4);

//     }
// }