using System;
using TrainRacer.Contract;
using TrainRacer.Contract.Enums;

namespace TrainRacer.Core.Models.Drivers
{
    public class AggressiveDriver : BaseDriver
    {
        private readonly Random _random = new();

        protected override void DriverBoost(ITrain train)
        {
            train.CurrentSpeed = train.CurrentSpeed switch
            {
                double x when x < train.TopSpeed * 0.1 => train.CurrentSpeed * 1.5,
                double x when x < train.TopSpeed * 0.5 => train.CurrentSpeed * 1.2,
                double x when x < train.TopSpeed * 0.8 => train.CurrentSpeed * 1.1,
                _ => train.CurrentSpeed
            };
        }

        protected override DriverIntention GetNextIntention()
        {
            return _random.Next(10) switch
            {
                int i when i < 7 => DriverIntention.Accelerate,
                int i when i < 9 => DriverIntention.Decelerate,
                _ => DriverIntention.MaintainSpeed
            };
        }
    }
}
