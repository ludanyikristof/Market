using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void GetPriceTest1()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 100);
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('C', 20);
            shop.RegisterProduct('E', 50);
            var price = shop.GetPrice("ACEE");
            Assert.AreEqual(130, price);
            shop.Clear();
        }
        [TestMethod]
        public void GetCountDiscountTest2()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('E', 50);
            shop.RegisterCountDiscount('A', 3, 4);
            var price = shop.GetPrice("AAAAAEEE");  
            Assert.AreEqual(4 * 10 + 3 * 50, price);
            shop.Clear();
        }
        [TestMethod]
        public void GetAmountdiscountTest3()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('B', 100);
            shop.RegisterAmountDiscountMethod('A', 5, 0.9);  
            var price = shop.GetPrice("AAAAAAB"); 
            Assert.AreEqual(6 * 10 * 0.9 + 100, price);
            shop.Clear();
        }
        [TestMethod]
        public void GetMemberDiscountTest5()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            var price = shop.GetPrice("AAAAAtAAAAA");
            Assert.AreEqual(10*10*0.9, price);
            shop.Clear();

        }
        [TestMethod]
        public void ComboDiscountTest4()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('B', 20);
            shop.RegisterProduct('C', 50);
            shop.RegisterProduct('D', 100);
            shop.RegisterComboDiscount("ABCD", 60);
            var price = shop.GetPrice("CAAAABBD");
            Assert.AreEqual(60 + 3 * 10 + 20, price);
            shop.Clear();
        }

       
    }
}
