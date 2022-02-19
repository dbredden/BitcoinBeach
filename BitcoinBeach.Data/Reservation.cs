using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Data
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public Guid OwnerId { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey(nameof(ProfileId))]
        public virtual Profile Profile { get; set; }
        public int UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
    }
}
