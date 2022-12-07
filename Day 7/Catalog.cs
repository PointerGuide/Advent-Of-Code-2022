using System.Dynamic;
using System.Numerics;

namespace Day_7;

public class Catalog:File
{
    internal Catalog(string name, Catalog? catalog, int levelOfNesting) : base(name, 0, catalog, levelOfNesting)
    {
        _files = new List<File>();
    }

    public override BigInteger GetSize() => new BigInteger(_files.Select(f => f.Size).Sum());

    public void AddFile(File file) => _files.Add(file);

    public List<File> GetFiles(bool recursive = true)
    {
        if (!recursive)
            return _files;

        List<File> files = new List<File>();
        foreach (File file in _files)
        {
            switch (file)
            {
                case Catalog catalog:
                    files.Add(catalog);
                    files.AddRange(catalog.GetFiles(recursive));
                    break;
                case File:
                    files.Add(file);
                    break;
            }
        }
        return files;
    }
    public File Find(string filename) => _files.Find(f => f.Name == filename) ?? throw new InvalidOperationException();

    public new void PrintInfo()
    {
        base.PrintInfo();
        foreach (File file in _files)
        {
            switch (file)
            {
                case Catalog catalog:
                    catalog.PrintInfo();
                    break;
                case File:
                    file.PrintInfo();
                    break;
            }
        }
    }
    private readonly List<File> _files;
}