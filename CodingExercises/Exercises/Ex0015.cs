using Exercises;

/*
Difficulty: Medium
Problem: Reverse Integer

Description:
Given a signed 32-bit integer x, return x with its digits reversed. 
If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], 
then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:
Input: x = 123
Output: 321

Example 2:
Input: x = -123
Output: -321

Example 3:
Input: x = 120
Output: 21 

Constraints:
-231 <= x <= 231 - 1

*/

[Exercise("ex0015")]
public class Ex0015 : IExercise
{
    public void Run()
    {
        int input = 123;         // 321
        // int input = -123;        // -321
        // int input = 120;         // 21
        // int input = 1534236469;  // 0
        // int input = -2147483648; // 0
        // int input = -1563847412; // 0
        
        int output = Reverse(input);
        Console.WriteLine(output);
    }

    public int Reverse(int x) 
    {
        // Negating the minimum value of an unsigned int (-2,147,483,648) gives you a long (2,147,483,647),
        // so you have to account for that possibility.
        if (x == int.MinValue) return 0;

        bool isNegative = false;
        if (x < 0)
        {
            isNegative = true;
            x = Math.Abs(x);
        }

        char[] fwd = x.ToString().ToCharArray();
        char[] rev = new char[fwd.Length];
        int fwdLength = fwd.Length;
        
        // Populate `rev` with reverse indexed loop
        for (x = fwdLength - 1; x >= 0; x--)
        {
            rev[(fwdLength - 1) - x] = fwd[x];
        }

        string revAsStr = isNegative ? "-" + String.Join("", rev) : String.Join("", rev);
        
        // It's possible that the reversed numeric value will overflow an unsigned int
        // (either on the high or low side), so you need to check for that.
        long parseResult;
        long.TryParse(revAsStr, out parseResult);
        
        if (parseResult < int.MinValue || parseResult > int.MaxValue)
        {
            return 0;
        }
        else
        {
            return Int32.Parse(revAsStr);
        }
    }
}
