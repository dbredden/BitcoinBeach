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
        [Display(Name = "Unit ID Number")]
        public int UnitId { get; set; }

        [Display(Name="Unit Title")]
        public string Title { get; set; }

        [Display(Name = "Unit Description")]
        public string Description { get; set; }

        [Display(Name = "Unit Address")]
        public string Address { get; set; }

        [Display(Name = "Price in Bitcoin")]
        public decimal Price { get; set; }

        [Display(Name = "Maximum Guests")]
        public int Guests { get; set; }

        [Display(Name = "Beds")]
        public int Beds { get; set; }

        [Display(Name = "Bathrooms")]
        public int Bathrooms { get; set; }
    }
}
