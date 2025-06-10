using Exercises;

/*
Topic: Arrays / Hash Tables / Strings
Difficulty: Medium
Problem: Group Anagrams

Description:
Write a method that takes an array of strings strs and groups the anagrams together. 
You can return the answer in any order.

Examples:

Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Input: strs = [""]
Output: [[""]]

Input: strs = ["a"]
Output: [["a"]]
*/

[Exercise("ex0005")]
public class Ex0005 : IExercise
{
    public void Run()
    {
        string[] input = ["eat","tea","tan","ate","nat","bat"];
        IList<IList<string>> output = GroupAnagrams(input);
        Console.WriteLine(string.Join("\n", output.Select(row => string.Join(", ", row))));
    }

    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        // We declare that our concrete list will hold items of the INTERFACE type.
        var anagramGroups = new List<IList<string>>();

        Dictionary<string, List<string>> foo = new Dictionary<string, List<string>>();

        for (int x = 0; x < strs.Length; x++)
        {
            // sort the string
            var sorted = strs[x].ToArray();
            Array.Sort(sorted);
            string sortedStr = string.Join("", sorted);

            if (foo.ContainsKey(sortedStr))
            {
                foo[sortedStr].Add(strs[x]);
            }
            else
            {
                foo.Add(sortedStr, new List<string> { strs[x] });
            }
        }

        foreach(KeyValuePair<string, List<string>> pair in foo)
        {
            anagramGroups.Add(pair.Value);
        }

        return anagramGroups;
    }
}
