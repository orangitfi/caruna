using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sopimusrekisteri.BLL_CF.Class;
using System;

namespace Sopimusrekisteri.Tests
{
    [TestClass]
    public class TestLaskennallinenPaattymispvm
    {

        private DateTime Nyt => new DateTime(2022, 2, 1);


        [TestMethod]
        public void Test1()
        {
            var l = new LaskennallinenPaattymispvm();
            Assert.IsTrue(l.Value == DateTime.MaxValue.Date, nameof(Test1));
        }

        [TestMethod]
        public void Test2()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Irtisanomisaika = 12
            };
            Assert.IsTrue(l.Value == DateTime.MaxValue.Date, nameof(Test2));
        }

        [TestMethod]
        public void Test3()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Irtisanottu = new DateTime(2015, 4, 15)
            };
            Assert.IsTrue(l.Value == l.Irtisanottu, nameof(Test3));
        }

        [TestMethod]
        public void Test4()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Irtisanomisaika = 12,
                Irtisanottu = new DateTime(2015, 4, 15)
            };
            Assert.IsTrue(l.Value == new DateTime(2016, 4, 15), nameof(Test4));
        }

        [TestMethod]
        public void Test5()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Paattyy = new DateTime(2007, 6, 10)
            };
            Assert.IsTrue(l.Value == l.Paattyy, nameof(Test5));
        }

        [TestMethod]
        public void Test6()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Paattyy = new DateTime(2007, 6, 10),
                Irtisanottu = new DateTime(2015, 4, 15)
            };
            Assert.IsTrue(l.Value == l.Paattyy, nameof(Test6));
        }

        [TestMethod]
        public void Test7()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Paattyy = new DateTime(2007, 6, 10),
                Jatkoaika = 24
            };
            Assert.IsTrue(l.Value == new DateTime(2023, 6, 10), nameof(Test7));
        }

        [TestMethod]
        public void Test8()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Paattyy = new DateTime(2007, 6, 10),
                Jatkoaika = 24,
                Irtisanottu = new DateTime(2015, 4, 15)
            };
            Assert.IsTrue(l.Value == new DateTime(2015, 6, 10), nameof(Test8));
        }

        [TestMethod]
        public void Test9()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Paattyy = new DateTime(2007, 6, 10),
                Jatkoaika = 24,
                Irtisanomisaika = 12
            };
            Assert.IsTrue(l.Value == new DateTime(2023, 6, 10), nameof(Test9));
        }


        [TestMethod]
        public void Test10()
        {
            var l = new LaskennallinenPaattymispvm
            {
                Nyt = Nyt,
                Paattyy = new DateTime(2007, 6, 10),
                Jatkoaika = 24,
                Irtisanomisaika = 12,
                Irtisanottu = new DateTime(2015, 4, 15)
            };
            Assert.IsTrue(l.Value == new DateTime(2017, 6, 10), nameof(Test10));
        }
    }
}
