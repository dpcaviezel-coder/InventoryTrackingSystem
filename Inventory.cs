using System.Text.Json;

namespace InventoryTrackingSystem
{
    public class Inventory
    {
        List<Product> products { get; set; } = new(); 
    

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
        public void UpdateQuantity(Product product, int newQuantity)
        {
            var existingProduct = products.FirstOrDefault(p => p.Sku == product.Sku);
            if (existingProduct != null)
            {
                existingProduct.Quantity = newQuantity;
            }
        }
        public void SearchProduct(string name)
        {
            var foundProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var product in foundProducts)
            {
                Console.WriteLine($"ID: {product.Sku}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($"Price: {product.Price:C}");
            }
        }

        public void DisplayInventory()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Sku}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($"Price: {product.Price:C}");
            }
        }

        public void SaveInventory(string filePath)
        {
            var json = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, json);
        }

        public void LoadInventory(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            }
        }

        public void GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var filteredProducts = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"SKU: {product.Sku}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($"Price: ${product.Price:C}");
            }
        }
        public Product? FindProductBySku(int sku)
        {
            return products.FirstOrDefault(p => p.Sku == sku);
        }
    }
}
    
