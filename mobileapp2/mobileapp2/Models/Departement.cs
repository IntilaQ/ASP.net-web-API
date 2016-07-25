using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileapp2.Models
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
