using TrainRacer.Contract;

namespace TrainRacer.Core.Models.Tracks;

public class DefaultTrack : ITrack
{
    public double Length => 100;

    public string Name => "Just some track";
}
