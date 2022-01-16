namespace TrainRacer.Core.Models.Trains;

public class ShinyDiesel : BaseTrain
{
    public override double TopSpeed => 42;

    public override double TractiveForce => 2900;

    public override double Mass => 21000;

    public override string Name => "Zephyr";
}
