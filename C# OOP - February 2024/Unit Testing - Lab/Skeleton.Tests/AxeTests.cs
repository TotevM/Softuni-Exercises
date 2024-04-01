using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;

        [SetUp]
        public void SetUp()
        {
            axe = new(5, 5);
        }


        [Test]
        public void DurabilityLost_AfterAnAttack()
        {
            Dummy dummy = new Dummy(3, 3);
            axe.Attack(dummy);
            Assert.IsTrue(axe.DurabilityPoints == 4);
        }

        [Test]
        public void Attacking_WithBrokenWeapon()
        {
            axe = new(3, 0);
            Assert.Throws<InvalidOperationException>(() =>
            axe.Attack(new Dummy(3, 3)));
        }
    }
}
