using Exercises;

/*
Topic: Linked Lists / Two Pointers
Difficulty: Medium
Problem: Remove Nth Node From End of List

Description:
Given the head of a linked list and an integer n, remove the nth node from the end of the list and return its head.

Examples:

Input: head = [1, 2, 3, 4, 5], n = 2
Output: [1, 2, 3, 5]
(Explanation: The 2nd node from the end is the node with value 4. We remove it.)

Input: head = [1], n = 1
Output: [] (An empty list, represented by null)
(Explanation: We remove the only node in the list.)

Input: head = [1, 2], n = 1
Output: [1]
(Explanation: The 1st node from the end is the node with value 2. We remove it.)
*/

[Exercise("ex0008")]
public class Ex0008 : IExercise
{
    public void Run()
    {
        int[] list = {1, 2, 3, 4, 5};
        int offset = 2;
        
        // int[] list = {1};
        // int offset = 1;
        
        // int[] list = {1, 2};
        // int offset = 1;

        // int[] list = {1, 2, 3, 4, 5};
        // int offset = 0;

        var head = CreateLinkedList(list);
        var result = RemoveNthFromEnd(head, offset);
        
        PrintList(result);
    }

    // The solution
    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        // 1. Create a dummy node that points to the real head.
        ListNode dummy = new ListNode(0, head);

        // 2. Start two pointers, left and right, at the beginning of our new structure.
        // The 'left' pointer will end up on the node *before* the one we want to remove.
        ListNode left = dummy; 
        // The 'right' pointer will be our "scout".
        ListNode right = head;

        // 3. Move the 'right' pointer forward by 'n' steps to create the gap.
        for (int i = 0; i < n; i++)
        {
            right = right.next;
        }

        // 4. Now, move both pointers forward together until the 'right' scout hits the end.
        while (right != null)
        {
            left = left.next;
            right = right.next;
        }

        // At this point, 'left' is pointing to the node right before the one to be deleted.
        // For example, if we delete '4', 'left' is on '3'.

        // 5. Re-wire the 'next' pointer to skip over the node to be deleted.
        left.next = left.next.next;

        // 6. The original list is now modified. The dummy node's 'next' pointer
        // points to the true head of the modified list.
        return dummy.next;
    }

    public ListNode CreateLinkedList(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return null;
        }

        ListNode head = new ListNode(arr[0]);
        ListNode current = head;
        
        for (int i = 1; i < arr.Length; i++)
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }
        
        return head;
    }

    // Helper method to print the list to the console
    public void PrintList(ListNode head)
    {
        ListNode current = head;
        
        while (current != null)
        {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        
        Console.Write("null");
    }
}

/* 
Commented out because this class already exists in the `Exercises` namespace 
from the first linked list exercise. 
*/
// public class ListNode 
// {
//     public int val;
//     public ListNode next;
    
//     public ListNode(int val = 0, ListNode? next = null) 
//     {
//         this.val = val;
//         this.next = next;
//     }
// }
