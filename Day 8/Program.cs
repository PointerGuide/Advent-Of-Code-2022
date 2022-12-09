using Day_8;

//That answer is... meh :/

// Parse input //
int[][] grid = InputParser.Parse("input.txt"); //[row][column]

// Create and fill visibility map
int gridWidth = grid.Length, gridHeight = grid[0].Length;
bool[,] visibilityMap = new bool[gridWidth, gridHeight]; //[row, column]

// Part one //
List<Task> tasks = new List<Task>
{
    Task.Run(LookFromTop),
    Task.Run(LookFromBottom),
    Task.Run(LookFromRight),
    Task.Run(LookFromLeft),
};
await Task.WhenAll(tasks);

Console.WriteLine(visibilityMap.Cast<bool>().Count(isVisible => isVisible));

// Part two //
int maxScore = 0;
for (int row = 0; row < gridHeight; row++)
    for (int col = 0; col < gridHeight; col++)
    {
        maxScore = Math.Max(maxScore, EvaluateScenicScoreForIndex((row, col)));
    }
Console.WriteLine(maxScore);


void LookFromTop()
{
    
    for (int col = 0; col < gridWidth; col++)
    {
        int currentColMax = -1;
        for (int row = 0; row < gridHeight; row++)
        {
            if (grid[row][col] <= currentColMax) continue;
            currentColMax = grid[row][col];
            lock(visibilityMap) visibilityMap[row, col] = true;
        }
    }
}
void LookFromRight()
{
    
    for (int row = 0; row < gridHeight; row++)
    {
        int currentRowMax = -1;
        for (int col = gridWidth - 1; col >= 0 ; col--)
        {
            if (grid[row][col] <= currentRowMax) continue;
            currentRowMax = grid[row][col];
            lock (visibilityMap) visibilityMap[row, col] = true;
        }
    }
}
void LookFromBottom()
{
    for (int col = 0; col < gridWidth; col++)
    {
        int currentColMax = -1;
        for (int row = gridHeight - 1; row >= 0; row--)
        {
            if (grid[row][col] <= currentColMax) continue;
            currentColMax = grid[row][col];
            lock (visibilityMap) visibilityMap[row, col] = true;
        }
    }
}
void LookFromLeft()
{
    
    for (int row = 0; row < gridHeight; row++)
    {
        int currentRowMax = -1;
        for (int col = 0; col < gridWidth; col++)
        {
            if (grid[row][col] <= currentRowMax) continue;
            currentRowMax = grid[row][col];
            lock (visibilityMap) visibilityMap[row, col] = true;
        }
    }
}

int EvaluateScenicScoreForIndex((int row, int col) index)
{
    int score = 1;
    int count = 0;

    //Look up
    for (int row = index.row - 1; row >= 0; row--)
    {
        count++;
        if (grid[index.row][index.col] <= grid[row][index.col]) break;
    }
    score *= count; count = 0;

    //Look down
    for (int row = index.row + 1; row < gridHeight; row++)
    {
        count++;
        if (grid[index.row][index.col] <= grid[row][index.col]) break;
    }
    score *= count; count = 0;

    //Look left
    for (int col = index.col - 1; col >= 0; col--)
    {
        count++;
        if (grid[index.row][index.col] <= grid[index.row][col]) break;
    }
    score *= count; count = 0;

    //Look right
    for (int col = index.col + 1; col < gridWidth; col++)
    {
        count++;
        if (grid[index.row][index.col] <= grid[index.row][col]) break;
    }
    return score * count;
}

void PrintGrid()
{
    for (int i = 0; i < gridHeight; i++)
    {
        for (int j = 0; j < gridWidth; j++)
        {
            Console.Write(grid[i][j]);
        }
        Console.WriteLine();
    }
}

void PrintVisibilityMap()
{
    for (int i = 0; i < gridHeight; i++)
    {
        for (int j = 0; j < gridWidth; j++)
        {
            int visible = visibilityMap[i, j] ? 1 : 0;
            Console.Write(visible);
        }
        Console.WriteLine();
    }
}


