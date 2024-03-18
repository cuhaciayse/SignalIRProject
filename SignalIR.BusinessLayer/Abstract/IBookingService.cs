﻿using SignalIRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
		void BookingStatusApproved(int id);
		void BookingStatusCancelled(int id);
	}
}
