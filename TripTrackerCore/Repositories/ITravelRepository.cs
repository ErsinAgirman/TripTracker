using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.Repositories
{
	public interface ITravelRepository : IGenericRepository<Travel>
	{
		Task<List<Travel>> GetTravelWithStaff();
	}
}
