## Coding Exercises in C#

Coding exercises, using C# 8.0 as the primary language. This is mostly for interview prep, and to try to stay sharp on fundamental concepts.

Broadly speaking, my objective is to cover the following categories:

- Arrays & Strings
- Hash Tables (in C#, Dictionary<TKey, TValue>)
- Linked Lists
- Stacks & Queues
- Trees
- Graphs
- Recursion
- Dynamic Programming Techniques
- Etc.

There isn't a straight line through these topics for me. I have been blending them as I go, and I often circle back to additional exercises in earlier categories before continuing forward. It will seem a bit unstructured to an outside observer.

I am currently using Google Gemini (2.5 Pro) to source these exercises and provide feedback on my solutions.

---

The project itself implements a small runner mechanism, which allows me to simply add exercises to a common namespace, assign each a unique identifier (e.g., `ex0001`), and invoke any of them from the .NET SDK command line. 
The runner will pick up the matching class, and automatically invoke its `Run()` method.

For example: `dotnet run -- ex0001`

This means that every exercise in the project is included in every build (`dotnet build` | `dotnet run`), so each exercise needs to compile cleanly before moving forward.

A template for a new **exercise** would look something like this:

```
// File: CodingExercises/Ex0001.cs

using Exercises;

/*
I will typically document the exercise requirements here.
*/

[Exercise("Ex0001")]
public class Ex0001 : IExercise
{
    public void Run()
    {
        // Here you can set up any inputs or outputs as needed for the exercise,
        // call your solution method, and write any output to stdout as needed.
        <T> input1 = Something;
        <T> input2 = SomethingElse;
        <T> result = MySolution(input1, input2);
        Console.WriteLine(result);
    }

    // Implement the solution here as one or more class methods
    private <T> MySolution(<T> foo, <T> bar)
    {
        return <T>;
    }
}

```

Nothing fancy.
