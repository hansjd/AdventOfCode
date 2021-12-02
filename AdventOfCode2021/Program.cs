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
        default:
            break;
    }
}
