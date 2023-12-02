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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{

		}

		public int ActiveOrderCount()
		{
			using var c = new SignalRContext();
			return c.Orders.Where(x=>x.Description == "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			using var c = new SignalRContext();	
			return c.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
		}

		public decimal TodayTotalPrice()
		{
			/*
			 Bugünkü kazanç kısmı udemy soru-cevap bölümünden başka bir öğrencinin çözümü ile yapıldı.
			 Hoca şimdilik es geçti, daha sonra dönülecek.
			 */

			using var c = new SignalRContext();
			DateTime nowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			return c.Orders.Where(x => x.Date == nowDate && x.Description == "Hesap Kapatıldı").Sum(y => y.TotalPrice);
			//return c.Orders.Where(x => x.Date == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y => y.TotalPrice);
		}

		public int TotalOrderCount()
		{
			using var c = new SignalRContext();
			return c.Orders.Count();
		}
	}
}
