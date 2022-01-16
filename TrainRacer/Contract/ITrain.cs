namespace TrainRacer.Contract
{
    public interface ITrain
    {
        /// <summary>
        /// Top Speed in m/s
        /// </summary>
        double TopSpeed
        {
            get;
        }

        /// <summary>
        /// Current speed in m/s
        /// </summary>
        double CurrentSpeed
        {
            get; set;
        }

        /// <summary>
        /// Tractive force in kN
        /// </summary>
        double TractiveForce
        {
            get;
        }

        /// <summary>
        /// Mass in kg
        /// </summary>
        double Mass
        {
            get;
        }

        string Name
        {
            get;
        }

        /// <summary>
        /// Distance traveled in m
        /// </summary>
        double DistanceTraveled
        {
            get; set;
        }
    }
}
