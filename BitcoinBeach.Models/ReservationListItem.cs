using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class ReservationListItem
    {
        public int ReservationId { get; set; }

        public virtual ProfileCreate ProfileId { get; set; }

        public virtual UnitCreate UnitId { get; set; }

        [Display(Name="Reservation Start Date")]
        public DateTime ReservationStartDate { get; set; }

        [Display(Name ="Reservation End Date")]
        public DateTime ReservationEndDate { get; set; }
    }
}
