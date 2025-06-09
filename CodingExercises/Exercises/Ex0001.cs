using Exercises;

/*
Topic: Arrays & Strings
Difficulty: Easy
Problem: Find First Non-Repeating Character

Description:
Write a method that takes a string as input and finds the first character that does not repeat anywhere else in the string. 
The method should be case-sensitive (i.e., 'a' and 'A' are considered different characters). 
If all characters repeat or the string is empty, return the null character '\0'.

Examples:

Input: "swiss"
Output: 'w'
(Explanation: 's' repeats. 'w' is the first character that does not.)

Input: "stress"
Output: 't'
(Explanation: 's' repeats. 't' is the first non-repeating character. 'r' and 'e' also repeat.)

Input: "aabbcc"
Output: '\0'
(Explanation: All characters in the string repeat.)
*/

[Exercise("ex0001")]
public class Ex0001 : IExercise
{
    public void Run()
    {
        // Console.WriteLine("Hello from exercise 0001!");
        string input = "swiss";
        // string input = "stress";
        // string input = "aabbcc";
        
        char output = FirstNonRepeatingChar(input);
        Console.WriteLine(output);
    }

    public char FirstNonRepeatingChar(string s)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>();

        // First pass: Build the frequency map
        foreach (char c in s)
        {
            if (!counts.ContainsKey(c))
            {
                counts.Add(c, 0);
            }

            counts[c]++;
        }

        // Second pass: iterate through the original string to find the first
        // character with a count of 1. This preserves the order.
        foreach (char c in s)
        {
            if (counts[c] == 1)
            {
                return c;
            }
        }

        return '\0';
    }
}
