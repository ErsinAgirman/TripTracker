using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
	public class AdminUpdateDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		//public virtual ICollection<Travel> ApprovedTravels { get; set; }

	}
}
