// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

public class Day2
{
    public Day2()
    {
        List<Movement> input = File.ReadAllLines("Input/02.txt").Select(i =>
        {
            string[] splitline = i.Split(' ');
            return NewMethod(splitline);
        }
        ).ToList();

        Submarine submarine = new Submarine();

        foreach (Movement movement in input)
        {
            submarine.Move(movement);
        }

        Console.WriteLine(submarine);
    }

    private static Movement NewMethod(string[] splitline)
    {
        return new Movement
        {
            Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), splitline[0], true),
            Distance = int.Parse(splitline[1])
        };
    }
}
