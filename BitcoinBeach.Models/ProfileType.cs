using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Models
{
    public enum AccountType { Landlord, Renter}
    public class ProfileType
    {
        public byte id
        {
            get
            {
                if (type == AccountType.Landlord)
                {
                    return 1;
                }
                else if (type == AccountType.Renter)
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
