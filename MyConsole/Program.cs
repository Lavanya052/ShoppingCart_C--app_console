using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

}
interface ICart
{
    void AddProduct(Product product, int quantity);
    void RemoveProduct(String Product);
    void ViewCart();
    double Checkout();
}
abstract class Cart : ICart
{
    protected List<Product> items = new List<Product>();

    public abstract void AddProduct(Product product, int quantity);

    public abstract void RemoveProduct(String ProductName);

    public void ViewCart()
    {
        Console.WriteLine("Items in Cart:");
        foreach (var item in items)
        {
            Console.WriteLine(item.Name + " - $" + item.Price);
        }
        Console.WriteLine("\n-------------------------------------------");
    }

    public double Checkout()
    {
        double total = 0;
        foreach (var item in items)
        {
            total += item.Price;
        }
        return total;
    }
}

class ShoppingCart : Cart
{


    public override void AddProduct(Product product, int quantity)
    {
        items.Add(product);
        Console.WriteLine($"{quantity} {product.Name}(s) added to the cart.");
        Console.WriteLine("\n-------------------------------------------");
    }

    public override void RemoveProduct(string productName)
    {
        Product productToRemove = items.Find(p => p.Name.Equals(productName));
        if (productToRemove != null)
        {
            items.Remove(productToRemove);
            Console.WriteLine(productName + " removed from cart.");
        }
        else
        {
            Console.WriteLine(productName + " not found in cart.");
        }
        Console.WriteLine("\n-------------------------------------------");
    }


}

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        List<Product> products = new List<Product>
        {
            new Product { Name = "Soap", Price = 36.00 },
            new Product { Name = "Chips", Price = 10.00 },
            new Product { Name = "Washing powder", Price = 149.99 },
            new Product { Name = "Washing soda", Price = 49.99 },
            new Product { Name = "Honey", Price = 549.99 }
        };

        Console.WriteLine("Welcome to the Shopping Cart App!");

        while (true)
        {
            Console.WriteLine("\nAvailable Products:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + products[i].Name + " - $" + products[i].Price);
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add Product to Cart");
            Console.WriteLine("2. Remove Product from Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter product number to add to cart: ");
                    int productNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    cart.AddProduct(products[productNumber - 1],quantity);
                    break;
                case 2:
                    Console.Write("Enter product name to remove from cart: ");
                    string productName = Console.ReadLine();
                    cart.RemoveProduct(productName);
                    break;
                case 3:
                    cart.ViewCart();
                    break;
                case 4:
                    Console.WriteLine("Total: $" + cart.Checkout());
                    Console.WriteLine("\n-------------------------------------------");
                    break;
                case 5:
                    Console.WriteLine("Thank you for using the Shopping Cart App!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}