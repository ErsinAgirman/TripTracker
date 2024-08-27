using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.DTOs
{
	internal class UserSignInDto
	{
		public class UserRegisterDto
		{
			public string Username { get; set; }
			public string Mail { get; set; }
			public string Password { get; set; }

		}
	}
}
