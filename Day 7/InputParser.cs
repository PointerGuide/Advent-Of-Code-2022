namespace Day_7
{
    internal static class InputParser
    {
        public static List<(string name, string[] args)> Parse(string filename)
        {
            string[] inputs = System.IO.File.ReadAllText(filename).Split('$').Skip(1).ToArray();
            List<(string, string[])> commands = new List<(string, string[])>();
            foreach (string input in inputs)
            {
                string[] parts = input.Trim().Split('\n');
                string name = parts[0].Split(' ')[0].Trim();
                List<string> args = new List<string>();
                if (name.StartsWith("cd"))
                {
                    args.Add(parts[0].Split(' ')[1]);
                }
                else if (name.StartsWith("ls"))
                {
                    args = parts.Skip(1).Select(p => p.Trim()).ToList();
                }

                commands.Add((name, args.ToArray()));
            }
            return commands;
        }
    }
}
