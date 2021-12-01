// See https://aka.ms/new-console-template for more information
Console.WriteLine("select a day!");

if(int.TryParse(Console.ReadLine(), out int input))
{
    switch (input)
    {
        case 1:
            _ = new Day1();
            break;
        default:
            break;
    }
}
