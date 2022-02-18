using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class ReservationDetail
    {
        public int ReservationId { get; set; }
        public int ProfileId { get; set; }
        public int UnitId { get; set; }

        [Display(Name="Reservation Start Date")]
        public DateTime ReservationStartDate { get; set; }

        [Display(Name ="Reservation End Date")]
        public DateTime ReservationEndDate { get; set; }
    }
}
