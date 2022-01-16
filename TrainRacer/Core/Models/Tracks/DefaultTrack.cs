using TrainRacer.Contract;

namespace TrainRacer.Core.Models.Tracks;

public class DefaultTrack : ITrack
{
    public double Length => 500;

    public string Name => "Medium";
}
