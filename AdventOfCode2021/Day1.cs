// See https://aka.ms/new-console-template for more information
internal class Day1
{
    public Day1()
    {
        List<int> input = File.ReadAllLines("Input/01.txt").Select(i => int.Parse(i)).ToList();
        int NumberOfTimesIncreased = 0;

        for (int i = 2; i < input.Count - 1; i++)
        {
            int j = i - 1;
            int previousDepth = input[j - 1] + input[j] + input[j + 1];
            int currentDepth = input[i - 1] + input[i] + input[i + 1];

            if (currentDepth > previousDepth)
                NumberOfTimesIncreased++;
            previousDepth = currentDepth;
        }

        Console.WriteLine($"Number of time greater than previous depth: {NumberOfTimesIncreased}");
    }
}