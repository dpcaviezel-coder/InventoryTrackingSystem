namespace InventoryTrackingSystem
{
    public class Product
    {
        public string Name { get; set; }
        public int Sku { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, int sku, int quantity, decimal price)
        {
            Name = name;
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }


        public void DisplayProductInfo()
        {
            Console.WriteLine("\n== Product Information: ==");
            Console.WriteLine($"Product Name: {Name}");
            Console.WriteLine($"SKU: {Sku}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine("===========================\n");
        }
    }
}
    
