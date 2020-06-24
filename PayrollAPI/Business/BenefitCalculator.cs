using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollAPI.Business
{
    public static class BenefitCalculator
    {
        private const decimal COST_PER_EMPLOYEE = 1000;
        private const decimal COST_PER_DEPENDENT = 500;
        private const decimal DISCOUNT = 10;
        private const decimal paycheckAmount = 2000;
        private const decimal paychecksPerYear = 26;
        public static decimal CalculateCost(string employeeName, List<string> dependents)
        {
            decimal discount = 0;
            decimal cost = COST_PER_EMPLOYEE + dependents.Count() * COST_PER_DEPENDENT;

            if (employeeName.StartsWith("A"))
            {
                discount = COST_PER_EMPLOYEE * DISCOUNT / 100;
            }

            List<string> aDependents = dependents.Where(n => n.StartsWith("A")).ToList();
            discount += aDependents.Count() * COST_PER_DEPENDENT * DISCOUNT / 100;

            return cost - discount;
        }

        public static decimal CalculateGrossPay()
        {
            return paycheckAmount * paychecksPerYear;
        }
    }
}