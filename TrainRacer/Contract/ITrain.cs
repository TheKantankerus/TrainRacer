namespace TrainRacer.Contract
{
    public interface ITrain
    {
        double TopSpeed
        {
            get;
        }

        double CurrentSpeed
        {
            get; set;
        }

        double TractiveForce
        {
            get;
        }

        double Mass
        {
            get;
        }

        string Name
        {
            get;
        }

        double DistanceTraveled
        {
            get; set;
        }
    }
}
