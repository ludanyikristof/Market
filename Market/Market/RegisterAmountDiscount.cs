using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{

    class RegisterAmountDiscount
    {

        public char item;
        public int amount;
        public double discount;

        public RegisterAmountDiscount(char item, int amount, double discount)
        {
            this.item = item;
            this.amount = amount;
            this.discount = discount;
        }
        public Dictionary<char, double> GetRegisterAmountDiscount(Dictionary<char, double> store)
        {
            if (store.ContainsKey(item))
            {
                if (amount <= Shop.GetProductAmount()[item])
                    store[item] *= discount;
                
            }
            return store;
        }
        
    }
}
