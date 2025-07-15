using Exercises;

/*
Product of Array Except Self
Topic: Arrays / Prefix-Suffix

Difficulty: Medium

Problem:
Given an integer array nums, return an array answer such that answer[i] 
is equal to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and does not use the division operation.

Examples:

Input: nums = [1,2,3,4]
Output: [24,12,8,6]

Explanation:
answer[0] is 2 * 3 * 4 = 24
answer[1] is 1 * 3 * 4 = 12
answer[2] is 1 * 2 * 4 = 8
answer[3] is 1 * 2 * 3 = 6

---

Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
*/

[Exercise("ex0027")]
public class Ex0027 : IExercise
{
    public void Run()
    {
        int[] input = [1,2,3,4];
        // int[] input = [-1,1,0,-3,3];
        int[] output = ProductExceptSelf(input);
        Console.WriteLine("[" + string.Join(", ", output) + "]");
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] answer = new int[n];

        // Pass 1: Calculate left products (prefixes)
        answer[0] = 1;
        for (int i = 1; i < n; i++)
        {
            answer[i] = nums[i - 1] * answer[i - 1];
        }

        // Pass 2: Calculate right products (suffixes) and multiply
        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            answer[i] = answer[i] * rightProduct;
            rightProduct *= nums[i];
        }

        return answer;
    }
}
