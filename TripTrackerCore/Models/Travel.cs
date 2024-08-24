using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.Models
{
    public class Travel : BaseEntity
    {
        public string Description { get; set; }
        public string? City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Stay { get; set; }
        public string Vehicle { get; set; }

        //Personel ile ilişki
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        //Durum ile ilişki
        public int StatusId { get; set; } /*= 3;*/
        public Status Status { get; set; }

        //Admin ile İlişki
        public int AdminId { get; set; }
        public Staff Admin { get; set; }
        

    }
}
