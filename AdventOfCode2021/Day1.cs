// See https://aka.ms/new-console-template for more information
internal class Day1
{
    private readonly List<int> input;
    public int NumberOfTimesIncreased { get; set; }
    public int NumberOfTimesDecreased { get; set; }
    public int NumberOfTimesEqual { get; set; }

    public Day1()
    {
        input = File.ReadAllLines("Input/01.txt").Select(i => int.Parse(i)).ToList(); ;
    }

    internal void Run()
    {
        int? previousDepth = null;
        for (int i = 1; i < input.Count - 1; i++)
        {
            int currentDepth = input[i - 1] + input[i] + input[i + 1];

            if (previousDepth is null)
            {
                Console.WriteLine($"{currentDepth} (N/A - no previous measurement)");
                previousDepth = currentDepth;
                continue;
            }


            if (currentDepth > previousDepth)
            {
                Console.WriteLine($"{currentDepth} (increased)");
                NumberOfTimesIncreased++;
            }
            else if (currentDepth < previousDepth)
            {
                Console.WriteLine($"{currentDepth} (decreased)");
                NumberOfTimesDecreased++;
            }
            else
            {
                Console.WriteLine($"{currentDepth} (no change)");
                NumberOfTimesEqual++;
            }
            previousDepth = currentDepth;
        }

        Console.WriteLine($"Number of time greater than previous depth: {NumberOfTimesIncreased}");

    }
}