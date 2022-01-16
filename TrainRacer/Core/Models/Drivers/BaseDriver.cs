using TrainRacer.Contract;
using TrainRacer.Contract.Enums;
using TrainRacer.Contract.Extensions;

namespace TrainRacer.Core.Models.Drivers
{
    public abstract class BaseDriver : IDriver
    {
        public void DriveTrain(ITrain train, double intervalMilliseconds)
        {
            ModifySpeed(train, intervalMilliseconds);
            train.Travel(intervalMilliseconds);
        }

        public void ModifySpeed(ITrain train, double intervalMilliseconds)
        {
            if (train != null)
            {
                switch (GetNextIntention())
                {
                    case DriverIntention.Accelerate:
                        train.Accelerate(intervalMilliseconds);
                        break;
                    case DriverIntention.Decelerate:
                        train.Decelerate(intervalMilliseconds);
                        break;
                    default:
                        break;
                }
                DriverBoost(train);
            }
        }

        protected abstract DriverIntention GetNextIntention();
        protected abstract void DriverBoost(ITrain train);
    }
}
