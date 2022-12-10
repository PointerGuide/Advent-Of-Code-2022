using Day_10;

List<(string instruction, int value)> commands = InputParser.Parse("example.txt");
commands.ForEach(Execute);
int register = 1;
int cycle = 1;

void Execute((string instruction, int value) command)
{
    int executionCycles = 1;
    switch (command.instruction)
    {
        case "noop":
            break;
        case "addx":
            break;
    }
}