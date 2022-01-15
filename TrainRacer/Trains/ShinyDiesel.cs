namespace TrainRacer.Trains
{
    public class ShinyDiesel : BaseTrain
    {
        public override double TopSpeed => 95;

        public override double TractiveForce => 900;

        public override double Mass => 2500;

        public override string Name => "Zephyr";
    }
}
