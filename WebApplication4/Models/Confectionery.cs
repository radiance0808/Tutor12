using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class Confectionery
    {
        public int idConfectionery { get; set; }

        public string Name { get; set; }

        public Single PricePerite { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Confectionery_Order> Confectionery_Orders { get; set; }
    }
}
