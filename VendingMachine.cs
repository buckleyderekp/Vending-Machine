using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending
{
    public class VendingMachine
    {
        private List<Product> _products = new List<Product>();

        public VendingMachine()
        {
            _products.Add(new Product() { Id = 1, Name = "Snickers", Price = .75 });
            _products.Add(new Product() { Id = 2, Name = "Pepsi", Price = 1.25 });
            _products.Add(new Product() { Id = 3, Name = "Diamond Ring", Price = 2_400 });
            _products.Add(new Product() { Id = 4, Name = "Tesla", Price = 85_000 });
            _products.Add(new Product() { Id = 5, Name = "Hot Pocket", Price = 1.50 });
        }

        // Add a new product to the Vending Machine (For stocking machine)
        public void AddProduct(Product newProduct)
        {
            _products.Add(newProduct);
        }

        // Remove a product from the Vending Machine (for purchasing a product)
        public void RemoveProduct(Product productToRemove)
        {
            _products.Remove(productToRemove);
        }

        // Get all products ordered by price (lowest on top)
        public List<Product> GetAll()
        {
            return _products.OrderBy(p => p.Price).ToList();
        }

        // Find a product by name. Results should be ordered by name)
        public List<Product> SearchByName(string nameCriteria)
        {
            return _products.Where(p => p.Name == nameCriteria).ToList();
        }

        // Find a product between a range or prices. Results should be ordered by price
        public List<Product> SearchByPrice(double minPrice, double maxPrice)
        {
            return _products.Where(p => p.Price < maxPrice && p.Price > minPrice).ToList();
        }

        // Return a product with a given ID. Return null if not found.
        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        // Return the cheapest product or null if there are no products
        public Product GetCheapest()
        {
            List<Product> sortedProducts = _products.OrderBy(p => p.Price).ToList();
            return sortedProducts[0];
        }

        // Return the most expensive product or null if there are no products
        public Product GetMostExpensive()
        {
            List<Product> sortedProducts = _products.OrderByDescending(p => p.Price).ToList();
            return sortedProducts[0];
        }

        // Return all the product names in alphabetical ordere
        public List<string> GetProductNames()
        {
            List<string> names = _products.Select(p => p.Name).ToList();
            return names.OrderBy(name => name).ToList();
        }

        // Property to represent the total of all the products' prices.
        public double TotalValue
        {
            get
            {
                List<double> prices = _products.Select(p => p.Price).ToList();
                return prices.Sum();
            }
        }
    }
}