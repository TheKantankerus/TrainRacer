namespace TrainRacer.Contract
{
    public interface IDriver
    {
        void DriveTrain(ITrain train, double intervalMilliseconds);
    }
}
