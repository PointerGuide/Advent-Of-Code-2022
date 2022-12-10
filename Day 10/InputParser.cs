namespace Day_10;

internal static class InputParser
{
    public static List<(string instruction, int value)> Parse(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        List<(string instruction, int value)> commands = new List<(string, int)>();
        foreach (string line in lines)
        {
            string[] split = line.Split(' ');
            int val = split.Length > 1 ? int.Parse(split[1]) : 0;
            commands.Add((split[0], val));
        }
        return commands;
    }
}
