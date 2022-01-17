using System;
using TrainRacer.Contract;
using TrainRacer.Contract.Enums;

namespace TrainRacer.Core.Services.Drivers
{
    public class CautiousDriver : BaseDriver
    {
        private readonly Random _random = new();

        protected override void DriverBoost(ITrain train)
        {
            train.CurrentSpeed = train.CurrentSpeed switch
            {
                double x when x < train.TopSpeed * 0.1 => train.CurrentSpeed * 1.1,
                double x when x > train.TopSpeed - train.TopSpeed * 0.05 => train.CurrentSpeed * 0.9,
                _ => train.CurrentSpeed
            };
        }

        protected override DriverIntention GetNextIntention()
        {
            return _random.Next(10) switch
            {
                int i when i < 5 => DriverIntention.Accelerate,
                int i when i < 7 => DriverIntention.Decelerate,
                _ => DriverIntention.MaintainSpeed
            };
        }
    }
}
