namespace Day_4
{
    internal static class InputParser
    {
        public static IEnumerable<(HashSet<int>, HashSet<int>)> Parse(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            IEnumerable<(HashSet<int>, HashSet<int>)> sections =
                lines.Select(l => l.Split(','))
                     .Select(s => (s[0].Split('-'), s[1].Split('-')))
                     .Select(s => (s.Item1.Select(i => int.Parse(i)).ToArray(),
                                     s.Item2.Select(i => int.Parse(i)).ToArray()))
                     .Select(s => (Enumerable.Range(s.Item1[0], s.Item1[1] - s.Item1[0] + 1).ToHashSet(),
                                     Enumerable.Range(s.Item2[0], s.Item2[1] - s.Item2[0] + 1).ToHashSet()));
            return sections;
        }
    }
}
