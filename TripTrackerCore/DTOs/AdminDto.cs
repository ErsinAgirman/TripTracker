using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerCore.DTOs
{
    public class AdminDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isAdmin { get; set; } = true;
        public int? AdminId { get; set; }
        //public List<StaffDto> Staffs { get; set; }
        //public List<TravelDto> TravelAdmins { get; set; }
        //public List<TravelDto> Travels { get; set; }
    }
}
