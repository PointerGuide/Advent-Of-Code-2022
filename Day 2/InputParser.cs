namespace Day_2;

public static class InputParser
{
    public static string[] Parse(string filename)
    {
        return File.ReadAllLines(filename);
    }
}