using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
	public class TravelDto : BaseDto
	{
		public string Description { get; set; }
		public string? City { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Stay { get; set; }
		public string Vehicle { get; set; }

		public int StaffId { get; set; }
		public int? StatusId { get; set; }
		public int AdminId { get; set; }
	}
}
