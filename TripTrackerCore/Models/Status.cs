using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.Models
{
    public class Status : BaseEntity
    {
        public string Information { get; set; }

        // Bu durumla ilişkili seyahatler
        public virtual ICollection<Travel> Travels { get; set; }
    }
}
