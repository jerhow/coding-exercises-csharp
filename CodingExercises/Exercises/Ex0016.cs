using Exercises;

/*
Topic: Linked Lists
Difficulty: Easy
Problem: Remove Duplicates from Sorted List

Description:
Given the head of a sorted linked list, delete all duplicates such that each element appears only once. 
Return the linked list sorted as well.

Examples:
Input: head = [1,1,2]
Output: [1,2]

Input: head = [1,1,2,3,3]
Output: [1,2,3]

Constraints:
The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
*/

[Exercise("ex0016")]
public class Ex0016 : IExercise
{
    public void Run()
    {
        // ListNode input = CreateLinkedList([1, 1, 2]);
        ListNode input = CreateLinkedList([1, 1, 2, 3, 3]);
        ListNode result = DeleteDuplicates(input);
        PrintList(result);
    }

    // The solution
    public ListNode DeleteDuplicates(ListNode head) 
    {
        if (head == null) return null;

        // The key to this exercise is that the list is guaranteed to be sorted.
        // This simplifies the logic considerably (you only need one pointer).

        ListNode current = head;

        while (current != null && current.next != null) // Check both because we need to compare them each time
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }

    // Helper method to create the linked list so that we can run the exercise
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
