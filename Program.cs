using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;

namespace Serialization
{

    class Program
    {
        public static int Selector(int count)
        {
            int select;
            while (!int.TryParse(Console.ReadLine(), out select) || (select < 0 || select > count))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ошибка ввода");
                Console.ResetColor();
                Console.ReadKey();
                return -1;
            }
            return select;
        }
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            using (var reader = new ProductReader("Testproducts.json"))
            {
                products = reader.ToList();
            }

            using (var reader = new CustomersReader("Testcustomers.json"))
            {
                customers = reader.ToList();
            }

            using (var reader = new OrderReader("Testorders.json", customers, products))
            {
                orders = reader.ToList();
            }

            int select = 0;
            while (true)
            {
                MenuList.MainMenu();
                select = Selector(6);

                if (select == 0)
                {
                    Saver.SaveAll(customers, products, orders);
                    break;
                }
                if (select == -1)
                    continue;

                switch (select)
                {
                    case 1:
                        while (true)
                        {
                            MenuList.Menu_1(customers);
                            int select_1 = Selector(customers.Count);
                            if (select_1 == 0)
                                break;
                            if (select_1 == -1)
                                continue;
                            while (true)
                            {
                                MenuList.Menu_1_1(customers.ElementAt(select_1 - 1));
                                int select_1_1 = Selector(2);
                                if (select_1_1 == 0)
                                    break;
                                if (select_1_1 == -1)
                                    continue;
                                switch (select_1_1)
                                {
                                    case 1:
                                        Order tmp;
                                        if ((tmp = Creator.AddOrder(customers.ElementAt(select_1 - 1), products)) != null)
                                            orders.Add(tmp); break;
                                    case 2:
                                        while (true)
                                        {
                                            MenuList.Menu_1_1_2(customers.ElementAt(select_1 - 1));
                                            int select_1_1_2 = Selector(0);
                                            if (select_1_1_2 == 0)
                                                break;
                                            if (select_1_1_2 == -1)
                                                continue;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            MenuList.Menu_2(products, customers);
                            select = Selector(0);
                            if (select == 0)
                                break;
                            if (select == -1)
                                continue;
                        }
                        break;
                    case 3: customers.Add(Creator.AddCustomer()); break;
                    case 4: products.Add(Creator.AddProduct()); break;
                    case 5:
                            Console.Clear();
                            Console.WriteLine(OrdersInfo.Summa(customers));
                            Console.ReadKey();
                        break;                   
                }
            }
        }
    }
}


