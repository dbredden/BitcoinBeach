using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class UnitDetail
    {
        public int UnitId { get; set; }

        [Display(Name="Rental Unit Title")]
        public string Title { get; set; }

        [Display(Name = "Unit Description")]
        public string Description { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public int Guests { get; set; }

        public int Beds { get; set; }

        public int Bathrooms { get; set; }
    }
}
