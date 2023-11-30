using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).ToList();
			return values;
		}

		public int ProductCount()
		{
			using var c = new SignalRContext();
			var values = c.Products.Count();
			return values;
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID)
			.FirstOrDefault())).Count();
			return value;
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID)
			.FirstOrDefault())).Count();
			return value;
		}

		public string ProductNameByMaxPrice()
		{
			using var c = new SignalRContext();
			return c.Products.Where(x => x.ProductPrice == (c.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var c = new SignalRContext();
			return c.Products.Where(x => x.ProductPrice == (c.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var c = new SignalRContext();
			return c.Products.Average(x => x.ProductPrice);
		}

		public decimal ProductAvgPriceByHamburger()
		{
			using var c = new SignalRContext();
			return c.Products.Where(x => x.CategoryID == (c.Categories.Where(y => y.CategoryName == "Hamburger")
			.Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.ProductPrice);
		}
	}
}
