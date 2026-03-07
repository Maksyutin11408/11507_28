using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaIterator
{
    public class Iterator: IDisposable
    {
        private StreamReader _stream;
        private string? _currentLine;
        private bool _closed = false;

        public Iterator(string filepath)
        {
            _stream = new StreamReader(filepath);
            MoveNext();
        }
        private bool MoveNext()
        {
            _currentLine = _stream.ReadLine();
            return _currentLine != null;  
        }
        public bool HasNext()
        {
            return _currentLine != null;
        }
        public string Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more elements");
            }
            string result = _currentLine!;
            MoveNext();
            return result;
        }
        public void Reset()
        {
            _stream.BaseStream.Position = 0;
            _stream.DiscardBufferedData();
            MoveNext();
        }
        public void Dispose()
        {
            if (!_closed)
            {
                _stream.Dispose();
                _closed = true;
            }
        }
    }
}
