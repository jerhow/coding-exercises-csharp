using Exercises;

/*
Topic: Linked Lists / Merging

Difficulty: Easy

Problem: Merge Two Sorted Lists

Description:
You are given the heads of two sorted linked lists, list1 and list2.

Merge the two lists into one new sorted list. 
The new list should be made by splicing together the nodes of the first two lists. 
Return the head of the merged linked list.

Examples:

Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]

Input: list1 = [], list2 = [0]
Output: [0]
*/

[Exercise("ex0009")]
public class Ex0009 : IExercise
{
    public void Run()
    {
        ListNode list1 = CreateLinkedList([1, 2, 4]);
        ListNode list2 = CreateLinkedList([1, 3, 4]);

        // ListNode list1 = CreateLinkedList([]);
        // ListNode list2 = CreateLinkedList([0]);

        ListNode result = MergeTwoLists(list1, list2);
        
        PrintList(result);
    }

    // The solution
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }

            tail = tail.next; // Advance the tail pointer after each attachment
        }

        // At this point, one of the lists will be null, but the other might still have nodes left.
        // Attach the rest of the non-null list to `tail`.
        // The assignment will be null anyway if both lists are null.
        tail.next = list1 ?? list2;

        return dummy.next; // Return the node _after_ the dummy node, which is the true head.
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
