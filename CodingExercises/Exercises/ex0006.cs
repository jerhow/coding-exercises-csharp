using Exercises;

/*
Topic: Linked Lists / Two Pointers
Difficulty: Easy
Problem: Middle of the Linked List

Description:
Given the head of a singly-linked list, write a method that returns the middle node of the linked list.

If there are two middle nodes (i.e., the list has an even number of nodes), 
return the second middle node.

Examples:

Input: head = [1, 2, 3, 4, 5]
(This represents a list: 1 -> 2 -> 3 -> 4 -> 5)
Output: Node with value 3
(This is the single middle node of the list)

Input: head = [1, 2, 3, 4, 5, 6]
(This represents a list: 1 -> 2 -> 3 -> 4 -> 5 -> 6)
Output: Node with value 4
(There are two middle nodes, 3 and 4. We return the second one.)
*/

[Exercise("ex0006")]
public class Ex0006 : IExercise
{
    public void Run()
    {
        int[] input = {1, 2, 3, 4, 5, 6};
        var head = CreateLinkedList(input);
        var middleNode = MiddleNode(head);
        
        Console.WriteLine(middleNode.val);
        PrintList(middleNode);
    }

    // The solution
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null) return null;

        // Carry two pointers: `slow` moves by a single node, `fast` by two
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            Console.WriteLine(slow.val);
            Console.WriteLine(fast.val);
            Console.WriteLine("\n");
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
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

public class ListNode 
{
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode? next = null) 
    {
        this.val = val;
        this.next = next;
    }
}
