using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerCore.Repositories;

namespace TripTrackerCore.Services
{
	public interface ITravelService : IService<Travel>
	{

		Task<CustomResponseDto<List<TravelWithStaffDto>>> GetTravelWithStaff();
	}
}
