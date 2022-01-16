using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TrainRacer.Contract;
using TrainRacer.Core.Controllers;

namespace TrainRacerTests.Controllers
{
    [TestClass]
    public class RaceControllerTests
    {
        [TestMethod]
        public void RaceCompleteTriggersAfterStart()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            mockTrain.SetupGet(m => m.DistanceTraveled).Returns(10);

            var mockTrack = new Mock<ITrack>();
            mockTrack.SetupGet(m => m.Length).Returns(5);

            var mockDriver = new Mock<IDriver>();
            mockDriver.Setup(m => m.DriveTrain(It.IsAny<ITrain>(), It.IsAny<double>()));

            List<RaceResult> results = new();
            ManualResetEvent resetEvent = new(false);

            var controller = new RaceController(new IDriver[] { mockDriver.Object });

            controller.RaceUpdated += (sender, args) =>
            {
                results.Add(args.RaceResult);
            };

            bool isRaceComplete = false;

            controller.RaceComplete += () =>
            {
                isRaceComplete = true;
                resetEvent.Set();
            };

            //Act
            controller.StartRace(new ITrain[] { mockTrain.Object }, mockTrack.Object);
            resetEvent.WaitOne(5000);

            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(mockTrain.Object, results.First().Train);
            Assert.IsTrue(isRaceComplete);
        }
    }
}
