using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class UnitCreate
    {
        [Required]
        [Display(Name = "Unit Title")]
        [MaxLength(100, ErrorMessage = "Shortern your title.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Unit Description")]
        [MaxLength(8000, ErrorMessage = "Shortern your description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Unit Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Price in Bitcoin")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Maximum Guests")]
        public int Guests { get; set; }

        [Required]
        [Display(Name = "Beds")]
        public int Beds { get; set; }

        [Required]
        [Display(Name = "Bathrooms")]
        public int Bathrooms { get; set; }
    }
}
