// See https://aka.ms/new-console-template for more information
Console.WriteLine("select a day!");

if(int.TryParse(Console.ReadLine(), out int input))
{
    switch (input)
    {
        case 1:
            _ = new Day1();
            break;
        case 2:
            _ = new Day2();
            break;
        case 3:
            _ = new Day3();
            break;
        case 4:
            _ = new Day4();
            break;
        default:
            break;
    }
}
