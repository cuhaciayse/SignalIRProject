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

        public string ProductNameByMaxPrice()
        {
            var context =new SignalIRContext();
            var maxprice= context.Products.Max(x=>x.Price);
            var productNameOfMaxPrice = context.Products.Where(x => x.Price == maxprice).Select(y => y.ProductName).FirstOrDefault();
            return productNameOfMaxPrice;
        }

        public string ProductNameByMinPrice()
        {
            var context = new SignalIRContext();    
            var minprice= context.Products.Min(x=>x.Price);
            var productNameOfMinPrice= context.Products.Where(x=>x.Price== minprice).Select(y => y.ProductName).FirstOrDefault();
            return productNameOfMinPrice;
        }

        public decimal ProductPriceAvg()
        {
            var context = new SignalIRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            var context = new SignalIRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(x=>x.Price);    
        }
    }
}
