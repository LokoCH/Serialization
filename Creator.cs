using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    public static class Creator
    {
        static Creator() { }

        static public Customer AddCustomer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Создание нового клиента:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Имя: ");
            string name = Console.ReadLine();

            Console.Write("Телефон: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.ResetColor();
            return new Customer(Guid.NewGuid(), name, phone, email, new List<Product>());
        }
        static public Product AddProduct()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Создание нового продукта:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Цена: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.ResetColor();
            return new Product(Guid.NewGuid(), name, price);
        }

        static public Order AddOrder(Customer customer, List<Product> products)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Добавление заказа для {customer.Name}");
            int idx = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"№\tНаименование\tЦена");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in products)
            {
                ++idx;              
                Console.WriteLine($"{idx}\t{item.PrintProduct()}");
            }
            Console.WriteLine("0 - Отмена");

            int select = Program.Selector(products.Count);

            if (select == 0)
                return null;
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Товар {products.ToArray()[select - 1].Name}, количество: ");
            int count = int.Parse(Console.ReadLine());

            customer.Products.Add(new Product(products.ToArray()[select - 1], count));
            return new Order(customer.Id, products.ToArray()[select - 1].Id, count);
        }

    }
}
