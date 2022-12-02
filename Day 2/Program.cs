//////////////////////////RULES///////////////////////////

using Day_2;

Dictionary<string, int> duelResults = new Dictionary<string, int>
{
    //A - Rock      vs      Y - Paper
    //B - Paper     vs      Z - Scissors
    //C - Scissors  vs      X - Rock
    { "A Y", 6 },
    { "B Z", 6 },
    { "C X", 6 },
    { "A X", 3 },
    { "B Y", 3 },
    { "C Z", 3 }
};

Dictionary<char, int> points = new Dictionary<char, int>
{
    //1 point for Rock
    //2 points for Paper
    //3 points for Scissors
    { 'X', 1 },
    { 'Y', 2 },
    { 'Z', 3 }
};

////////////////////////////////////////////////////////////

// Part One //
string[] input = InputParser.Parse("input.txt");
IEnumerable<int> pointsPerDuel = CalculatePoints(input);

int totalScore = pointsPerDuel.Sum();

// Part Two //

Dictionary<string, string> decryption = new Dictionary<string, string>
{
    //A - Rock            X - Lose
    //B - Paper           Y - draw
    //C - Scissors        Z - Win
    //Losses
    { "A X", "A Z" },
    { "B X", "B X" },
    { "C X", "C Y" },
    //Draws
    { "A Y", "A X" },
    { "B Y", "B Y" },
    { "C Y", "C Z" },
    //Wins
    { "A Z", "A Y" },
    { "B Z", "B Z" },
    { "C Z", "C X" }
};
totalScore = CalculatePoints(input.Select(i => decryption[i]).ToArray()).Sum();

IEnumerable<int> CalculatePoints(IReadOnlyCollection<string> input)
{
    int[] pointsPerDuel = new int[input.Count];
    int i = 0;
    foreach (string duel in input)
    {
        string[] choices = duel.Split(' ');
        int result = points[char.Parse(choices[1])];
        result += duelResults.ContainsKey(duel) ? duelResults[duel] : 0;
        pointsPerDuel[i++] = result;
    }

    return pointsPerDuel;
}
