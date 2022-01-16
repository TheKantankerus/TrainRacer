namespace TrainRacer.Core.Models.Trains;

public class SuperSteam : BaseTrain
{
    public override double TopSpeed => 50;

    public override double TractiveForce => 4550;

    public override double Mass => 30000;

    public override string Name => "Mallard";
}
