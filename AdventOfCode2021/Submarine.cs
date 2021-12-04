// See https://aka.ms/new-console-template for more information
public class Submarine
{
    public Location Location { get; set; } = new Location();

    public int Aim { get; set; } = 0;

    public int Odometer { get; set; } = 0;

    public int Speed { get; set; } = 0;

    public int Course => Odometer * Location.Depth;

    public void Move(Movement movement)
    {
        switch (movement.Direction)
        {
            case DirectionEnum.Forward:
                Odometer += movement.Distance;
                Location.Depth += movement.Distance * Aim;
                break;
            case DirectionEnum.Backward:
                break;
            case DirectionEnum.Up:
                Aim -= movement.Distance;
                break;
            case DirectionEnum.Down:
                Aim += movement.Distance;
                break;
            case DirectionEnum.Left:
                break;
            case DirectionEnum.Right:
                break;
            default:
                break;
        }
    }

    public override string ToString()
    {
        return $"Distance = {Odometer}\nDepth = {Location.Depth}\nAim = {Aim}\nCourse = {Course}";
    }
}
