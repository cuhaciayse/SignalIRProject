using Microsoft.EntityFrameworkCore;
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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalIRContext context) : base(context)
        {
        }
        public int CategoryCount()
        {
            using var context = new SignalIRContext();
            return context.Categories.Count();
        }

        public int ActiveCategoryCount()
        {
            using var context = new SignalIRContext();
            return context.Categories.Where(x=>x.Status==true).Count();
        }

   
        public int PasiveCategoryCount()
        {
            using var context = new SignalIRContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
