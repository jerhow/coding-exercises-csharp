using Exercises;

/*
Topic: Arrays / Hash Tables
Difficulty: Medium

Top K Frequent Elements

Problem:
Given an integer array nums and an integer k, return the k most frequent elements. 
You may return the answer in any order.

Examples:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
Explanation: 1 appears 3 times, 2 appears 2 times, and 3 appears once. The two most frequent are 1 and 2.

---

Input: nums = [1], k = 1
Output: [1]
*/

[Exercise("ex0021")]
public class Ex0021 : IExercise
{
    public void Run()
    {
        int[] input1 = [1, 1, 1, 2, 2, 3];
        int input2 = 2;

        // int[] input1 = [1];
        // int input2 = 1;

        int[] result = TopKFrequent(input1, input2);
        string printableResult = String.Join(", ", result);
        Console.WriteLine(printableResult);
    }

    // This solution runs in O(n log n) in the worst case (where every element is unique),
    // which is significantly better than the other solution.
    public int[] TopKFrequent(int[] nums, int k)
    {
        // Build the frequency map. This is O(n).
        var freqMap = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (!freqMap.ContainsKey(num))
            {
                freqMap[num] = 0;
            }
            freqMap[num]++;
        }

        // Use LINQ to sort, take, and select.
        // The sorting step is O(m log m), where m is the number of unique elements.
        int[] result = freqMap
            .OrderByDescending(kvp => kvp.Value) // Sort by frequency (the dictionary Value)
            .Take(k)                             // Take the first k elements
            .Select(kvp => kvp.Key)              // Select only the number (the dictionary Key)
            .ToArray();                          // Convert to an array

        return result;
    }

    // This solution works, but has a total time complexity of O(n * k), which is not ideal.
    // It avoids using LINQ, but it has more moving pieces to think about.
    public int[] TopKFrequentLessEfficient(int[] nums, int k)
    {
        if (nums.Length == 0)
        {
            return [];
        }

        var freqMap = new Dictionary<int, int>(); // frequency map

        foreach (int num in nums)
        {
            if (!freqMap.ContainsKey(num))
            {
                freqMap.Add(num, 0);
            }

            freqMap[num]++;
        }

        int[] results = new int[k];
        int highCount = 0;
        int highElement = 0;

        for (int j = 0; j < k; j++)
        {
            foreach (KeyValuePair<int, int> kvp in freqMap)
            {
                if (kvp.Value > highCount)
                {
                    highCount = kvp.Value;
                    highElement = kvp.Key;
                }
            }

            results[j] = highElement;
            freqMap.Remove(highElement);
            highCount = 0;
        }

        return results;
    }
    
}
