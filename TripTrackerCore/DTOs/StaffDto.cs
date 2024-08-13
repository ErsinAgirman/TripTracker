using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
	public class StaffDto : BaseDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		//public ICollection<Travel> Travels { get; set; }
	}
}
