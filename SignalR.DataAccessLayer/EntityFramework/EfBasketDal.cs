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
	public class EfBasketDal : GenericRepository<Basket>, IBasketDal
	{
		public EfBasketDal(SignalRContext context) : base(context)
		{

		}

		public List<Basket> GetBasketByMenuTableNumber(int id)
		{
			using var c = new SignalRContext();
			var values = c.Baskets.Where(x => x.MenuTableID == id).ToList();
			return values;
		}
	}
}
