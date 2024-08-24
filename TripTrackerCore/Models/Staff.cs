using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.Models
{
    public class Staff :IdentityUser<int>
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UptatedDate { get; set; }
       
        public bool isAdmin { get; set; }   
        public bool Active { get; set; }

        public int? AdminId { get; set; }
        public Staff Admin { get; set; }

        public List<Staff> staffs { get; set; }
        //public List<Travel> travels { get; set; }
        public List<Travel> travelAdmins { get; set; }
        public List<Travel> Travels { get; set; }

    }
}
