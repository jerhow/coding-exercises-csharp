[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ExerciseAttribute : Attribute
{
    public string Key { get; }
    public ExerciseAttribute(string key) => Key = key;
}
