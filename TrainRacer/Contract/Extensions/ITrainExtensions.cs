using System;

namespace TrainRacer.Contract.Extensions
{
    public static class ITrainExtensions
    {
        public static ITrain Accelerate(this ITrain train, double intervalMilliseconds)
        {
            train.CurrentSpeed += train.TractiveForce * intervalMilliseconds / (1000 * train.Mass);
            train.CurrentSpeed = Math.Min(train.TopSpeed, Math.Abs(train.CurrentSpeed));
            return train;
        }

        public static ITrain Decelerate(this ITrain train, double intervalMilliseconds)
        {
            train.CurrentSpeed -= train.TractiveForce * intervalMilliseconds / (1000 * train.Mass);
            train.CurrentSpeed = Math.Max(-train.TopSpeed, train.CurrentSpeed);
            return train;
        }

        public static ITrain Travel(this ITrain train, double intervalMilliseconds)
        {
            train.DistanceTraveled += train.CurrentSpeed * intervalMilliseconds / 1000;
            return train;
        }
    }
}
