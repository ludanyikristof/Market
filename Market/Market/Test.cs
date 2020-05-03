using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void GetPriceTest()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('C', 20);
            shop.RegisterProduct('E', 50);
            var price = shop.GetPrice("ACEE");
            Assert.AreEqual(130, price);
        }
        [TestMethod]
        public void GetCountDiscountTest()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('E', 50);
            shop.RegisterCountDiscount('A', 3, 4); // 3 áráért 4-et vihet
            var price = shop.GetPrice("AAAAAEEE");  // 5*10+3*50 helyett 4*10+3*50
            Assert.AreEqual(4 * 10 + 3 * 50, price);
        }
        [TestMethod]
        public void GetAmountdiscountTest()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            shop.RegisterProduct('B', 100);
            shop.RegisterAmountDiscountMethod('A', 5, 0.9);   // 5 darabtól, 0.9-es szorzó
            var price = shop.GetPrice("AAAAAAB");  // 6*10*0.9+100
            Assert.AreEqual(6 * 10 * 0.9 + 100, price);
        }
        [TestMethod]
        public void GetMemberDiscountTest()
        {
            Shop shop = new Shop();
            shop.RegisterProduct('A', 10);
            var price = shop.GetPrice("AAAAAtAAAAA");
            Assert.AreEqual(10*10*0.9, price);
                
        }          
    }
}
