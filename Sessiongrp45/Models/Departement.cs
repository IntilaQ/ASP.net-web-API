using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sessiongrp45.Models
{
    public class Departement
    {
        public Departement()
        {
            this.Employees = new HashSet<Employee>();
        }
        public int DepartementId { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}