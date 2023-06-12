using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class Voucher
    {
        public Dictionary<string, Dictionary<string, string>> VoucherType = new Dictionary<string, Dictionary<string, string>>()
        {
            { "Bronze", 
                new Dictionary<string, string>() 
                { 
                    { "type", "Regular" },
                    { "size", "Small" },
                    { "special", "No" },
                    { "extras", "-" }
                } 
            },
            { "Silver",
                new Dictionary<string, string>()
                {
                    { "type", "Americano" },
                    { "size", "Medium" },
                    { "special", "Yes" },
                    { "extras", "-" }
                }
            },
            { "Gold",
                new Dictionary<string, string>()
                {
                    { "type", "Latte" },
                    { "size", "Large" },
                    { "special", "Yes" },
                    { "extras", "Marsh-mellows" }
                }
            }
        };
    }
}
