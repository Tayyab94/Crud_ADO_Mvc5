using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeADO_crud.Models
{
    public class Employee
    {
        public int emp_id { get; set; }

        public string emp_name { get; set; }

        public string emp_city { get; set; }

        public string emp_department { get; set; }

        public string emp_pincode { get; set; }
    }
}