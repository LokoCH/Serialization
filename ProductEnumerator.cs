using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    internal class ProductEnumerator : IEnumerator<Product>
    {
        public readonly ProductReader _reader;
        private  Product _product;
        public ProductEnumerator(ProductReader pr)
        {
            _reader = pr;
        }
       
        public Product Current => _product;

        public bool MoveNext()
        {
            return (_product = _reader.ReadNext()) != null;
        }
        public void Dispose(){}

        object IEnumerator.Current => throw new NotImplementedException();

        public void Reset(){}
    }
}
