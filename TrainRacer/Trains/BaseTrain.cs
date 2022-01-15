using TrainRacer.Contract;

namespace TrainRacer.Trains
{
    public abstract class BaseTrain : ITrain
    {
        public abstract double TopSpeed
        {
            get;
        }

        public double CurrentSpeed
        {
            get;
            set;
        }

        public abstract double TractiveForce
        {
            get;
        }

        public abstract double Mass
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        public double DistanceTraveled
        {
            get;
            set;
        }
    }
}
