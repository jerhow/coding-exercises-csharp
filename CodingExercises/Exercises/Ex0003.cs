using Exercises;

/*
Topic: Strings / Hash Tables
Difficulty: Easy
Problem: Valid Anagram

Description:
Write a method that takes two strings, s and t, 
and returns true if t is an anagram of s, and false otherwise. 
An anagram is a word or phrase formed by rearranging the letters 
of a different word or phrase, typically using all the original letters exactly once. 
For the purpose of this problem, assume the strings contain only lowercase English letters.

Examples:

Input: s = "anagram", t = "nagaram"
Output: true

Input: s = "rat", t = "car"
Output: false

Input: s = "listen", t = "silent"
Output: true
*/

[Exercise("ex0003")]
public class Ex0003 : IExercise
{
    public void Run()
    {
        string input1 = "anagram";
        string input2 = "nagaram";
        bool output = IsAnagram(input1, input2);
        Console.WriteLine(output);
    }

    /*
    The Hash Table (Frequency Map) Approach
    The idea here is to count the frequency of each character.

    - First, a quick check: if the strings have different lengths, they can't be anagrams.
    - Create a "frequency map" (a Dictionary) from the first string, s, mapping each character to how many times it appears.
    - Iterate through the second string, t. For each character in t, decrement its count in our map.
    - If you ever encounter a character in t that isn't in the map, or if its count is already zero, you know it's not an anagram.
    - If you get through all of t successfully, the strings are anagrams.

    This is a linear O(n) solution.
    */
    public bool IsAnagram(string s, string t)
    {
        // Mismatched lengths can't be an anagram.
        if (s.Length != t.Length)
        {
            return false;
        }

        // Create a frequency map for the first string.
        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!counts.ContainsKey(c))
            {
                counts[c] = 0;
            }
            counts[c]++;
        }

        // Decrement counts using the second string.
        foreach (char c in t)
        {
            // If a char from t is not in s, or if we've seen it too many times.
            if (!counts.ContainsKey(c) || counts[c] == 0)
            {
                return false;
            }
            counts[c]--;
        }

        return true;
    }

    /*
    This solution (using sorting) is more concise, but less efficient.
    It is O(n log n), because of the sorting.
    */
    public bool IsAnagram_(string s, string t) 
    {
        char[] sArr = s.ToCharArray();
        Array.Sort(sArr);
        
        char[] tArr = t.ToCharArray();
        Array.Sort(tArr);

        return (String.Join("", sArr) == String.Join("", tArr));
    }
}
