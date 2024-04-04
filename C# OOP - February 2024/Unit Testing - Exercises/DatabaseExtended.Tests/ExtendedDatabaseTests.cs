namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person[] maxPeopleArr;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void ConstructorWorks() 
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"prsn{i}"));
            }
        }

        [Test]
        public void AddRange_ExceedLimit_ShouldThrow()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"prsn{i}"));
            }


            Assert.Throws<InvalidOperationException>(() =>
            database.Add(new Person(34, $"prsn{34}")));
        }

        [Test]
        public void AddMethod_DuplicatingUsername_ShouldThrowAnExeption()
        {
            Person p1 = new Person(2342,"nadya");
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
            database=new Database(new Person(2342, "nadya"));
            database.Remove();
            Assert.IsTrue(database.Count==0);
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