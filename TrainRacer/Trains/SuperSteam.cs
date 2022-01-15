namespace TrainRacer.Trains
{
    public class SuperSteam : BaseTrain
    {
        public override double TopSpeed => 110;

        public override double TractiveForce => 1350;

        public override double Mass => 3000;

        public override string Name => "Mallard";
    }
}
