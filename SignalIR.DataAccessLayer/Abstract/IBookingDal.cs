using SignalIRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
		void BookingStatusApproved(int id);
		void BookingStatusCancelled(int id);
	}
}
