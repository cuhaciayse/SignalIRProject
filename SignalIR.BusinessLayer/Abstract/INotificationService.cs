﻿using SignalIR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalIR.BusinessLayer.Abstract
{
	public interface INotificationService:IGenericService<Notification>
	{
		int TNotificationCountByStatusFalse();
		List<Notification> TGetAllNotificationByFalse();
		void TNotificationStatusChangeToTrue(int id);
		void TNotificationStatusChangeToFalse(int id);
	}
}
