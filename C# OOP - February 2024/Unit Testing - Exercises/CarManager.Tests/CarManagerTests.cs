//namespace CarManager.Tests
//{
//    using System;
//    using NUnit.Framework;

//    [TestFixture]
//    public class CarManagerTests
//    {
//        private const string validMake = "VW";
//        private const string validModel = "Golf";
//        private const double validFuelConsumption = 1;
//        private const double validFuelCapacity = 3;

//        private const string nonValidMake = "";
//        private const string nonValidModel = "";
//        private const double nonValidFuelConsumption = -1;
//        private const double nonValidFuelCapacity = -1;

//        private Car car;

//        [SetUp]
//        public void SetUp()
//        {
//            car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
//        }

//        [Test]
//        public void testCtor_ShouldWork()
//        {
//            Assert.That(car, Is.Not.Null);
//            Assert.That(car.Make == validMake);
//            Assert.That(car.Model == validModel);
//            Assert.That(car.FuelConsumption == validFuelConsumption);
//            Assert.That(car.FuelCapacity == validFuelCapacity);
//            Assert.That(car.FuelAmount == 0);
//        }

//        [Test]
//        public void MakeProperty_SetterWorks_ShouldThrowEx()
//        {
//            Assert.Throws<ArgumentException>(() =>
//            car = new Car(nonValidMake, validModel, validFuelConsumption, validFuelCapacity));
//        }

//        [Test]
//        public void ModelProperty_SetterWorks_ShouldThrowEx()
//        {
//            Assert.Throws<ArgumentException>(() =>
//            car = new Car(validMake, nonValidModel, validFuelConsumption, validFuelCapacity));
//        }

//        [Test]
//        public void FuelConsumptionProperty_SetterWorks_ShouldThrowEx()
//        {
//            Assert.Throws<ArgumentException>(() =>
//            car = new Car(validMake, validModel, nonValidFuelConsumption, validFuelCapacity));
//        }

//        [Test]
//        public void FuelAmountProperty_SetterWorks_ShouldThrowEx()
//        {
//            Assert.Throws<ArgumentException>(() =>
//            car = new Car(validMake, validModel, validFuelConsumption, nonValidFuelCapacity));
//        }

//        [Test]
//        public void RefuelMethod_WithNegativeNumber_ShouldThrownAnException()
//        {
//            Assert.Throws<ArgumentException>(() =>
//               car.Refuel(-1));
//        }

//        [Test]
//        public void RefuelMethod_RefuelingToTheTop_ShouldThrownAnException()
//        {
//            car.Refuel(validFuelCapacity + 1);
//            Assert.That(car.FuelCapacity == validFuelCapacity);
//        }

//        [Test]
//        public void Drive_CantReachDestination_ShouldThrowException()
//        {
//            Assert.Throws<InvalidOperationException>(() =>
//            car.Drive(400));
//        }

//        [Test]
//        public void Drive_WorksCorrectly()
//        {
//            car.Refuel(validFuelCapacity);
//            car.Drive(100);
//            Assert.That(car.FuelAmount + 1 == car.FuelCapacity);
//        }
//    }
//}
namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Mazda";
        private const string Model = "3";
        private const double Consumption = 7.0;
        private const double FuelCapacity = 50;
        private Car mazda;

        [SetUp]
        public void Setup()
        {
            mazda = new Car(Make, Model, Consumption, FuelCapacity);
        }

        [Test]
        public void Constructor_CorrectParameters_CreatesNewInstance()
        {
            Car newMazda = new Car(Make, Model, Consumption, FuelCapacity);
            Assert.That(newMazda, Is.Not.Null);
            Assert.That(newMazda.Make, Is.EqualTo(Make));
            Assert.That(newMazda.Model, Is.EqualTo(Model));
            Assert.That(newMazda.FuelConsumption, Is.EqualTo(Consumption));
            Assert.That(newMazda.FuelCapacity, Is.EqualTo(FuelCapacity));
            Assert.That(newMazda.FuelAmount, Is.EqualTo(0));
        }


        [Test]
        public void Make_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(null, Model, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Make_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(string.Empty, Model, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }


        [Test]
        public void Model_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, null, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Model_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, string.Empty, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void FuelConsumption_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, Make, 0, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }


        [Test]
        public void FuelCapacity_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, Make, Consumption, 0));
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_HappyPath_FuelAddedToTank()
        {
            double amountOfFuel = FuelCapacity - 1;
            mazda.Refuel(amountOfFuel);

            Assert.That(mazda.FuelAmount, Is.EqualTo(amountOfFuel));
        }

        [Test]
        public void Refuel_TankOverFlow_FuelAddedToTank()
        {
            double amountOfFuel = FuelCapacity + 1;
            mazda.Refuel(amountOfFuel);
            Assert.That(mazda.FuelAmount, Is.EqualTo(FuelCapacity));
        }


        [Test]
        public void Refuel_RefuelZeroOrLessLiters_FuelAddedToTank()
        {
            Assert.Throws<ArgumentException>(() => mazda.Refuel(0));
            Assert.Throws<ArgumentException>(() => mazda.Refuel(-1));
        }

        [Test]
        public void Drive_HappyPath_ReducesFuelAmount()
        {
            double distance = 20;
            mazda.Refuel(FuelCapacity);
            double fuelNeeded = (distance / 100) * Consumption;
            double expectedFuelAmount = mazda.FuelAmount - fuelNeeded;

            mazda.Drive(distance);

            Assert.That(mazda.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        public void Drive_NotEnoughFuel_ReducesFuelAmount()
        {

            double distance = 20;
            double fuelNeeded = (distance / 100) * Consumption;
            double expectedFuelAmount = mazda.FuelAmount - fuelNeeded;

            var exception = Assert.Throws<InvalidOperationException>(() => mazda.Drive(distance));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));

        }
    }
}