namespace Day_5
{
    internal static class InputParser
    {
        public static (Stack<char>[] stacks, List<(int count, int from, int to)> instructions) Parse(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            //At first parse crates 
            int idx = Array.FindIndex(lines, l => l.Contains('1'));
            int stacksAmount = (lines[idx].Length + 1) / 4;
            Stack<char>[] stacks = new Stack<char>[stacksAmount];
            for (int i = 0; i < stacksAmount; i++) stacks[i] = new Stack<char>();

            for (int i = idx-1; i >= 0; i--)
            {
                var line = lines[i].ToCharArray();
                var crates = line.Where((crate, index) => index % 4 - 1 == 0).ToArray();
                foreach (var crate in crates.Select((value, index) => (value, index)))
                {
                    if (!(crate.value == ' ')) 
                        stacks[crate.index].Push(crate.value);
                }
            }

            //Next parse move instructions
            List<string> instructionsStrings = lines.Skip(idx + 2).ToList();
            List<(int count, int from, int to)> instructions = new List<(int, int, int)>();
            for (int i = 0; i<instructionsStrings.Count; i++)
            {
                string instruction = new string(instructionsStrings[i].Where(c => char.IsDigit(c) || char.IsWhiteSpace(c)).ToArray()).Trim();
                string[] values = instruction.Replace("  ", "-").Split('-');
                int[] casted = values.Select(v => int.Parse(v)).ToArray();
                instructions.Add((casted[0], casted[1]-1, casted[2]-1));
            }

            return (stacks, instructions);
        }
    }
}
