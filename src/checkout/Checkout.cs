﻿using System.Collections.Generic;
using System.Linq;

namespace checkout
{
    public class Checkout
    {
        public IList<SpecialOffer> SpecialOffers { get; } = new List<SpecialOffer>{
            new SpecialOffer("A99", 3, 1.30m),
            new SpecialOffer("B15", 2, 0.45m)
        };

        public IList<Item> ScannedItems { get; } = new List<Item>();
        public decimal Total()
        {
            var itemsToProcess = ScannedItems.ToList();
            var total = 0m;
            foreach (var offer in SpecialOffers)
            {
                if (itemsToProcess.Count(s => s.Sku == offer.Sku) >= offer.Quantity)
                {
                    var countToRemove = itemsToProcess.Count(s => s.Sku == offer.Sku);
                    var numberOfItemsNotOnOffer = itemsToProcess.Count(s => s.Sku == offer.Sku) % offer.Quantity;

                    total += offer.OfferPrice * (countToRemove / offer.Quantity);
                    var i = itemsToProcess.Count() - 1;
                    while (countToRemove != numberOfItemsNotOnOffer)
                    {
                        var currentItem = itemsToProcess[i];
                        if (currentItem.Sku == offer.Sku && countToRemove != 0)
                        {
                            itemsToProcess.RemoveAt(i);
                            countToRemove--;
                        }
                        else if (countToRemove == 0)
                        {
                            break;
                        }
                        i--;
                    }
                }

            }

            total += itemsToProcess.Sum(s => s.UnitPrice);
            return total;
        }

        public void Scan(Item item)
        {
            ScannedItems.Add(item);
        }


    }

    public class Item
    {
        public Item(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
        public string Sku { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class SpecialOffer
    {
        public SpecialOffer(string sku, int quantity, decimal offerPrice)
        {
            Sku = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }

        public string Sku { get; }
        public int Quantity { get; }
        public decimal OfferPrice { get; }
    }
}
