namespace Day_1;

internal static class InputParser
{
    public static Dictionary<long, List<long>> Parse(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        Dictionary<long, List<long>> elvesPacks = new Dictionary<long, List<long>>(lines.Length);
        int elfIndex = 0;

        //Parse input
        foreach (string line in lines)
        {
            if (line == "")
            {
                elfIndex++;
                continue;
            }


            if (!elvesPacks.ContainsKey(elfIndex))
                elvesPacks[elfIndex] = new List<long>();

            elvesPacks[elfIndex].Add(long.Parse(line));
        }

        return elvesPacks;
    }
}