using System;
using TrainRacer.Contract;
using TrainRacer.Contract.Enums;

namespace TrainRacer.Core.Services.Drivers
{
    public class ErraticDriver : BaseDriver
    {
        private int _intentionCounter = 0;
        private readonly Random _random = new();

        protected override void DriverBoost(ITrain train)
        {
            train.CurrentSpeed *= _random.NextDouble() + 0.5;
            train.CurrentSpeed += _intentionCounter % 2;
        }

        protected override DriverIntention GetNextIntention()
        {
            _intentionCounter++;
            if (_intentionCounter % 5 == 0)
            {
                return DriverIntention.MaintainSpeed;
            }

            if (_intentionCounter % 9 == 0)
            {
                return DriverIntention.Decelerate;
            }

            return DriverIntention.Accelerate;
        }
    }
}
