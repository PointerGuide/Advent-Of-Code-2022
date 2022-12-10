namespace Day_9;

internal static class InputParser
{
    public static List<(Direction direction, int steps)> Parse(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        List<(Direction direction, int steps)> commands = new List<(Direction, int)>();
        foreach (string line in lines)
        {
            string[] split = line.Split(' ');
            Direction direction = (Direction)split[0][0];
            commands.Add((direction, int.Parse(split[1])));
        }
        return commands;
    }
}

internal enum Direction
{
    Right = 'R',
    Left = 'L',
    Down = 'D',
    Up = 'U'
}

