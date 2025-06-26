using Exercises;

/*
Topic: Linked Lists / Two Pointers

Difficulty: Easy

Problem: Linked List Cycle

Description:
Given head, the head of a linked list, determine if the linked list has a cycle in it.

A cycle exists if there is some node in the list that can be reached again by continuously following the next pointer. Internally, the last node's next pointer will point to an earlier node in the list instead of null.

Return true if there is a cycle, and false otherwise.

Examples:

Input: head = [3,2,0,-4], with the last node (-4) pointing to the node with value 2.
(This represents a list: 3 -> 2 -> 0 -> -4 -> 2 [and the cycle continues])
Output: true
(There is a cycle, as the tail connects back to the second node.)

Input: head = [1,2], with the last node (2) pointing to the node with value 1.
(This represents a list: 1 -> 2 -> 1 [and the cycle continues])
Output: true

Input: head = [1]
(This represents a list: 1 -> null)
Output: false
(There is no cycle.)
*/

[Exercise("ex0010")]
public class Ex0010 : IExercise
{
    public void Run()
    {
        ListNode a = new ListNode(3);
        ListNode b = new ListNode(2);
        ListNode c = new ListNode(0);
        ListNode d = new ListNode(-4);

        // Non-circular list:
        // a.next = b;
        // b.next = c;
        // c.next = d;
        // d.next = null;

        // List with cycle:
        a.next = b;
        b.next = c;
        c.next = d;
        d.next = b;

        bool result = HasCycle(a);
        Console.WriteLine(result);
    }

    // The solution
    public bool HasCycle(ListNode head) 
    {
        // Start both pointers at the head
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) 
        {
            // Advance the pointers
            slow = slow.next;
            fast = fast.next.next;

            // Check whether the pointers themselves have met
            if (slow == fast) 
            {
                return true; // Cycle detected
            }
        }

        // If the loop finishes, the fast pointer has reached the end (null)
        return false; // No cycle
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
