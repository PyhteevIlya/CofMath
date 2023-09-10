using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofMath.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public int GroundCoffee { get; set; }
        public int Water { get; set; }
        public int Milk { get; set; }
        public int Sugar { get; set; }
        public int Cup { get; set; }
        public int Handing { get; set; }

        public Storage(int cup, int groundCoffee, int water, int sugar, int milk, int handing)
        {
            GroundCoffee = groundCoffee;
            Water = water;
            Milk = milk;
            Sugar = sugar;
            Milk = milk;
            Cup = cup;
            Handing = handing;
        }
    }
}
