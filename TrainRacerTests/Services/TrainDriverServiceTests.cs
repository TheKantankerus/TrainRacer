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

            var controller = new TrainDriverService(mockTrain.Object, 100);

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
    }
}
