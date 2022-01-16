using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainRacer.Contract;
using TrainRacer.Contract.Extensions;

namespace TrainRacerTests.Extensions
{
    [TestClass]
    public class ITrainExtensionsTests
    {
        [TestMethod]
        public void AccelerateBehavesAsExpectedBelowMaxSpeed()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            mockTrain.SetupGet(m => m.Mass).Returns(1500);
            mockTrain.SetupGet(m => m.TractiveForce).Returns(1500);
            mockTrain.SetupProperty(m => m.CurrentSpeed);
            mockTrain.SetupGet(m => m.TopSpeed).Returns(15);

            mockTrain.Object.CurrentSpeed = 10;


            //Act
            mockTrain.Object.Accelerate(1000);

            //Assert
            Assert.AreEqual(11, mockTrain.Object.CurrentSpeed);
        }

        [TestMethod]
        public void AccelerateLimitedByMaxSpeed()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            mockTrain.SetupGet(m => m.Mass).Returns(1500);
            mockTrain.SetupGet(m => m.TractiveForce).Returns(1500);
            mockTrain.SetupProperty(m => m.CurrentSpeed);
            mockTrain.SetupGet(m => m.TopSpeed).Returns(10);

            mockTrain.Object.CurrentSpeed = 10;


            //Act
            mockTrain.Object.Accelerate(1000);

            //Assert
            Assert.AreEqual(10, mockTrain.Object.CurrentSpeed);
        }

        [TestMethod]
        public void DecelerateBehavesAsExpectedBelowMaxSpeed()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            mockTrain.SetupGet(m => m.Mass).Returns(1500);
            mockTrain.SetupGet(m => m.TractiveForce).Returns(1500);
            mockTrain.SetupProperty(m => m.CurrentSpeed);
            mockTrain.SetupGet(m => m.TopSpeed).Returns(15);

            mockTrain.Object.CurrentSpeed = 10;


            //Act
            mockTrain.Object.Decelerate(1000);

            //Assert
            Assert.AreEqual(9, mockTrain.Object.CurrentSpeed);
        }

        [TestMethod]
        public void DecelerateLimitedByMaxSpeed()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            mockTrain.SetupGet(m => m.Mass).Returns(1500);
            mockTrain.SetupGet(m => m.TractiveForce).Returns(1500);
            mockTrain.SetupProperty(m => m.CurrentSpeed);
            mockTrain.SetupGet(m => m.TopSpeed).Returns(10);

            mockTrain.Object.CurrentSpeed = -10;


            //Act
            mockTrain.Object.Decelerate(1000);

            //Assert
            Assert.AreEqual(-10, mockTrain.Object.CurrentSpeed);
        }

        [TestMethod]
        public void TravelIncreasesDistance()
        {
            //Arrange
            var mockTrain = new Mock<ITrain>();
            mockTrain.Setup(m => m.CurrentSpeed).Returns(10);
            mockTrain.SetupProperty(m => m.DistanceTraveled);

            //Act
            mockTrain.Object.Travel(500);

            //Assert
            Assert.AreEqual(5, mockTrain.Object.DistanceTraveled);
        }
    }
}
