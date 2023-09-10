using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofMath.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public int GroundCoffee { get; set; }
        public int Water { get; set; }
        public int Milk { get; set; }
        public int Price { get; set; }

        public Coffee(int groundCoffee, int water, int milk, int price)
        {
            GroundCoffee = groundCoffee;
            Water = water;
            Milk = milk;
            Price = price;
        }
    }
}
