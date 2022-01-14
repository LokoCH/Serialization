using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Customer> customers;
            using (var reader = new CustomersReader("customers.json"))
            {
                //Console.WriteLine("Customers:");
                customers = reader.ReadAll().ToArray();
                //foreach (var item in customers)
                //{
                //    Console.WriteLine($"{item.Id}, {item.Name}, {item.Phone}");
                //}
            }

            IEnumerable<Product> products;
            using (var reader = new ProductReader("products.json"))
            {
                //Console.WriteLine("Products:");
                products = reader.ReadAll();
                //foreach (var item in products)
                //{
                //    Console.WriteLine($"{item.Id}, {item.Name}, {item.Price}");
                //}
            }
            Console.WriteLine("---------------------------------");

            IEnumerable<Order> orders;
            using (var reader = new OrderReader("orders.json", customers, products))
            {
                orders = reader.ReadAll();
                orders.Count();

                // с помощью foreach
                //foreach (var order in orders)
                //{
                //    foreach (var customer in customers)
                //    {
                //        foreach (var product in products)
                //        {
                //            if (customer.Id == order.CustomerId && product.Id == order.ProductId)
                //                Console.WriteLine($"Покупатель: {customer.Name}, заказ: {product.Name} по цене {product.Price}");
                //        }
                //    }
                //}

                // с помощью LINQ
                //var selected = from customer in customers
                //               from product in products
                //               from order in orders
                //               where product.Id == order.ProductId && customer.Id == order.CustomerId
                //               select (customer, product);

                Console.WriteLine("-------------------------------------");

                foreach (var customer in customers)
                {
                    Console.WriteLine($"Покупатель: {customer.Name}, email: {customer.Email}, телефон:{customer.Phone}");
                    Console.WriteLine("Товары:");
                    Console.WriteLine($"\tНазвание\tЦена");
                    foreach (var product in customer.Products)
                    {
                        Console.WriteLine($"\t{product.Name}\t{product.Price}");
                    }
                    Console.WriteLine($"Сумма заказов: {customer.Products.Sum(c => c.Price) }");
                }
            }
        }
    }
}


