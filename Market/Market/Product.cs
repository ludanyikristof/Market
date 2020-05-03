using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class Product
    {
        private char name;
        private int price;

        public Product(char n, int p)
        {
            name = n;
            price = p;
        }
        public char GetName()
        {
            return name;
        }
        public int GetPrice()
        {
            return price;
        }
    }
}
