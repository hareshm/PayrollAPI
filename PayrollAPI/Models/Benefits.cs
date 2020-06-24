using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollAPI.Models
{
    public class Benefits
    {
        public string EmployeeName { get; set; }
        public string Dependents { get; set; }

        public decimal Cost { get; set; }
        public string Message { get; set; }

        public string GrossPayMessage { get; set; }
        public string CostMessage { get; set; }
        public string NetPayMessage { get; set; }

    }
}