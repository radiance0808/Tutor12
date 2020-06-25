using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.DTO
{
    public class OrderResponse
    {
        public int IdOrder { get; set; }

        public DateTime dateAccepted { get; set; }

        public DateTime dateFinished { get; set; }

        public List<Confectionery> confectioneries { get; set; }
    }
}
