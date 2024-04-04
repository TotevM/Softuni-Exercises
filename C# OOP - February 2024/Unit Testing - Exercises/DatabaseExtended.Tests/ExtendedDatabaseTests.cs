namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private const string validName = "pesho";
        private const long validID = 123;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void Constructor_NoParameters_Works()
        {
            Assert.That(database, Is.Not.Null);
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_WithParameters_Works()
        {
            database = new Database(new Person(validID, validName));
            Assert.That(database, Is.Not.Null);
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddRange_ExceedLimit_ShouldThrow()
        {
            Person[] exceedingAmount = new Person[17];


            Assert.Throws<ArgumentException>(() =>
            database = new Database(exceedingAmount));
        }

        //[Test]
        //public void AddMethod_ExceedingLimit_ShouldThrowAnExeption()
        //{
        //    Person[] people = new Person[16];

        //    database = new Database(people);
        //    Person person = new Person(validID, validName);

        //    Assert.Throws<InvalidOperationException>(() => database.Add(new Person(213, "dsad")));
        //}


        [Test]
        public void Add_Method_WhenDatabaseIsFull_ShouldThrowInvalidOperationException()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i + 1, $"User{i + 1}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "User17")));
        }

        [Test]
        public void AddMethod_DuplicatingUsername_ShouldThrowAnExeption()
        {
            Person p1 = new Person(2342, "nadya");
            database.Add(p1);

            Person p2 = new Person(25432, "nadya");
            Assert.Throws<InvalidOperationException>(() => database.Add(p2));
        }

        [Test]
        public void AddMethod_DuplicatingIDs_ShouldThrowAnExeption()
        {
            Person p1 = new Person(2342, "nadya");
            database.Add(p1);

            Person p2 = new Person(2342, "demoo");
            Assert.Throws<InvalidOperationException>(() => database.Add(p2));
        }

        [Test]
        public void RemoveMethod_ShouldWork()
        {
            database = new Database(new Person(validID, validName));
            database.Remove();
            Assert.IsTrue(database.Count == 0);
        }

        [Test]
        public void RemoveMethod_CountIsZero_ShouldThrowAnException()
        {
            database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove()
            );
        }

        [Test]
        public void FindUsernameMethod_NoPresentUsername_ShouldThrowAnExeption()
        {
            database = new Database(new Person(2342, "nadya"));
            Assert.Throws<InvalidOperationException>(() =>
            database.FindByUsername("natasha"));
        }

        [Test]
        public void FindUsernameMethod_UsernameIsNull_ShouldThrowAnExeption()
        {
            database = new Database(new Person(2342, "nadya"));
            Assert.Throws<ArgumentNullException>(() =>
            database.FindByUsername(null));
        }

        [Test]
        public void FindUsernameMethod_IsCaseSensitive_ShouldThrowAnExeption()
        {
            database = new Database(new Person(2342, "nadya"));
            Assert.Throws<InvalidOperationException>(() =>
            database.FindByUsername("Nadya"));
        }

        [Test]
        public void FindUsernameMethod_Works()
        {
            Person[] people = new Person[] { new Person(validID, validName), new Person(validID + 1, validName + "1") };
            database = new Database(people);
            Person Jack=database.FindByUsername(validName);

            Assert.That(Jack.UserName == people[0].UserName);
            Assert.That(Jack.Id == people[0].Id);
        }

        [Test]
        public void FindIDMethod_Works()
        {
            Person[] people = new Person[] { new Person(validID, validName), new Person(validID + 1, validName + "1") };
            database = new Database(people);
            Person Jack = database.FindById(validID);

            Assert.That(Jack.UserName == people[0].UserName);
            Assert.That(Jack.Id == people[0].Id);
        }

        [Test]
        public void FindByID_NotExisting_ShouldThrowAnException()
        {
            database = new Database(new Person(2342, "nadya"));
            Assert.Throws<InvalidOperationException>(() =>
            database.FindById(452));
        }

        [Test]
        public void FindByID_NegativeNumber_ShouldThrowAnException()
        {
            database = new Database(new Person(2342, "nadya"));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            database.FindById(-2342));
        }
    }
}