using System;
using System.Collections.Generic;
using Exercises;

/*
Implement a Stack using Queues

Description:
Design and implement a class MyStack that simulates the behavior of a stack (LIFO) using only standard Queue operations (Enqueue, Dequeue, Peek, Count).

Requirements:
Your MyStack class should have the following methods:

- void Push(int x) — Push element x onto the stack.
- int Pop() — Removes the element on top of the stack and returns it.
- int Top() — Get the top element.
- bool Empty() — Returns whether the stack is empty.

Constraints:

You may use one or two queues (your choice).
You can use only standard queue operations: 
enqueue to back, dequeue from front, peek at front, check if empty, and check size.

The solution should have acceptable performance for an easy question (don’t worry about full optimality).

Example:

MyStack stack = new MyStack();
stack.Push(1);
stack.Push(2);
Console.WriteLine(stack.Top());   // returns 2
Console.WriteLine(stack.Pop());   // returns 2
Console.WriteLine(stack.Empty()); // returns false
*/

/*
## Reminder
Stack: LIFO
Queue: FIFO
*/

[Exercise("ex0013")]
public class Ex0013 : IExercise
{
    public void Run()
    {
        // var stack = new MyStackTwoQueues();
        var stack = new MyStackOneQueue();
        stack.Push(1);
        stack.Push(2);
        stack.Push(99);
        Console.WriteLine(stack.Top());   // returns 99
        Console.WriteLine(stack.Pop());   // returns 99
        Console.WriteLine(stack.Empty()); // returns false
    }
}

public class MyStackTwoQueues
{
    private Queue<int> queue1 = new();
    private Queue<int> queue2 = new();

    public void Push(int x) 
    {
        queue2.Enqueue(x);

        while (queue1.Count > 0)
        {
            queue2.Enqueue(queue1.Dequeue());
        }

        // Swap references
        (queue1, queue2) = (queue2, queue1);
    }

    public int Pop() 
    {
        return queue1.Dequeue();
    }

    public int Top() 
    {
        return queue1.Peek();
    }

    public bool Empty() 
    {
        return (queue1.Count == 0);
    }
}

public class MyStackOneQueue 
{
    private Queue<int> queue = new();

    public void Push(int x) 
    {
        queue.Enqueue(x);

        for (int i = 0; i < queue.Count - 1; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
    }

    public int Pop() {
        return queue.Dequeue();
    }

    public int Top() {
        return queue.Peek();
    }

    public bool Empty() {
        return queue.Count == 0;
    }
}
