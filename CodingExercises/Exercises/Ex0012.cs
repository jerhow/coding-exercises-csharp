using System;
using System.Collections.Generic;
using Exercises;

/*
Topic: Queues / Design

Difficulty: Easy

Problem: Number of Recent Calls

Description:
You are asked to implement a RecentCounter class. 
This class will count the number of recent requests within a certain time frame.

Your RecentCounter class should have the following:

A constructor, RecentCounter(), which initializes the counter with zero recent requests.

A method, int Ping(int t), which adds a new request at a specific time t (in milliseconds) 
and returns the number of requests that have happened in the past 3000 milliseconds (including the new one). 
Specifically, it should return the number of requests in the time range [t - 3000, t].

You can assume that each call to Ping will use a strictly larger value of t than the previous call.

Conceptual Hint:
Think about the stream of incoming pings. As a new Ping(t) arrives, you need to do two things:

Add the new time t to your collection of recent pings.

Remove any pings from your collection that are now too old (i.e., less than t - 3000).
*/

[Exercise("ex0012")]
public class Ex0012 : IExercise
{
    public void Run()
    {
        var rc = new RecentCounter();
        Console.WriteLine(rc.Ping(1));
        Console.WriteLine(rc.Ping(100));
        Console.WriteLine(rc.Ping(3001));
        Console.WriteLine(rc.Ping(3002));
    }
}

public class RecentCounter 
{
    private Queue<int> pings;
    private const int TIME_WINDOW = 3000;

    public RecentCounter() 
    {
        this.pings = new Queue<int>();
    }
    
    public int Ping(int t) 
    {
        // Add the new ping to the back of the queue
        this.pings.Enqueue(t);

        // Remove any pings from the front of the queue that are too old.
        // This loop continues until the ping at the front is recent enough.
        while (this.pings.Peek() < (t - TIME_WINDOW))
        {
            this.pings.Dequeue();
        }

        // Return the remaining count of pings in the queue
        return this.pings.Count;
    }
}
