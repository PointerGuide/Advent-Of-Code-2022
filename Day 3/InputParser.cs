namespace Day_3
{
    internal static class InputParser
    {
        public static IEnumerable<(char[], char[])> Parse(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            IEnumerable<(char[], char[])> compartments = lines.Select(l => (l.Substring(0, l.Length / 2).ToCharArray(),
                l.Substring(l.Length / 2, l.Length / 2).ToCharArray()));

            return compartments;
        }
    }
}
