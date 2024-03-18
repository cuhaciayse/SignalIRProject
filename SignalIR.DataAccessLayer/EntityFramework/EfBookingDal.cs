using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalIRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalIRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context = new SignalIRContext();
			var values = context.Bookings.Find(id);
			values.Description = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var context = new SignalIRContext();
			var values = context.Bookings.Find(id);
			values.Description = "Rezervasyon İptal Edildi";
			context.SaveChanges();
		}
	}
}
