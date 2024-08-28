using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.DTOs.UIDtos
{
		public class UserProfileDto
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Email { get; set; }
			public DateTime RegistrationDate { get; set; }
			public string AdminFirstName { get; set; }
			public string AdminLastName { get; set; }
		}

	
}
