namespace TrainRacer.Core.Models.Trains;

public class StandardSteam : BaseTrain
{
    public override double TopSpeed => 35;

    public override double TractiveForce => 5500;

    public override double Mass => 35000;

    public override string Name => "B12";
}
