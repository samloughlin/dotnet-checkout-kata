﻿using System;
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

        [Test]
        public void WhenTotalCalled_WithNoItemsScanned_ReturnsZero(){

            var target = new Checkout();
            var result = target.Total();

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void WhenTotalCalled_AndSingleItemScanned_ReturnsPriceOfSingleItem(){

            var target = new Checkout();
            var item = new Item("A99", 0.50m);

            target.Scan(item);
            var result = target.Total();

            Assert.That(result, Is.EqualTo(item.UnitPrice));
        }

        [Test]
        public void WhenTotalCalled_AndMultipleIdenticalItemsScanned_ReturnsSumOfTheItems(){

            var target = new Checkout();
            var item = new Item("A99", 0.50m);
            var timesToScan = 5;
            for(int i = 0; i < timesToScan; ++i){
                target.Scan(item);
            }
            var result = target.Total();
            
            var expectedTotal = 2.5m;
            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        
        [Test]
        public void WhenTotalCalled_AndItemsHaveSpecialOffers_And3ApplesHaveBeenScanned_Returns1_30(){

            var target = new Checkout();
            var item = new Item("A99", 0.50m);
            var timesToScan = 3;
            for(int i = 0; i < timesToScan; ++i){
                target.Scan(item);
            }
            var result = target.Total();
            
            var expectedTotal = 1.3m;
            Assert.That(result, Is.EqualTo(expectedTotal));
        }

    }
}
