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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalIRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalIRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            var context = new SignalIRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            var context = new SignalIRContext();
            var drinkCategoryId = context.Categories.Where(y => y.CategoryName.Contains("İçecek")).Select(z => z.CategoryID);

            return context.Products.Count(x => drinkCategoryId.Contains(x.CategoryID));

        }

        public int ProductCountByCategoryNameHamburger()
        {
            var context = new SignalIRContext();    
            return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).First())).Count();
        }
    }
}
