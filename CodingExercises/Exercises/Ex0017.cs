using Exercises;

/*
Difficulty: Easy
Problem: Single Number

Description:
Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

*** You must implement a solution with a linear runtime complexity and use only constant extra space. ***

Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1

Constraints:
1 <= nums.length <= 3 * 104
-3 * 104 <= nums[i] <= 3 * 104
Each element in the array appears twice except for one element which appears only once.
*/

[Exercise("ex0017")]
public class Ex0017 : IExercise
{
    public void Run()
    {
        int[] input = [2, 2, 1];       // 1
        // int[] input = [4, 1, 2, 1, 2]; // 4
        // int[] input = [1];             // 1
        
        int output = SingleNumber(input);
        Console.WriteLine(output);
    }

    /*
    Because of the requirement that you use only constant extra space, this problem cannot be solved
    with a separate data structure (Dictionary/frequency map, etc).

    The solution (trick) is to simply iterate through the array and XOR every element together.

    The time complexity here is O(n).

    Because we only use a single integer variable (`result`) for storage, regardless of the input size,
    this gets us a space complexity of O(1).

    Had we used a Dictionary, that would use O(n) extra space (where n is the number of unique elements).
    */
    public int SingleNumber(int[] nums)
    {
        int result = 0;
        foreach (int num in nums) 
        {
            result = result ^ num;
        }
        return result;
    }
}
