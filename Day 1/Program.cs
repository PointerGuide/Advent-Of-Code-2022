using Day_1;

Dictionary<long, List<long>> elvesPacks = InputParser.Parse("example.txt");

// Part One //
long[] sums = elvesPacks.Select(c => c.Value.Sum()).ToArray();
long answerPart1 = sums.Max();

// Part Two //
sums = sums.OrderByDescending(c => c).ToArray();
long answerPart2 = sums[0] + sums[1] + sums[2];