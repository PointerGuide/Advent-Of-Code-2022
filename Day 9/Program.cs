using Day_9;

const int gridSize = 1000;
const bool printMovement = false;
bool[,] grid = new bool[gridSize, gridSize]; //Initial grid

(int x, int y) headPos = (gridSize / 2, gridSize / 2);
(int x, int y) tailPos = (gridSize / 2, gridSize / 2);
List<(Direction direction, int steps)> commands = InputParser.Parse("example.txt");

// Part one //
commands.ForEach(cmd => Move(cmd.direction, cmd.steps));
if (printMovement)
    Console.SetCursorPosition(0, gridSize + 1);
Console.WriteLine(grid.Cast<bool>().Count(x => x));

// Part two //
grid = new bool[gridSize, gridSize];
headPos = (gridSize / 2, gridSize / 2);
(int x, int y)[] tail = new (int, int)[9];
tail = Array.ConvertAll(tail, k => (gridSize / 2, gridSize / 2));
commands.ForEach(cmd => MoveRope(cmd.direction, cmd.steps));
Console.WriteLine(grid.Cast<bool>().Count(x => x) + 1);

void MoveRope(Direction direction, int steps)
{
    while (steps-- > 0)
        StepRope(direction);
}
void StepRope(Direction direction)
{
    grid[tail[8].x, tail[8].y] = true;
    MoveHead(direction);
    int diffX = headPos.x - tail[0].x; int diffY = headPos.y - tail[0].y;
    if (Math.Abs(diffX) <= 1 && Math.Abs(diffY) <= 1) return;
    tail[0].x += Math.Sign(diffX);
    tail[0].y += Math.Sign(diffY);
    for (int i = 1; i <= 8; i++)
    {
        diffX = tail[i-1].x - tail[i].x; diffY = tail[i - 1].y - tail[i].y;
        if (Math.Abs(diffX) <= 1 && Math.Abs(diffY) <= 1) continue;
        tail[i].x += Math.Sign(diffX);
        tail[i].y += Math.Sign(diffY);
    }
    /*
    PrintGrid();
    for (int i = 8; i >= 0; i--)
    {
        Console.SetCursorPosition(tail[i].x, tail[i].y);
        Console.Write(i);
    }
    Console.SetCursorPosition(headPos.x, headPos.y);
    Console.Write('H');
    Thread.Sleep(1000);
    */
}

void Move(Direction direction, int steps)
{
    while(steps-- > 0)
        Step(direction);
}
void Step(Direction direction)
{
    MakeTrace();
    MoveHead(direction);
    MoveTail();

    if (printMovement)
    {
        PrintGrid();
        PrintHeadAndTail();
        Thread.Sleep(1000);
    }
}
void MakeTrace() => grid[tailPos.x, tailPos.y] = true;
void MoveHead(Direction direction)
{
    switch (direction)
    {
        case Direction.Right:
            headPos.x += 1;
            break;
        case Direction.Left:
            headPos.x -= 1;
            break;
        case Direction.Up:
            headPos.y += 1;
            break;
        case Direction.Down:
            headPos.y -= 1;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
    }
}
void MoveTail()
{
    int diffX = headPos.x - tailPos.x; int diffY = headPos.y - tailPos.y;
    if (Math.Abs(diffX) <= 1 && Math.Abs(diffY) <= 1) return;
    tailPos.x += Math.Sign(diffX);
    tailPos.y += Math.Sign(diffY);
}
void PrintHeadAndTail()
{
    Console.SetCursorPosition(tailPos.x, tailPos.y);
    Console.Write('T');
    Console.SetCursorPosition(headPos.x, headPos.y);
    Console.Write('H');
}
void PrintGrid()
{
    Console.Clear();
    for (int i = 0; i < gridSize; i++)
    {
        for (int j = 0; j < gridSize; j++)
        {
            char c = grid[j, i] ? '#' : '.';
            Console.Write(c);
        }
        Console.WriteLine();
    }
}
