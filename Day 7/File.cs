using System.Numerics;

namespace Day_7;

public class File
{
    internal File(string name, long size, Catalog? catalog, int levelOfNesting)
    {
        Name = name;
        _size = size;
        Catalog = catalog;
        _levelOfNesting = levelOfNesting;
    }

    internal int _levelOfNesting;

    private long _size;
    public string Name { get; }
    public long Size
    {
        get => (long)GetSize();
        set => _size = value;
    }

    public virtual BigInteger GetSize()
    {
        return _size;
    }

    public Catalog? Catalog { get; }

    public void PrintInfo()
    {
        string nesting = new string(Enumerable.Repeat(' ', _levelOfNesting*2).ToArray());
        Console.WriteLine($"{nesting}- {Name} ({GetType().Name}, size={GetSize()})");
    }
}