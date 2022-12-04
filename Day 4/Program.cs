using Day_4;

// Part one //
IEnumerable<(HashSet<int>, HashSet<int>)> sections = InputParser.Parse("input.txt");
var fullyContains = sections.Select(s => s.Item1.IsSupersetOf(s.Item2) || s.Item1.IsSubsetOf(s.Item2));
Console.WriteLine(fullyContains.Count(s => s));

// Part two //
var overlapPair = sections.Select(s => s.Item1.Overlaps(s.Item2));
Console.WriteLine(overlapPair.Count(s => s));