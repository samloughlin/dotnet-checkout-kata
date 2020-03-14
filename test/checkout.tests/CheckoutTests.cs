using System;
using NUnit.Framework;

namespace checkout.tests
{
    
    public class CheckoutTests
    {
        [Test]
        public void WhenScanCalled_ScannedItemContainsTheItem(){
            var target = new Checkout();

            var item = new Item("A99", 0.50m);


            Assert.That(target.ScannedItems, Does.Not.Contain(item));
            target.Scan(item);
            Assert.That(target.ScannedItems, Does.Contain(item));
        }
    }
}
