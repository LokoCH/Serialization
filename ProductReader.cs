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

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
