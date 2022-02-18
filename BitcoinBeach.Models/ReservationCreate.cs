using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class ReservationCreate
    {
        [Required]
        public int ProfileId { get; set; }

        [Required]
        public int UnitId { get; set; }

        [Required]
        public DateTime ReservationStartDate { get; set; }

        [Required]
        public DateTime ReservationEndDate { get; set; }
    }
}
