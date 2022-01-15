namespace TrainRacer.Trains
{
    public class OddElectric : BaseTrain
    {
        public override double TopSpeed => 50;

        public override double TractiveForce => 3200;

        public override double Mass => 2900;

        public override string Name => "Crocodile";
    }
}
