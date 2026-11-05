using System;
using System.Collections.Generic;

namespace InventoryTrackingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Laptop", 1001, 10, 999.99m);
            Product product2 = new Product("Smartphone", 1002, 20, 499.99m);
            Product product3 = new Product("Headphones", 1003, 15, 79.99m);
            Product product4 = new Product("Monitor", 1004, 5, 199.99m);

            Inventory inventory = new();
            inventory.AddProduct(product1);
            inventory.AddProduct(product2);
            inventory.AddProduct(product3);
            inventory.AddProduct(product4);

            static void RunAddProduct(Inventory inventory)
            {
                Console.Write("Enter product name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter SKU: ");
                int sku = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter price: ");
                decimal price = decimal.Parse(Console.ReadLine() ?? "0");

                Product newProduct = new Product(name ?? "", sku, quantity, price);
                inventory.AddProduct(newProduct);
                Console.WriteLine("Product added successfully.");
            }

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n== Inventory Tracking System ==");
                Console.WriteLine("1. Display Inventory");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Update Product Quantity");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Save Inventory");
                Console.WriteLine("7. Load Inventory");
                Console.WriteLine("8. Exit");

                Console.Write("\nSelect an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inventory.DisplayInventory();
                        break;
                    case "2":
                        RunAddProduct(inventory);
                        break;
                    case "3":
                        Console.Write("Enter SKU of product to remove: ");
                        int removeSku = int.Parse(Console.ReadLine() ?? "0");
                        Product? productToRemove = inventory.FindProductBySku(removeSku);
                        if (productToRemove != null)
                        {
                            inventory.RemoveProduct(productToRemove);
                            Console.WriteLine("Product removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter SKU of product to update: ");
                        int updateSku = int.Parse(Console.ReadLine() ?? "0");
                        Product? productToUpdate = inventory.FindProductBySku(updateSku);
                        if (productToUpdate != null)
                        {
                            Console.Write("Enter new quantity: ");
                            int newQuantity = int.Parse(Console.ReadLine() ?? "0");
                            inventory.UpdateQuantity(productToUpdate, newQuantity);
                            Console.WriteLine("Quantity updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;
                    case "5":
                        RunSearch(inventory);
                        break;
                    case "6":
                        Console.Write("Enter file path to save inventory: ");
                        string? savePath = Console.ReadLine();
                        if (!string.IsNullOrEmpty(savePath))
                            inventory.SaveInventory(savePath);
                        break;
                    case "7":
                        Console.Write("Enter file path to load inventory: ");
                        string? loadPath = Console.ReadLine();
                        if (!string.IsNullOrEmpty(loadPath))
                            inventory.LoadInventory(loadPath);
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }

                static void RunSearch(
                    InventoryTrackingSystem.Inventory inventory)
                { 

                Console.WriteLine(
                    "\nSearch Method:");

                Console.WriteLine("1. Search by Name");
                Console.WriteLine("2. Search by SKU");
                Console.WriteLine("3. Search by Price Range");

                Console.Write("\nSelect a search option: ");

                string? searchChoice = Console.ReadLine();

                    switch (searchChoice)
                    {
                        case "1":
                            Console.Write("Enter product name to search: ");
                            string? searchName = Console.ReadLine();
                            inventory.SearchProduct(searchName ?? "");
                            break;
                        case "2":
                            Console.Write("Enter SKU to search: ");
                            int searchSku = int.Parse(Console.ReadLine() ?? "0");
                            Product? foundProduct = inventory.FindProductBySku(searchSku);
                            if (foundProduct != null)
                            {
                                foundProduct.DisplayProductInfo();
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                            break;
                        case "3":
                            Console.Write("Enter minimum price: ");
                            decimal minPrice = decimal.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Enter maximum price: ");
                            decimal maxPrice = decimal.Parse(Console.ReadLine() ?? "0");
                            inventory.GetProductsByPriceRange(minPrice, maxPrice);
                            break;
                        default:
                            Console.WriteLine("Invalid search option. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}
    
