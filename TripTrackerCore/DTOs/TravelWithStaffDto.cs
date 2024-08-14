using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.DTOs
{
	public class TravelWithStaffDto: TravelDto
	{
        public  StaffDto Staff { get; set; }
    }
}
