using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
	public class StaffDto 
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public string Name { get; set; }
		public string Surname { get; set; }
        public bool isAdmin { get; set; } = false;
        public int? AdminId { get; set; }

        //public ICollection<Travel> Travels { get; set; }
    }
}
