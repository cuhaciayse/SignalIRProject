﻿using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Abstract;
using SignalIR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalIR.BusinessLayer.Concrete
{
    public class OrderDetailManager:IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void TAdd(OrderDetail entity)
        {
            _orderDetailDal.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity); 
        }

        public OrderDetail TGetByID(int id)
        {
            return _orderDetailDal.GetByID(id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _orderDetailDal.GetListAll();
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }
    }
}
