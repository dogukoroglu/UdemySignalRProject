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
	public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
	{
		public EfDiscountDal(SignalRContext context) : base(context)
		{
		}

		public void ChangeStatusToFalse(int id)
		{
			using var c = new SignalRContext();
			var value = c.Discounts.Find(id);
			value.DiscountStatus = false;
			c.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var c = new SignalRContext();
			var value = c.Discounts.Find(id);
			value.DiscountStatus = true;
			c.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var context = new SignalRContext();
			var values = context.Discounts.Where(x=>x.DiscountStatus == true).ToList();
			return values;
		}
	}
}
