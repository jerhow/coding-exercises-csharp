using Exercises;

/*
Topic: Arrays / Hash Tables
Difficulty: Easy
Problem: Two Sum

Description:
Write a method that takes an array of integers nums and an integer target. 
The method should return the indices of the two numbers in the array that add up to the target. 
You may assume that each input will have exactly one solution, 
and you may not use the same element twice. 
The order of the returned indices does not matter.

Examples:

Input: nums = [2, 7, 11, 15], target = 9
Output: [0, 1]
(Explanation: nums[0] + nums[1] is 2 + 7 = 9)

Input: nums = [3, 2, 4], target = 6
Output: [1, 2]
(Explanation: nums[1] + nums[2] is 2 + 4 = 6)

Input: nums = [3, 3], target = 6
Output: [0, 1]
*/

[Exercise("ex0004")]
public class Ex0004 : IExercise
{
    public void Run()
    {
        int[] input1 = [2, 7, 11, 15];
        int input2 = 9;
        // int[] input1 = [3, 2, 4];
        // int input2 = 6;
        // int[] input1 = [3, 3];
        // int input2 = 6;
        int[] output = TwoSum(input1, input2);
        // Console.WriteLine(output);
        Console.WriteLine(string.Join(", ", output));
    }

    public int[] TwoSum(int[] nums, int target)
    {
        // Dictionary to store the numbers we've seen and their indices.
        // Key: The number from the array.
        // Value: The index of that number.
        Dictionary<int, int> seenNumbers = new Dictionary<int, int>();

        // We only need one loop. 
        // This, combined with the inner Dict key lookup (constant time),
        // gets us a O(n) linear time solution.
        for (int i = 0; i < nums.Length; i++)
        {
            int currentNum = nums[i];
            int complement = target - currentNum;

            // Check if the complement we need is already in our dictionary.
            // This lookup is an average O(1) operation.
            if (seenNumbers.ContainsKey(complement))
            {
                // If it is, we've found our solution.
                return [seenNumbers[complement], i];
            }

            // If we haven't found the complement, add the current number
            // and its index to the dictionary for future checks.
            // We do this at the end to handle cases like [3, 3] target = 6.
            if (!seenNumbers.ContainsKey(currentNum))
            {
                seenNumbers.Add(currentNum, i);
            }
        }

        // Per the problem, a solution always exists, but for completeness...
        return [];
    }

    /*
    Array.IndexOf will always find the first match, which causes a bug when there are
    duplicate values in `nums`.
    This solution is also O(n^2) quadratic. Keeping it for reference.
    */
    public int[] TwoSumArraySubset(int[] nums, int target) 
    {
        for (int n = 0; n < nums.Length; n++)
        {
            int[] numsSubset = nums.Where((val, idx) => idx != n).ToArray();
            if (numsSubset.Contains(target - nums[n]))
            {
                return [n, Array.IndexOf(nums, (target - nums[n]))];
            }
        }

        return [];
    }

    /*
    The brute force approach. O(n^2) quadratic.
    */
    public int[] TwoSumQuadratic(int[] nums, int target) 
    {
        for (int x = 0; x < nums.Length; x++)
        {
            for (int y = 0; y < nums.Length; y++)
            {
                if (x == y)
                {
                    continue;
                }

                if (nums[x] + nums[y] == target)
                {
                    return [x, y];
                }
            }
        }

        return [];
    }

    public int[] TwoSum__(int[] nums, int target) 
    {
        foreach (int n in nums)
        {
            if (nums.Contains(target - n))
            {
                return [n, (target - n)];
            }
        }

        return [];
    }
}
