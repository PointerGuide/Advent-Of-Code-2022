namespace Day_8
{
    internal static class InputParser
    {
        public static int[][] Parse(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            return lines.Select(l => Array.ConvertAll(l.ToCharArray(), c => c - '0')).ToArray();
        }
    }
}
