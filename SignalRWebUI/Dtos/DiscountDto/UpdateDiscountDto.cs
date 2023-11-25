﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.DiscountDto
{
	public class UpdateDiscountDto
	{
		public int DiscountID { get; set; }
		public string DiscountTitle { get; set; }
		public string DiscountAmount { get; set; }
		public string DiscountDescription { get; set; }
		public string DiscountImageUrl { get; set; }
	}
}
