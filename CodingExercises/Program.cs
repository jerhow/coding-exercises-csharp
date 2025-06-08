using System.Reflection;
using System.Collections.Concurrent;
using Exercises;

var key = args.FirstOrDefault();
if (key is null)
{
    Console.WriteLine("Usage: dotnet run -- <exercise-key>");
    return;
}

var exercise = ExerciseFactory.Create(key);
exercise.Run();

public static class ExerciseFactory
{
    private static readonly ConcurrentDictionary<string, Type> _map = BuildMap();

    public static IExercise Create(string key)
    {
        if (!_map.TryGetValue(key, out var type))
            throw new ArgumentException($"No exercise registered for key “{key}”.", nameof(key));			

        // If you use DI, resolve from the container here instead.
        return (IExercise)Activator.CreateInstance(type)!;
    }

    private static ConcurrentDictionary<string, Type> BuildMap()
    {
        var dict = new ConcurrentDictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!typeof(IExercise).IsAssignableFrom(type) || type.IsAbstract) continue;

            var attr = type.GetCustomAttribute<ExerciseAttribute>();
            if (attr is null) continue;

            if (!dict.TryAdd(attr.Key, type))
                throw new InvalidOperationException($"Duplicate exercise key “{attr.Key}” on {type.FullName}.");
        }

        return dict;
    }
}
