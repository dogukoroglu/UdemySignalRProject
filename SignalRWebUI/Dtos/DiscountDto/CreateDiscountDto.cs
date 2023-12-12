using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.DiscountDto
{
	public class CreateDiscountDto
	{
		public string DiscountTitle { get; set; }
		public string DiscountAmount { get; set; }
		public string DiscountDescription { get; set; }
		public string DiscountImageUrl { get; set; }
		public bool DiscountStatus { get; set; }

	}
}
