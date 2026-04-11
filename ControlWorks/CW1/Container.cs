using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1
{
    public class Container<T> where T : IComparable<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T GetMax()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T currentMax = _items[0];
            foreach (T item in _items.Skip(1))
            {
                if (currentMax.CompareTo(item) < 0)
                {
                    currentMax = item;
                }
            }
            return currentMax;
        }
        public void Sort()
        {
            _items.Sort();
        }
    }

}
