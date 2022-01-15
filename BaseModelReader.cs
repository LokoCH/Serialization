using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Serialization
{
    public abstract class BaseModelReader : IDisposable
    {
        private readonly string _fileName;
        private StreamReader _stream;

        public bool IsOpened => _stream != null;
        protected BaseModelReader(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException(nameof(filename));
            _fileName = filename;
        }

        protected void Open()
        {
            _stream = new StreamReader(_fileName);
        }

        protected void Close()
        {
            if (_stream == null)
                throw new NullReferenceException(nameof(_stream));
            _stream.Dispose();
            _stream = null;
        }

        protected string ReadLine()
        {
            if (_stream == null)
                throw new NullReferenceException(nameof(_stream));
            if (_stream.EndOfStream)
                return null;
            return _stream.ReadLine();
        }

        public void Dispose()
        {
            if (_stream != null)
                _stream.Dispose();
        }
    }
}
