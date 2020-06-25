using System;
using System.Collections.Generic;

namespace WebApplication4.Services
{
    public class OrderRequest
    {
        public DateTime dateAccepted { get; set; }

        public string Notes { get; set; }

        public List<ConfectioneryOrderRequest> confRequests { get; set; }
    }
}