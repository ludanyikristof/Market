using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class CountDiscount
    {
        private char Sale;
        private int howmuch;
        private int howmany;

        public CountDiscount(char sale, int howmuch, int howmany)
        {
            this.Sale = sale;
            this.howmuch = howmuch;
            this.howmany = howmany;

        }
        public char GetSale()
        {
            return Sale;
        }
        public double GetHowmuch()
        {
            return howmuch;
        }
        public double GetHowmany()
        {
            return howmany;
        }
        public int CountDiscountAmount(Dictionary<char, int> cart)
        {
            // vissza adja hogy mennyit nem kell fizetni egy termékből
            foreach(KeyValuePair<char, int> item in cart)
            {
                return (cart[Sale] / howmany) * (howmany - howmuch);
            }
            return 0;
        }

    } 
}
