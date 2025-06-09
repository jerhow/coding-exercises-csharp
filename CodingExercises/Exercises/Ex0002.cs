using Exercises;

/*
Topic: Hash Tables (Dictionary<TKey, TValue>)
Difficulty: Easy
Problem: Most Frequent Element

Description:
Write a method that takes an array of integers and returns the integer that appears most frequently. 
If there is a tie for the most frequent element, you may return any one of the tied elements. 
You can assume the input array will not be empty.

Examples:

Input: [1, 3, 1, 3, 2, 1]
Output: 1
(Explanation: 1 appears 3 times, 3 appears 2 times, and 2 appears 1 time.)

Input: [4, 5, 6, 6, 4, 3]
Output: 4 or 6
(Explanation: 4 and 6 both appear twice, which is the highest frequency.)

Input: [0, 0, 0, 0, 0]
Output: 0
*/

[Exercise("ex0002")]
public class Ex0002 : IExercise
{
    public void Run()
    {
        // Console.WriteLine("Hello from exercise 0002");
        int[] input = [1, 3, 1, 3, 2, 1];
        // int[] input = [4, 5, 6, 6, 4, 3];
        // int[] input = [0, 0, 0, 0, 0];
        int output = MostFrequentElement(input);
        Console.WriteLine(output);
    }

    public int MostFrequentElement(int[] nums) 
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();

        // Pass 1: Build the frequency map
        // Time: O(n), Space: O(k)
        foreach(int num in nums)
        {
            if (!counts.ContainsKey(num))
            {
                counts.Add(num, 0);
            }

            counts[num]++;
        }

        
        // Pass 2: Find the element with the highest frequency.
        // Time: O(k), where k is the number of unique elements.
        int mostFrequentElement = 0;
        int maxCount = 0;

        foreach (KeyValuePair<int, int> pair in counts)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                mostFrequentElement = pair.Key;
            }
        }

        return mostFrequentElement;
    }

    public int MostFrequentElement_(int[] nums) 
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();

        foreach(int num in nums)
        {
            if (!counts.ContainsKey(num))
            {
                counts.Add(num, 0);
            }

            counts[num]++;
        }

        var sortedList = counts.OrderByDescending(kvp => kvp.Value).ToList();
        return sortedList.First().Key;
    }
}
