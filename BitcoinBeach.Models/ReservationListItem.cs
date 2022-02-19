﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class ReservationListItem
    {
        [Display(Name ="Reservation ID")]
        public int ReservationId { get; set; }

        [Display(Name ="Profile ID")]
        public virtual ProfileCreate ProfileId { get; set; }

        [Display(Name ="Unit ID")]
        public virtual UnitCreate UnitId { get; set; }

        [Display(Name="Reservation Start Date")]
        public DateTime ReservationStartDate { get; set; }

        [Display(Name ="Reservation End Date")]
        public DateTime ReservationEndDate { get; set; }
    }
}
