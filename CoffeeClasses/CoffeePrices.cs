using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class CoffeePrices
    {
        public Dictionary<string, double> types = new Dictionary<string, double>()
        {
            { "Regular", 2.0 },
            { "Latte", 2.5 },
            { "Americano", 2.0 },
            { "FlatWhite", 3.0 },
            { "Macchiato", 2.5 },
            { "Espresso", 1.5 }
        };

        public Dictionary<string, double> size = new Dictionary<string, double>()
        {
            { "Large", 1.0 },
            { "Medium", 0.5 },
            { "Small", 0.0 }
        };

        public Dictionary<string, double> special = new Dictionary<string, double>()
        {
            { "Yes", 0.5 },
            { "No", 0.0 }
        };

        public Dictionary<string, double> extras = new Dictionary<string, double>()
        {
            { "Marsh-mellows", 1.0 },
            { "Popcorn", 1.0 },
            { "-", 0.0 }
        };
    }
}
