using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollAPI.Business;

namespace BenefitsTest
{
    [TestClass]
    public class BenefitCalculatorTest
    {
        [TestMethod]
        public void TestCalculateGrossPay()
        {
            decimal grossPay = BenefitCalculator.CalculateGrossPay();
            Assert.IsTrue(grossPay == 52000);
        }

        [TestMethod]
        public void TestCalculateCost()
        {
            decimal cost = BenefitCalculator.CalculateCost("Haresh", new List<string>() { "Nikita", "Aditya", "Alisha" });
            Assert.IsTrue(cost == 2400);
        }

        [TestMethod]
        public void TestCalculateCostEmplooyeeOnly()
        {
            decimal cost = BenefitCalculator.CalculateCost("Haresh", new List<string>() { });
            Assert.IsTrue(cost == 1000);
        }

        [TestMethod]
        public void TestCalculateCostAjayOnly()
        {
            decimal cost = BenefitCalculator.CalculateCost("Ajay", new List<string>() { });
            Assert.IsTrue(cost == 900);
        }
    }
}
