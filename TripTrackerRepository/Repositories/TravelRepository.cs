using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;
using TripTrackerCore.Repositories;

namespace TripTrackerRepository.Repositories
{
	public class TravelRepository : GenericRepository<Travel>, ITravelRepository
	{
		public TravelRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<List<Travel>> GetTravelWithStaff()
		{
			//Eager Loading travels ile staff i aynı anda çekmek
			//eğer staff sonra çekilseydi lazy loading
			return await _context.Travels.Include(x => x.Staff).ToListAsync();
		}
	}
}
