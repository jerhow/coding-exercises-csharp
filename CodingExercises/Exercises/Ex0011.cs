using System;
using System.Collections.Generic;
using Exercises;

/*
Topic: Stacks / Strings

Difficulty: Easy

Problem: Valid Parentheses

Description:
Given a string s containing just the characters (, ), {, }, [ and ], determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets. (( must be closed by ), { by }, etc.)

Open brackets must be closed in the correct order. (The last one opened is the first one closed).

Examples:

Input: s = "()"
Output: true

Input: s = "()[]{}"
Output: true

Input: s = "(]"
Output: false (The ( is incorrectly closed by a ])

Input: s = "([)]"
Output: false (The [ is opened, then ( is opened, but the [ is closed by a ) before the ( is closed).

Input: s = "{[]}"
Output: true
*/

[Exercise("ex0011")]
public class Ex0011 : IExercise
{
    public void Run()
    {
        // string input = "()";     // true
        // string input = "()[]{}"; // true
        // string input = "(]";     // false
        // string input = "([)]";   // false
        string input = "{[]}";   // true

        bool result = IsValid(input);
        Console.WriteLine(result);
    }

    // The solution
    public bool IsValid(string s) 
    {
        // An odd number of characters can never be valid
        if (s.Length % 2 != 0)
        {
            return false;
        }

        // A stack to hold the opening brackets that are waiting to be closed
        var openingBrackets = new Stack<char>();

        // Map the closing brackets (keys) to their opening partners (values)
        var bracketMapping = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char c in s)
        {
            if (bracketMapping.ContainsKey(c)) // A closing bracket
            {
                // We're either out of opening brackets (empty stack) or we have a mismatched closing bracket
                if (openingBrackets.Count == 0 || openingBrackets.Pop() != bracketMapping[c])
                {
                    return false;
                }
            }
            else // An opening bracket
            {
                openingBrackets.Push(c);
            }
        }

        return (openingBrackets.Count == 0);
    }
}
