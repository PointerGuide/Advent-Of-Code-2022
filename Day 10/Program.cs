using Day_10;

List<(string instruction, int value)> commands = InputParser.Parse("input.txt");
int register = 1;
int cycle = 1;
int printed = 0;
const int crtWidht = 40, crtHeight = 6;
// Part one + two//
List<int> signalStrengths = new List<int>();
commands.ForEach(Execute);
int signalTotalStrength = signalStrengths.Where((e, i) => new List<int> { 20, 60, 100, 140, 180, 220 }.Contains((i+1) * 20)).Sum();
Console.WriteLine(signalTotalStrength);

void Execute((string instruction, int value) command)
{
    Cycle();
    if (command.instruction == "noop") return;
    register += command.value;
    Cycle();
}
void Cycle()
{
    if (cycle % 20 == 0)
        signalStrengths.Add(cycle*register);
    DrawCrtPixel();
    cycle++;
    Thread.Sleep(1000/60);
}
void DrawCrtPixel()
{
    int diff = Math.Abs(register - cycle % 40);
    char c = diff <= 1 ? '#' : '.';
    Console.Write(c);
    printed++;
    if (cycle % 40 == 0)
        Console.WriteLine();
}