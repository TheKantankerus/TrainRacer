using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using TrainRacer.Contract;
using TrainRacer.Core.Services;

namespace TrainRacerTests.Services
{
    [TestClass]
    public class TrainDriverServiceTests
    {
        [TestMethod]
        public void DistanceUpdatedTriggersAfterStart()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            var mockDriver = new Mock<IDriver>();

            var controller = new TrainDriverService(mockTrain.Object, 100, new IDriver[] { mockDriver.Object });

            int updateCount = 0;

            controller.DistanceUpdated += (sender, args) =>
            {
                updateCount++;
                Assert.AreEqual(mockTrain.Object, args.Train);
            };

            //Act
            controller.StartTrain();

            Thread.Sleep(550);

            //Assert
            Assert.AreEqual(5, updateCount);
        }

        [TestMethod]
        public void DriverCalledAfterStart()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            var mockDriver = new Mock<IDriver>();
            mockDriver.Setup(m => m.DriveTrain(It.IsAny<ITrain>(), It.IsAny<double>()));

            var controller = new TrainDriverService(mockTrain.Object, 100, new IDriver[] { mockDriver.Object });

            //Act
            controller.StartTrain();

            Thread.Sleep(550);

            //Assert
            mockDriver.Verify(m => m.DriveTrain(mockTrain.Object, 100), Times.Exactly(5));
        }
    }
}
