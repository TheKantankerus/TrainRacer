namespace TrainRacer.Core.Models.Trains;

public class OddElectric : BaseTrain
{
    public override double TopSpeed => 22;

    public override double TractiveForce => 620000;

    public override double Mass => 29000;

    public override string Name => "Crocodile";
}
