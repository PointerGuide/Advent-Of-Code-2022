using Day_3;

List<(char[], char[])> compartments = InputParser.Parse("input.txt").ToList();

// Part one //
List<int> priorities = new List<int>(compartments.Count);
foreach ((char[], char[]) compartment in compartments)
{
    char intersection = compartment.Item1.Intersect(compartment.Item2).First();
    
    int priority = char.IsLower(intersection) ? intersection - 96 : intersection - 38; //convert ascii value to priority
    priorities.Add(priority); 
}

Console.WriteLine(priorities.Sum());

// Part two //
IEnumerable<HashSet<char>[]> groups = compartments.Select(c => c.Item1.Concat(c.Item2).ToHashSet()).Chunk(3);
priorities.Clear();

foreach (HashSet<char>[] group in groups)
{
    char intersection = group[0].Intersect(group[1]).Intersect(group[2]).First();
    int priority = char.IsLower(intersection) ? intersection - 96 : intersection - 38; //convert ascii value to priority
    priorities.Add(priority);
}

Console.WriteLine(priorities.Sum());