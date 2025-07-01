using System;
using System.Collections.Generic;
using Exercises;

/*
Topic: Stacks / Arrays
Difficulty: Medium
Problem: Evaluate Reverse Polish Notation

Description:
You are given an array of strings tokens that represents an arithmetic expression in Reverse Polish Notation.
Evaluate the expression and return an integer that represents its value.

Notes:
The valid operators are +, -, *, and /.
Each operand may be an integer or another expression.
The division between two integers should truncate toward zero.
You may assume the given RPN expression is always valid.

Examples:
- Input: tokens = ["2", "1", "+", "3", "*"]
- This is equivalent to (2 + 1) * 3
- Output: 9
- Walkthrough:
Push "2" -> Stack: [2]
Push "1" -> Stack: [2, 1]
See +: Pop 1, Pop 2. Compute 2 + 1 = 3. Push 3. -> Stack: [3]
Push "3" -> Stack: [3, 3]
See *: Pop 3, Pop 3. Compute 3 * 3 = 9. Push 9. -> Stack: [9]
End of tokens. Pop 9. Result is 9.

- Input: tokens = ["4", "13", "5", "/", "+"]
- This is equivalent to 4 + (13 / 5)
- Output: 6
- Walkthrough: 
13 / 5 truncates to 2. Then 4 + 2 = 6.
*/

/*
## Reminder
Stack: LIFO
Queue: FIFO
*/

[Exercise("ex0014")]
public class Ex0014 : IExercise
{
    public void Run()
    {
        string[] input = ["2", "1", "+", "3", "*"];
        // string[] input = ["4", "13", "5", "/", "+"];
        // int output = EvalRPNFancy(input);
        int output = EvalRPNTrad(input);
        Console.WriteLine(output);
    }

    /*
    NOTE: These two versions of the solution take different approaches for:
    1. Determining if the token is an operator or an operand (`HashSet<string>` vs `int.TryParse`)
    2. Mapping the operator to its real operation (switch/case vs Dictionary of func delegates)
    */

    public int EvalRPNFancy(string[] tokens)
    {
        // Using HashSet for constant time lookups
        var operators = new HashSet<string>
        {
            { "+" }, { "-" }, { "*" }, { "/" }
        };

        // Dictionary of func delegates for the operator/operation mapping
        var operatorFuncs = new Dictionary<string, Func<int, int, int>>();
        operatorFuncs.Add("+", (a, b) => a + b);
        operatorFuncs.Add("-", (a, b) => a - b);
        operatorFuncs.Add("*", (a, b) => a * b);
        operatorFuncs.Add("/", (a, b) => b != 0 ? a / b : throw new DivideByZeroException());

        var operands = new Stack<int>();

        foreach (string token in tokens)
        {
            if (operators.Contains(token))
            {
                // Could have ninja'd everything into one or two lines, but this is cleaner
                int op1 = operands.Pop();
                int op2 = operands.Pop();
                int calcResult = operatorFuncs[token](op2, op1);
                operands.Push(calcResult);
            }
            else
            {
                operands.Push(Int32.Parse(token));
            }
        }

        return operands.Pop();
    }

    // This version is the more normal approach
    public int EvalRPNTrad(string[] tokens)
    {
        var operands = new Stack<int>();

        foreach (string token in tokens)
        {
            // Try to parse the token as a number
            if (int.TryParse(token, out int number))
            {
                operands.Push(number);
            }
            else // It's an operator
            {
                // The second operand is popped first due to LIFO
                int op2 = operands.Pop();
                int op1 = operands.Pop();
                
                int result = 0;
                switch (token)
                {
                    case "+":
                        result = op1 + op2;
                        break;
                    case "-":
                        result = op1 - op2;
                        break;
                    case "*":
                        result = op1 * op2;
                        break;
                    case "/":
                        result = op1 / op2;
                        break;
                }
                operands.Push(result);
            }
        }

        // The final result is the only item left on the stack
        return operands.Pop();
    }
}
