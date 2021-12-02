// See https://aka.ms/new-console-template for more information
internal class Day2
{
    public Day2()
    {
        List<Movement> input = File.ReadAllLines("Input/02.txt").Select(i => { 
            string[] splitline = i.Split(' ');
            return new Movement
                {
                    Direction = splitline[0],
                    Distance = int.Parse(splitline[1])
                }; 
            }
        ).ToList();

        int distance = 0;
        int depth = 0;
        int aim = 0;
        foreach (Movement movement in input)
        {
            switch (movement.Direction)
            {
                case "forward":

                    distance += movement.Distance;
                    depth = depth + movement.Distance*aim;
                    break;
                case "backward":
                    distance -= movement.Distance;

                    break;
                case "up":
                    aim -= movement.Distance;
                    break;
                case "down":
                    aim += movement.Distance;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"horizontal distance = {distance}\ndepth = {depth}\naim = {aim}\nmultiply = {depth * distance}");
    }


    private class Movement {
        public string Direction { get; set; }

        public int Distance { get; set; }
    }
}