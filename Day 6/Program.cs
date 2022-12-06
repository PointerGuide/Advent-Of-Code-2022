char[] code = File.ReadAllText("input.txt").ToCharArray();

// Part one //
Console.WriteLine(FindStartOfPackedIndex(code, 4));

// Part two //
Console.WriteLine(FindStartOfPackedIndex(code, 14));

int FindStartOfPackedIndex(char[] code, int packetLength)
{
    for (int idx = 0; idx < code.Length - packetLength; idx++)
    {
        if (code[new Range(idx, idx + packetLength)].ToHashSet().Count != packetLength) continue;
        return idx + packetLength;
    }
    return -1;
}