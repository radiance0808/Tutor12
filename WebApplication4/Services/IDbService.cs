using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Services
{
   public interface IDbService
    {
        public IEnumerable getOrder(string name);

        public void newOrder(int id, OrderRequest request);
    }
}
