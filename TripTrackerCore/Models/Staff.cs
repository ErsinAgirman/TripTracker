using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.Models
{
    public class Staff : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Travel> Travels { get; set; }

    }
}
