﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.FeatureDto
{
	public class UpdateFeatureDto
	{
		public int FeatureID { get; set; }
		public string FeatureTitle1 { get; set; }
		public string FeatureDescription1 { get; set; }
		public string FeatureTitle2 { get; set; }
		public string FeatureDescription2 { get; set; }
		public string FeatureTitle3 { get; set; }
		public string FeatureDescription3 { get; set; }
	}
}
