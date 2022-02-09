using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Data
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Shorten your title.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Unit Description")]
        [MaxLength(8000, ErrorMessage = "Shortern your description")]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 24)]
        public int Guests { get; set; }

        [Required]
        public int Beds { get; set; }

        [Required]
        public int Bathrooms { get; set; }
    }
}
