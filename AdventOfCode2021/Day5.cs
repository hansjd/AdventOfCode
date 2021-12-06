// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

public class Day5
{
    public Day5()
    {
        IEnumerable<string> input = File.ReadAllLines("Input/05 Sample.txt");
        input = File.ReadAllLines("Input/05.txt");


        Part1(input);
        //Part2(input);
    }

    private void Part1(IEnumerable<string> input)
    {

        Console.WriteLine();
        foreach (string item in input)
        {
            CoordinateSets.Add(new CoordinateSet(item));
        }

        int max1 = CoordinateSets.Max(x => x.From.X);
        int max2 = CoordinateSets.Max(x => x.To.X);
        int x = max1 > max2 ? max1 : max2;
        max1 = CoordinateSets.Max(x => x.From.Y);
        max2 = CoordinateSets.Max(x => x.To.Y);
        int y = max1 > max2 ? max1 : max2;

        OceanFloor oceanFloor = new OceanFloor(x+1, y+1);
        oceanFloor.PlotHydrothermalVents(CoordinateSets);
        //Console.WriteLine(oceanFloor.ToString());
        //Console.WriteLine();
        Console.WriteLine(oceanFloor.NumberOfHotspots);
    }
    public List<CoordinateSet> CoordinateSets { get; set; } = new List<CoordinateSet> { };

}

public class OceanFloor
{
    public int[,] Squares { get; set; }
    public int NumberOfHotspots => CountHotspots();

    public OceanFloor(int x, int y)
    {
        Squares = new int[x, y];
    }

    public void PlotHydrothermalVents(List<CoordinateSet> sets)
    {
        foreach (CoordinateSet set in sets)
        {
            int difference = 0;
            DirectionEnum direction;
            if (set.From.X == set.To.X && set.From.Y > set.To.Y)
            {
                difference = set.From.Y - set.To.Y;
                direction = DirectionEnum.Up;
            }
            else if (set.From.X < set.To.X && set.From.Y > set.To.Y)
            {
                difference = set.From.X - set.To.X;
                direction = DirectionEnum.UpRight;
            }
            else if (set.From.X < set.To.X && set.From.Y == set.To.Y)
            {
                difference = set.From.X - set.To.X;
                direction = DirectionEnum.Right;
            }
            else if (set.From.X < set.To.X && set.From.Y < set.To.Y)
            {
                difference = set.From.X - set.To.X;
                direction = DirectionEnum.DownRight;
            }
            else if (set.From.X == set.To.X && set.From.Y < set.To.Y) 
            {
                difference = set.From.Y - set.To.Y;
                direction = DirectionEnum.Down;
            }
            else if (set.From.X > set.To.X && set.From.Y < set.To.Y)
            {
                difference = set.From.X - set.To.X;
                direction = DirectionEnum.DownLeft;
            }
            else if (set.From.X > set.To.X && set.From.Y == set.To.Y)
            {
                difference = set.From.X - set.To.X;
                direction = DirectionEnum.Left;
            }
            else if (set.From.X > set.To.X && set.From.Y > set.To.Y)
            {
                difference = set.From.X - set.To.X;
                direction = DirectionEnum.UpLeft;
            }
            else
            {
                continue;
            }

            difference = Math.Abs(difference);

            switch (direction)
            {
                case DirectionEnum.Forward:
                    break;
                case DirectionEnum.Backward:
                    break;
                case DirectionEnum.Up:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y - i, set.From.X]++;
                    }
                    break;
                case DirectionEnum.UpRight:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y - i, set.From.X + i]++;
                    }
                    break;
                case DirectionEnum.Right:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y, set.From.X + i]++;
                    }
                    break;
                case DirectionEnum.DownRight:
                    for (int i = 0; i <= difference; i++)
                    { 
                        Squares[set.From.Y + i, set.From.X + i]++;
                    }
                    break;
                case DirectionEnum.Down:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y + i, set.From.X]++;
                    }
                    break;
                case DirectionEnum.DownLeft:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y + i, set.From.X - i]++;
                    }
                    break;
                case DirectionEnum.Left:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y, set.From.X - i]++;
                    }
                    break;
                case DirectionEnum.UpLeft:
                    for (int i = 0; i <= difference; i++)
                    {
                        Squares[set.From.Y - i, set.From.X - i]++;
                    }
                    break;
                default:
                    break;
            }
            //break;

        }
    }

    public int CountHotspots()
    {
        int count = 0;
        foreach (int square in Squares)
        {
            if (square > 1)
            {
                count++;
            }
        }
        return count;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < Squares.GetLength(0); i++)
        {
            for (int j = 0; j < Squares.GetLength(1); j++)
            {
                s += Squares[i, j] > 0 ? Squares[i, j].ToString() : ".";
            }
            s += "\n";
        }
        return s;
    }
}


public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class CoordinateSet
{
    public Coordinate From { get; set; }
    public Coordinate To { get; set; }

    public CoordinateSet(string input)
    {
        var vs = input.Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray();
        From = new Coordinate { X = vs[0], Y = vs[1] };
        To = new Coordinate { X = vs[2], Y = vs[3] };
    }
}