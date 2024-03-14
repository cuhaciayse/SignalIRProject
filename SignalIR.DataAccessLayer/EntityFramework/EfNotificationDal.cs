using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
	public class EfNotificationDal:GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalIRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			var context = new SignalIRContext();
			return context.Notifications.Where(x=>x.Status==false).ToList();	
			
		}

		public int NotificationCountByStatusFalse()
		{
            var context = new SignalIRContext();
			return context.Notifications.Where(y => y.Status == false).Count();
        }

		public void NotificationStatusChangeToFalse(int id)
		{
			var context = new SignalIRContext();
			var values = context.Notifications.FirstOrDefault(y => y.NotificationID == id);
			if(values != null)
			{
				values.Status = false;
				context.SaveChanges();
			}
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			var context= new SignalIRContext();
			var values = context.Notifications.FirstOrDefault(x => x.NotificationID == id);
			if( values != null)
			{
				values.Status = true;
				context.SaveChanges();
			}
		}
	}
}
