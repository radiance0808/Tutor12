using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public class Order
    {
        public int idOrder { get; set; }

        public DateTime DateAccepted { get; set; }

        public DateTime DateFinished { get; set; }

        public string Notes { get; set; }

        public int idClient { get; set; }

        public int idEmployee { get; set; }

        public Customer customer { get; set; }

        public Employee employee { get; set; }

        public virtual ICollection<Confectionery_Order> Confectionery_Orders { get; set; }
    }
}