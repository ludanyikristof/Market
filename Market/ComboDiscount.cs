using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class ComboDiscount
    {
        public string item;
        public int total;
      

        public ComboDiscount(string item, int total )
        {
            this.item = item;
            this.total = total;
            
        }
       public  Boolean Checker(string item)
        { 
            string checkiteminstore = "";            
            foreach(KeyValuePair<char, int> value in Shop.productAmount)
            {               
                if(value.Value >= 1)
                {                    
                    checkiteminstore += (value.Key);
                }
                
            }
            int counter = 0;
            var sumcounter = item.Length;         
            foreach(char value in item)
            {
                if (checkiteminstore.Contains(value))
                {
                    counter++;
                }
                if (counter == sumcounter)
                {
                    return true;
                }
            }
            return false;  
            
        }
        public void GetDiscount()
        {
            
            foreach (ComboDiscount value in Shop.comboDiscounts)
            {
                bool istrue = true;
                while (istrue)
                {
                    istrue = Checker(value.item);
                    if (istrue)
                    {
                        foreach (char element in value.item)
                        {
                            Shop.productAmount[element] -= 1;
                        }
                        Shop.store.Add('|', value.total);
                    }
                }
            }

        }
       
    }
}
