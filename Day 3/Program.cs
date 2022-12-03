using Day_3;

List<(char[], char[])> compartments = InputParser.Parse("input.txt").ToList();

// Part one //
IEnumerable<char> intesections = compartments.Select(c => c.Item1.Intersect(c.Item2).Single());
List<int> priorities = intesections.Select(i => char.IsLower(i) ? i - 96 : i - 38).ToList();
Console.WriteLine(priorities.Sum());

// Part two //
IEnumerable<HashSet<char>[]> groups = compartments.Select(c => c.Item1.Concat(c.Item2).ToHashSet()).Chunk(3);
intesections = groups.Select(g => g[0].Intersect(g[1]).Intersect(g[2]).Single());
priorities = intesections.Select(i => char.IsLower(i) ? i - 96 : i - 38).ToList();
Console.WriteLine(priorities.Sum());