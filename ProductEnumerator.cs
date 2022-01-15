using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    internal class ProductEnumerator : IEnumerator<Product>
    {
        private readonly Product[] _products;
        private int _index;
        public ProductEnumerator(IEnumerable<Product>products)
        {
            _products = products.ToArray();
        }
       
        public Product Current => _products[_index];

        public bool MoveNext()
        {
            _index++;
            return _products[_index] != null;
        }
        public void Dispose(){}

        object IEnumerator.Current => throw new NotImplementedException();

        public void Reset(){}
    }
}
