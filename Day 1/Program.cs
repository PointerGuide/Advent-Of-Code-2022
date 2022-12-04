using Day_1;

Dictionary<long, List<long>> elvesPacks = InputParser.Parse("example.txt");

// Part One //
long[] sums = elvesPacks.Select(c => c.Value.Sum()).ToArray();
long answer = sums.Max();
Console.WriteLine(answer);

// Part Two //
sums = sums.OrderByDescending(c => c).ToArray();
answer = sums[0] + sums[1] + sums[2];
Console.WriteLine(answer);