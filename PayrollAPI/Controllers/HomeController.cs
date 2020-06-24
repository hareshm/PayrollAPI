using PayrollAPI.Business;
using PayrollAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();            
        }

        [HttpGet]
        public ActionResult Benefits()
        {           
            return View("Benefits");
        }


        [HttpPost]
        public ActionResult Benefits(Benefits benefits)
        {
            Benefits myBenefits = benefits;           
            return Costs(benefits);
        }
        
        [HttpGet]
        public ActionResult Costs(Benefits benefits)
        {            
            List<string> dependents = new List<string>();

            if (string.IsNullOrEmpty(benefits.EmployeeName))
            {
                benefits.Message = "Please enter Employee Name";
                return View("Benefits", benefits);
            }

            if (string.IsNullOrEmpty(benefits.Dependents) == false)
            {
                string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                dependents = benefits.Dependents.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
           
            decimal cost = BenefitCalculator.CalculateCost(benefits.EmployeeName, dependents);
            decimal grossPay = BenefitCalculator.CalculateGrossPay();
            decimal netPay = grossPay - cost;
            benefits.GrossPayMessage = $"Gross Pay: ${grossPay}";
            benefits.CostMessage = $"Cost of Benefits: ${ cost}";
            benefits.NetPayMessage = $"Net Pay:${netPay}";           

            return View("Benefits", benefits);
        }

    }
}