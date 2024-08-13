using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.Models
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Travel> ApprovedTravels { get; set; }
    }
}
