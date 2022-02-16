using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public class UnitEdit
    {
        public int UnitId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Guests { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
    }
}
