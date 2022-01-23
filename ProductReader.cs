using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleApp12
{
    public class ProductReader : BaseModelReader
    {
        public ProductReader(string filename) : base(filename) { }

        public IEnumerator<Product> GetEnumerator()
        {
            return new ProductEnumerator(this);
        }       

        public Product ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Product>(s);
        }
    }
}
