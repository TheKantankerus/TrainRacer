using Prism.Mvvm;
using TrainRacer.Contract;

namespace TrainRacer.Core.Models.Trains;

public abstract class BaseTrain : BindableBase, ITrain
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
        get => _distanceTraveled;
        set => SetProperty(ref _distanceTraveled, value);
    }
    private double _distanceTraveled;
}
