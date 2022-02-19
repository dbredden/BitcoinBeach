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
        [Display(Name ="Profile ID")]
        public int ProfileId { get; set; }

        [Required]
        [Display(Name ="Unit ID")]
        public int UnitId { get; set; }

        [Required]
        [Display(Name ="Reservation Start Date")]
        public DateTime ReservationStartDate { get; set; }

        [Required]
        [Display(Name ="Reservation End Date")]
        public DateTime ReservationEndDate { get; set; }
    }
}
