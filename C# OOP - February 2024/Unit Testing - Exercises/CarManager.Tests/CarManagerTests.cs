namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const string validMake = "VW";
        private const string validModel = "Golf";
        private const double validFuelConsumption = 1;
        private const double validFuelCapacity = 3;

        private const string nonValidMake = "";
        private const string nonValidModel = "";
        private const double nonValidFuelConsumption = -1;
        private const double nonValidFuelCapacity = -1;

        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
        }

        [Test]
        public void testCtor_ShouldWork()
        {
            Assert.That(car, Is.Not.Null);
            Assert.That(car.Make == validMake);
            Assert.That(car.Model == validModel);
            Assert.That(car.FuelConsumption == validFuelConsumption);
            Assert.That(car.FuelCapacity == validFuelCapacity);
            Assert.That(car.FuelAmount == 0);
        }

        [Test]
        public void MakeProperty_SetterWorks_ShouldThrowEx()
        {
            Assert.Throws<ArgumentException>(() =>
            car = new Car(nonValidMake, validModel, validFuelConsumption, validFuelCapacity));
        }

        [Test]
        public void ModelProperty_SetterWorks_ShouldThrowEx()
        {
            Assert.Throws<ArgumentException>(() =>
            car = new Car(validMake, nonValidModel, validFuelConsumption, validFuelCapacity));
        }

        [Test]
        public void FuelConsumptionProperty_SetterWorks_ShouldThrowEx()
        {
            Assert.Throws<ArgumentException>(() =>
            car = new Car(validMake, validModel, nonValidFuelConsumption, validFuelCapacity));
        }

        [Test]
        public void FuelAmountProperty_SetterWorks_ShouldThrowEx()
        {
            Assert.Throws<ArgumentException>(() =>
            car = new Car(validMake, validModel, validFuelConsumption, nonValidFuelCapacity));
        }

        [Test]
        public void RefuelMethod_WithNegativeNumber_ShouldThrownAnException()
        {
            Assert.Throws<ArgumentException>(() =>
               car.Refuel(-1));
        }

        [Test]
        public void RefuelMethod_RefuelingToTheTop_ShouldThrownAnException()
        {
            car.Refuel(validFuelCapacity + 1);
            Assert.That(car.FuelCapacity == validFuelCapacity);
        }

        [Test]
        public void Drive_CantReachDestination_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            car.Drive(400));
        }

        [Test]
        public void Drive_WorksCorrectly()
        {
            car.Refuel(validFuelCapacity);
            car.Drive(100);
            Assert.That(car.FuelAmount+1 == car.FuelCapacity);
        }
    }
}