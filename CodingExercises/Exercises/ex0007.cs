using Exercises;

/*
Topic: Linked Lists / Pointer Manipulation
Difficulty: Easy
Problem: Reverse a Linked List

Description:
Given the head of a singly-linked list, reverse the list, and return the new head of the reversed list.

Examples:

Input: head = [1, 2, 3, 4, 5]
(This represents a list: 1 -> 2 -> 3 -> 4 -> 5 -> null)
Output: Node with value 5
(The new list should be: 5 -> 4 -> 3 -> 2 -> 1 -> null)

Input: head = [1, 2]
(This represents a list: 1 -> 2 -> null)
Output: Node with value 2
(The new list should be: 2 -> 1 -> null)

Input: head = [] (An empty list, so head is null)
Output: null
*/

[Exercise("ex0007")]
public class Ex0007 : IExercise
{
    public void Run()
    {
        int[] input = {1, 2, 3, 4, 5};
        var head = CreateLinkedList(input);
        var reversedList = ReverseList(head);
        
        PrintList(reversedList);
    }

    // The solution
    public ListNode ReverseList(ListNode head) 
    {
        if (head == null) return null;

        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            // 1. Save the next node
            ListNode nextTemp = current.next; 
            
            // 2. Reverse the current node's pointer
            current.next = prev; 
            
            // 3. Move prev pointer one step forward
            prev = current; 
            
            // 4. Move current pointer one step forward
            current = nextTemp; 
        }

        // When the loop is done, 'prev' is the new head of the reversed list
        return prev;
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
