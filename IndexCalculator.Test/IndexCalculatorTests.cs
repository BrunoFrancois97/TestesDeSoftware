using System;
using IndexCalculator.Repository.Implementation;
using IndexCalculator.Service.Contracts;
using IndexCalculator.Service.Implementation;
using IndexCalculator.Service.Validators.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IndexCalculator.Test
{
    [TestClass]
    public class IndexCalculatorTests
    {
        private readonly IIndexCalculatorService service;

        public IndexCalculatorTests()
        {
            service = new IndexCalculatorService(new IndexCalculatorRepository(), new IndexCalculatorValidator());
        }

        [TestMethod]
        public void TestLeters()
        {
            Assert.ThrowsException<Exception>(() => service.GetIndex("a"));
        }

        [TestMethod]
        public void TestLetersWithNumbers()
        {
            Assert.ThrowsException<Exception>(() => service.GetIndex("a1"));
        }

        [TestMethod]
        public void TestEmpty()
        {
            Assert.ThrowsException<Exception>(() => service.GetIndex(""));
        }

        [TestMethod]
        public void TestEvenNumber()
        {
            Assert.ThrowsException<Exception>(() => service.GetIndex("1234"));
        }

        [TestMethod]
        public void TestValidSubscriptions()
        {
            var index = service.GetIndex("13579");
            Assert.AreEqual(1, index);

            index = service.GetIndex("13597");
            Assert.AreEqual(2, index);
        }
    }
}
