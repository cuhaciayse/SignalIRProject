using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalIR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalIRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            var context = new SignalIRContext();
            return context.Orders.Count(x => x.Description == "Müşteri Masada");
        }

        public decimal LastOrderPrice()
        {
            var context = new SignalIRContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public int TotalOrderCount()
        {
            var context = new SignalIRContext();
            return context.Orders.Count();  
        }
    }
}
