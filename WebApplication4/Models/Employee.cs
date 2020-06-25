using System.Collections.Generic;

namespace WebApplication4
{
    public class Employee
    {
        public int idEmployee { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}