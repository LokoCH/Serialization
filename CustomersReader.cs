﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleApp12
{
    public class CustomersReader : BaseModelReader//, IEnumerable<Customer>
    {
        public CustomersReader(string filename) : base(filename)
        {
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadAll()
        {
            if (IsOpened) Close();
            Customer c;
            while ((c = ReadNext()) != null)
            {
                yield return c;
            }
        }

        public Customer ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Customer>(s);
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{

        //}
    }
}
