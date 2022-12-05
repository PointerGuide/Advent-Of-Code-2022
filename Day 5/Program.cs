using Day_5;

//Parser works only for less than 10 stacks!
string filename = "example.txt";
(Stack<char>[] stacks, List<(int count, int from, int to)> instructions) = InputParser.Parse(filename);

// Part one //
foreach (var instruction in instructions)
{
    stacks[instruction.from].MoveTo(stacks[instruction.to], instruction.count);
}
string secretCode = "";
Array.ForEach(stacks, s => secretCode += s.Peek());
Console.WriteLine(secretCode);

// Part two //
(stacks, _) = InputParser.Parse(filename);



