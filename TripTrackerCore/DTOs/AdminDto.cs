﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
	public class AdminDto : BaseDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		//public virtual ICollection<Travel> ApprovedTravels { get; set; }
	}
}
