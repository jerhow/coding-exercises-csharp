using Exercises;

/*
Merge Intervals
Topic: Arrays / Sorting

Difficulty: Medium

Problem:
Given an array of intervals where intervals[i] = [start_i, end_i], 
merge all overlapping intervals, and return an array of the non-overlapping intervals 
that cover all the intervals in the input.

Examples:

Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, they are merged into [1,6].

---

Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
*/

[Exercise("ex0026")]
public class Ex0026 : IExercise
{
    public void Run()
    {
        int[][] input = [[1,3],[2,6],[8,10],[15,18]];
        // int[][] input = [[1,4],[4,5]];
        int[][] output = Merge(input);
        PrintResult(output);
    }

    public int[][] Merge(int[][] intervals) 
    {
        // Handle edge case of empty or single-interval input
        if (intervals.Length <= 1) 
        {
            return intervals;
        }

        // 1. Sort the intervals based on their start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // 2. Initialize a list to store the merged intervals
        var mergedIntervals = new List<int[]>();
        mergedIntervals.Add(intervals[0]); // Add the first interval to start

        // 3. Iterate through the rest of the intervals
        for (int i = 1; i < intervals.Length; i++) 
        {
            int[] currentInterval = intervals[i];
            int[] lastMergedInterval = mergedIntervals[mergedIntervals.Count - 1];

            // 4. Compare and merge if they overlap
            if (currentInterval[0] <= lastMergedInterval[1]) 
            {
                // Merge: update the end of the last merged interval
                lastMergedInterval[1] = Math.Max(lastMergedInterval[1], currentInterval[1]);
            } 
            else 
            {
                // No overlap: Add the current interval as a new one
                mergedIntervals.Add(currentInterval);
            }
        }

        // 5. Convert the list back to an array and return
        return mergedIntervals.ToArray();
    }

    public void PrintResult(int[][] result)
    {
        foreach (var row in result)
        {
            Console.WriteLine("[" + string.Join(", ", row) + "]");
        }
    }
    
}
