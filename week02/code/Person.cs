public class Person
{
    public readonly string Name;
    public int Turns { get; set; }
    public int OriginalTurns { get; }

    internal Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
        OriginalTurns = turns;
    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}