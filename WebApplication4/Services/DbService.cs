using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.DTO;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class DbService : IDbService
    {
        private readonly OrderDbContext context;

        public DbService(OrderDbContext con)
        {
            context = con;
        }

        public IEnumerable getOrder(string name)
        {
            if (name == null)
            {
                var res = from o in context.orders
                          select new OrderResponse
                          {
                              IdOrder = o.idOrder,
                              dateAccepted = o.DateAccepted,
                              dateFinished = o.DateFinished,
                              confectioneries = (from e in context.confectionery_Orders
                                                 join c in context.confectioneries on e.idConfectionery equals c.idConfectionery
                                                 where e.idOrder == o.idOrder
                                                 select new Confectionery
                                                 {
                                                     idConfectionery = c.idConfectionery,
                                                     Name = c.Name,
                                                     Type = c.Type,
                                                     PricePerite = c.PricePerite
                                                 }
                                      ).ToList()
                          };
                return res;
            }
            else
            {
                var exist = context.customers.Any(e => e.Name == name);
                if (exist)
                {
                    var customer = context.customers.Where(e => e.Name == name).Single();
                    var id = customer.idClient;
                    var res = from o in context.orders
                              where o.idClient == id
                              select new OrderResponse
                              {
                                  IdOrder = o.idOrder,
                                  dateAccepted = o.DateAccepted,
                                  dateFinished = o.DateFinished,
                                  confectioneries = (from e in context.confectionery_Orders
                                                     join c in context.confectioneries on e.idConfectionery equals c.idConfectionery
                                                     where e.idOrder == o.idOrder
                                                     select new Confectionery
                                                     {
                                                         idConfectionery = c.idConfectionery,
                                                         Name = c.Name,
                                                         Type = c.Type,
                                                         PricePerite = c.PricePerite
                                                     }).ToList()
                              };
                    return res;
                }
                else
                {
                    throw new Exception("Such order does not exist");
                }
            }

        }

        public void newOrder(int id, OrderRequest request)
        {
            var customer = context.customers.Any(e => e.idClient == id);
            if (customer)
            {
                var product = context.confectioneries.Any(e => request.confRequests.Select(s => s.Name).Contains(e.Name));
                context.Database.BeginTransaction();
                if (product)
                {
                    try
                    {
                        var order = new Order
                        {
                            idOrder = (context.orders.Max(e => e.idOrder) + 1),
                            DateAccepted = request.dateAccepted,
                            DateFinished = request.dateAccepted,
                            Notes = request.Notes,
                            idClient = id,
                            idEmployee = 1

                        };
                        context.orders.Add(order);
                        context.SaveChanges();


                        for (int i = 0; i < request.confRequests.Count(); i++)
                        {
                            int conf = context.confectioneries.Where(e => e.Name == request.confRequests.ElementAt(i).Name).Select(e => e.idConfectionery).FirstOrDefault();
                            var confOrder = new Confectionery_Order
                            {
                                idConfectionery = conf,
                                idOrder = (context.orders.Max(e => e.idOrder) + 1),
                                Quantity = request.confRequests.ElementAt(i).Quantity,
                                Notes = request.confRequests.ElementAt(i).Notes
                            };
                            context.confectionery_Orders.Add(confOrder);
                            context.SaveChanges();
                        }
                        context.Database.CommitTransaction();

                    }
                    catch (Exception e)
                    {
                        context.Database.RollbackTransaction();
                        throw new Exception("Error");
                    }
                }
                else
                {
                    throw new Exception("Such confectionery does not exist");
                }
            }
            else
            {
                throw new Exception("Such id does not exist");
            }
        }
    }
}


