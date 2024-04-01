using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new(2, 2);
            axe = new (2,2);
        }
        [Test]
        public void LoseHealth_WhenAttacked()
        {
            dummy.TakeAttack(1);
            Assert.IsTrue(dummy.Health == 1);
        }

        [Test]
        public void WhenAttacked_ThrowEx()
        {
            dummy=new(0, 1);
            Assert.Throws<InvalidOperationException>(()=> dummy.TakeAttack(1));
        }

        [Test]
        public void DeadDummy_GiveXP()
        {
            dummy = new(0, 1);
            Assert.IsTrue(dummy.GiveExperience() == 1);
        }
        [Test]
        public void AliveDummy_CantGiveXP()
        {
            dummy = new(2, 0);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}