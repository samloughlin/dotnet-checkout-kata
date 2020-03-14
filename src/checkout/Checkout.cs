namespace checkout
{
    public class Checkout
    {
        public decimal Total()
        {
            return 0m;
        }

        public void Scan(Item item)
        {

        }
    }

    public class Item{
        public string Sku { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
