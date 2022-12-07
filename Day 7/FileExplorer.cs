using System.Numerics;

namespace Day_7;

public class FileExplorer
{
    private readonly Catalog _root;
    private Catalog _workingDirectory;
    public FileExplorer()
    {
        _root = new Catalog("/", null, 0);
        _workingDirectory = _root;
    }

    public void ChangeDirectory(string catalog)
    {
        _workingDirectory = catalog switch
        {
            "/" => _root,
            ".." => _workingDirectory.Catalog ?? _root,
            _ => _workingDirectory = (Catalog)_workingDirectory.Find(catalog)
        };
    }

    public void PrintFileStructure() => _root.PrintInfo();

    public List<File> GetFiles() => _root.GetFiles();

    public BigInteger TotalUsed() => _root.GetSize();

    public void HandleCommand((string name, string[] args) command)
    {
        switch (command.name)
        {
            case "cd":
                ChangeDirectory(command.args[0]);
                break;
            case "ls":
                foreach (string arg in command.args)
                {
                    string[] argParts = arg.Split(' ');
                    string filename = argParts[1];
                    File f = arg.StartsWith("dir")
                        ? new Catalog(filename, _workingDirectory, _workingDirectory._levelOfNesting+1)
                        : new File(filename, int.Parse(argParts[0]), _workingDirectory, _workingDirectory._levelOfNesting + 1);
                    _workingDirectory.AddFile(f);
                }
                break;
        }
    }
}