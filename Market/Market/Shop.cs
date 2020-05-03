using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class Shop
    {
        //ha char kulccsal visszaadja a prdouctot ami tartalmazza a termekhez az arat (ebbe regisztraljuk a termemeketet)
        private Dictionary<char, Product> products = new Dictionary<char, Product>();
        //ez az a vasarlasok egyes termekek össz arat tartalmazza
        private Dictionary<char, double> store = new Dictionary<char, double>();
        //egyes termekekbol mennyi van
        private static Dictionary<char, int> productAmount = new Dictionary<char, int>();
        private List<RegisterAmountDiscount> amountDiscounts = new List<RegisterAmountDiscount>();

        private List<CountDiscount> countDiscounts = new List<CountDiscount>();
       
        public  bool member = false;
        
        public static Dictionary<char, int> GetProductAmount()
        {
            return productAmount;
        }
        public Dictionary<char, double> GetStore()
        {
            return store;
        }
        public void RegisterProduct(char s, int i)
        {
            // registráljuk a termékeket
            products.Add(s, new Product(s, i));
        }
        public double  GetPrice(string x)
        {
            //membercheck
            if (x.Contains("t"))
            {
                member = true;
               x=  x.Replace("t", "");


            }

            double sum = 0;
            //meg számolja hogy a vásárolando termékek hány darab van és azt eltárolja
            foreach(char c in x)
            {
                
                
                if (productAmount.ContainsKey(c))
                {
                    productAmount[c] += 1;
                    
                }
                else
                {
                    productAmount.Add(c, 1);
                }
            }
            // ez kiszámolja az egyes termékekhez tartozó az össz árát amit a store ban tárulunk
            foreach(KeyValuePair<char, int> product in productAmount)
            {

                store.Add(product.Key, products[product.Key].GetPrice() * product.Value);
                
            }
            // itt kiszámólja hogy a discount termékból mennyit kell levoni
            foreach(CountDiscount discount in countDiscounts)
            {
                int dis = discount.CountDiscountAmount(productAmount);
                store[discount.GetSale()] -= dis *products[discount.GetSale()].GetPrice();
            }
            foreach(RegisterAmountDiscount discount in amountDiscounts)
            {
                store = discount.GetRegisterAmountDiscount(store);
            }
            // minden után összegezük az árakat az egyestermékeknek
            foreach(KeyValuePair<char, double> item in store)
            {
                sum += item.Value;
            }
            //clubmemeber check
            if (member )
            {
                sum *= 0.9;
            }
            return sum;

        }
        public void RegisterCountDiscount(char name, int howmuch, int howmany)
        {
            countDiscounts.Add(new CountDiscount(name, howmuch, howmany));
        }
        public void RegisterAmountDiscountMethod(char name, int amount, double discount)
        {
            amountDiscounts.Add(new RegisterAmountDiscount(name, amount, discount));
        }

    }
}
    
