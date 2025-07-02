using Exercises;

/*
Topic: Arrays / Hash Tables / Sliding Window
Difficulty: Medium

Longest Substring Without Repeating Characters

Problem:
Given a string s, find the length of the longest substring without repeating characters.

Definitions:
A substring is a contiguous sequence of characters within a string. 
(e.g., "abc" is a substring of "abcabcbb", but "ac" is not).

Examples:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Input: s = "pwwkew"

Output: 3
Explanation: The answer is "wke", with the length of 3. 
Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/

[Exercise("ex0018")]
public class Ex0018 : IExercise
{
    public void Run()
    {
        // string input = "abcabcbb"; // 3
        // string input = "bbbbb"; // 1
        // string input = "pwwkew"; // 3
        string input = "dvdf"; // 3
        int output = LengthOfLongestSubstring(input);
        Console.WriteLine(output);
    }

    public int LengthOfLongestSubstring(string s)
    {
        int left = 0;
        int currentWindowLength = 0;
        int maxLength = 0;
        var window = new HashSet<char>();

        // The `left` and `right` pointers define a "sliding" window (the substring).
        // `right` iterates through the entire string.
        // `left` marks the beginning of the window, 
        // only moving forward to shrink the window when a duplicate is found.
        for (int right = 0; right < s.Length; right++)
        {
            // If a duplicate char is found, shrink the window from the left
            // until the duplicate is removed.
            while (window.Contains(s[right]))
            {
                window.Remove(s[left]);
                left++;
            }

            // Add the current character to the window's set
            window.Add(s[right]);

            // Update the max length with the size of the current valid window
            currentWindowLength = (right - left) + 1;
            maxLength = Math.Max(maxLength, currentWindowLength);
        }

        return maxLength;
    }
}
