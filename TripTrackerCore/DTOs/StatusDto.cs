using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
	public class StatusDto : BaseDto
	{
		public string Information { get; set; }
		//public virtual ICollection<Travel> Travels { get; set; }
	}
}
