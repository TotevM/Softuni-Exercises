namespace Database.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }


        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CheckIfCapacityIsExact_ThrowError(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            });
        }



        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorTest(int[] elementsToAdd)
        {
            Database testDb = new Database(elementsToAdd);

            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            Assert.AreEqual(expectedData, actualData);
            Assert.AreEqual(expectedCount, actualCount);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 })]
        [Test]
        public void CheckIfAddMethods_WorksCorrectly(int[] elementsToAdd)
        {
            database = new Database(elementsToAdd);
            int count = database.Count;

            database.Add(1);
            int secondaryCount = database.Count;

            Assert.AreEqual(secondaryCount, count + 1);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [Test]
        public void TryExceedingLimit_ShouldThrowException(int[] elementsToAdd)
        {
            database = new Database(elementsToAdd);
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(17)
            );
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [Test]
        public void RemoveMethod_ShouldRemoveLastIndex(int[] elementsToAdd)
        {
            database = new Database(elementsToAdd);
            database.Remove();
            int[] refArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

            Assert.AreEqual(database.Fetch(), refArr);
        }

        [TestCase(new int[] {})]
        [Test]
        public void RemoveMethod_WhenDBEmpty_ShouldThrowAnError(int[] elementsToAdd)
        {
            database = new Database(elementsToAdd);

            Assert.Throws<InvalidOperationException>(() =>
            database.Remove());
        }
    }
}
