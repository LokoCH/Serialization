using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Serialization
{
    public class Saver
    {
        public static void SaveAll(IEnumerable<Customer> customers, IEnumerable<Product> products, IEnumerable<Order> orders)
        {
            using (StreamWriter file = new StreamWriter("Testcustomers.json"))
            {
                foreach (var item in customers)
                {
                    string str = JsonSerializer.Serialize<Customer>(item);
                    file.WriteLine(str);
                }
            }

            using (StreamWriter file = new StreamWriter("Testproducts.json"))
            {
                foreach (var item in products)
                {
                    string str = JsonSerializer.Serialize<Product>(item);
                    file.WriteLine(str);
                }
            }

            using (StreamWriter file = new StreamWriter("Testorders.json"))
            {
                foreach (var item in orders)
                {
                    string str = JsonSerializer.Serialize<Order>(item);
                    file.WriteLine(str);
                }
            }
        }
    }
}
