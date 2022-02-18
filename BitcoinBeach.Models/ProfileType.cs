using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public enum AccountType { landlord, renter}
    public class ProfileType
    {
        public byte id
        {
            get
            {
                if (type == AccountType.landlord)
                {
                    return 1;
                }
                else if (type == AccountType.renter)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }

        public AccountType type { get; set; }
    }
}
