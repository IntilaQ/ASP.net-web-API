﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileapp2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }

        public int? DepartementId { get; set; }

        public Departement Departement { get; set; }
    }
}
