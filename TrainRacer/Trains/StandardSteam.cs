namespace TrainRacer.Trains
{
    public class StandardSteam : BaseTrain
    {
        public override double TopSpeed => 80;

        public override double TractiveForce => 1500;

        public override double Mass => 3500;

        public override string Name => "B12";
    }
}
