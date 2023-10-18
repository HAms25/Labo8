using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public string name { get; set; }
        public Decimal price { get; set; }
        public int stock { get; set; }
        public Boolean active { get; set; }
    }
}
