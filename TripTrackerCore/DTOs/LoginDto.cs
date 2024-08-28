using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.DTOs
{
	public class LoginDto
	{
        public UserRegisterDto registerDto { get; set; }
        public UserSignInDto signInDto { get; set; }
    }
}
