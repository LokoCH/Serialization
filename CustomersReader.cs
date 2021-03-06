using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Serialization
{
    public class CustomersReader : BaseModelReader, IEnumerable<Customer>
    {
        public CustomersReader(string filename) : base(filename) { }

        public IEnumerator<Customer> GetEnumerator()
        {
            return new CustomerEnumerator(this);
        }

        public Customer ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Customer>(s);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
