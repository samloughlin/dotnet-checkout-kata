using System.Collections.Generic;
using System.Linq;

namespace checkout
{
    public class Checkout
    {
        public IList<Item> ScannedItems { get; } = new List<Item>();
        public decimal Total()
        {
            return ScannedItems.Sum(s => s.UnitPrice);
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
}
