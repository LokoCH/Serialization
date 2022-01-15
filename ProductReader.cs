using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Serialization
{
    public class ProductReader : BaseModelReader, IEnumerable<Product>
    {
        public ProductReader(string filename) : base(filename) { }

        public IEnumerator<Product> GetEnumerator()
        {
            return new ProductEnumerator(ReadAll());
        }

        public IEnumerable<Product> ReadAll()
        {
            if (IsOpened) Close();
            Product c;
            while ((c = ReadNext()) != null)
            {
                yield return c;
            }
        }

        public Product ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Product>(s);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
