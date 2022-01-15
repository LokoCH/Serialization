using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    static class MenuList
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Главное меню");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - Список клинтов");
            Console.WriteLine("2 - Список продуктов");
            Console.WriteLine("3 - Добавить клиента");
            Console.WriteLine("4 - Добавить продукт");
            Console.WriteLine("5 - Сумма всех заказов");           
            Console.WriteLine("0 - Выйти");
            Console.ResetColor();
        }

        public static void Menu_1(IEnumerable<Customer>customers)
        {           
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Список клиентов:");
            int n = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"№\tИмя\t\t\tПочта\t\t\tТелефон");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in customers)
            {
                ++n;
                Console.WriteLine($"{n,0}\t{item.Name,0}\t\t{item.Email,0}\t\t{item.Phone,0}");
            }
            Console.WriteLine("0 - Выйти");
            Console.ResetColor();
        }

        public static void Menu_2(IEnumerable<Product> products, IEnumerable<Customer>customers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Список продуктов:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Наименование\t\tЦена\t\tВсего продано на сумму");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in products)
            {               
                Console.WriteLine($"{item.Name,12}\t\t{item.Price}\t\t{OrdersInfo.Summa(customers,item.Name)}");
            }
            Console.WriteLine("0 - Выйти");
            Console.ResetColor();
        }

        public static void Menu_1_1(Customer customer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Имя: {customer.Name}\tПочта: {customer.Email}\tТелефон: {customer.Phone}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - Добавить заказ");
            Console.WriteLine("2 - Список покупок");           
            Console.WriteLine("0 - Выход");
            Console.ResetColor();
        }

        public static void Menu_1_1_2(Customer customer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Имя: {customer.Name}\tПочта: {customer.Email}\tТелефон: {customer.Phone}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\tТовар\t\tКол-во\t\tЦена\t\tИтого");
            foreach (var item in customer.Products)
            {
                Console.WriteLine($"{item.Name,13}\t\t{item.Count,0}\t\t{item.Price}\t\t{item.Count*item.Price, 0}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\t\t\t\t\t{customer.Products.Sum(p=>p.Count*p.Price)}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("0 - Выйти");
            Console.ResetColor();
        }
    }
}
