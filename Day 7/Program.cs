using Day_7;

// Parsing part //
List<(string name, string[] args)> commands = InputParser.Parse("input.txt");
FileExplorer fileExplorer = new FileExplorer();
commands.ForEach(c => fileExplorer.HandleCommand(c));
//fileExplorer.PrintFileStructure();

// Part one //
long bigDirectoriesTotalSize = fileExplorer.GetFiles()
    .Where(f => f is Catalog && f.Size<100000).Sum(f => f.Size);
Console.WriteLine(bigDirectoriesTotalSize);

// Part two //
const long totalMemory = 70000000;
const long neededMemory = 30000000;
long inUseMemory = (long)fileExplorer.TotalUsed();
long totalFree = totalMemory - inUseMemory;
long needToDeleteMemory = neededMemory - totalFree;
Day_7.File directoryToDelete = fileExplorer.GetFiles()
    .Where(f => f is Catalog)
    .OrderBy(dir => dir.Size)
    .First(dir => dir.Size >= needToDeleteMemory);
Console.WriteLine(directoryToDelete.GetSize());