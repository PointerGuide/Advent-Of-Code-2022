using Day_4;

// Part one //
IEnumerable<(HashSet<int>, HashSet<int>)> sections = InputParser.Parse("input.txt");
IEnumerable<bool> fullyContainPairs = sections.Select(s => s.Item1.IsSupersetOf(s.Item2) || s.Item1.IsSubsetOf(s.Item2));
Console.WriteLine(fullyContainPairs.Count(s => s));

// Part two //
IEnumerable<bool> overlapPairs = sections.Select(s => s.Item1.Overlaps(s.Item2));
Console.WriteLine(overlapPairs.Count(s => s));