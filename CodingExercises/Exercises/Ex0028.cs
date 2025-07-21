using Exercises;

/*
Contains Duplicate
Topic: Arrays / Hash Tables

Difficulty: Easy

Problem:
Given an integer array nums, return true if any value appears at least twice in the array, 
and false if every element is distinct.

Examples:

Input: nums = [1,2,3,1]
Output: true

Input: nums = [1,2,3,4]
Output: false

Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true
*/

[Exercise("ex0028")]
public class Ex0028 : IExercise
{
    public void Run()
    {
        // int[] input = [1,2,3,1];
        // int[] input = [1,2,3,4];
        int[] input = [1,1,1,3,3,4,3,2,4,2];
        bool output = ContainsDuplicate(input);
        Console.WriteLine(output);
    }

    public bool ContainsDuplicate(int[] nums)
    {
        var seen = new HashSet<int>();

        foreach(int num in nums)
        {
            if (seen.Contains(num))
            {
                return true;
            }
            else
            {
                seen.Add(num);
            }
        }

        return false;
    }
}
