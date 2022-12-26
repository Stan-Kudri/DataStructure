using System.Collections;

namespace DataStructure
{
    public class ArrayList<T> : IEnumerable<T>
    {
        private const int DoubleMultiply = 2;

        private T[] ListItem { get; set; } = Array.Empty<T>();

        private int _capacity = 0;

        private int _lenght = 0;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _lenght)
                {
                    return ListItem[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < _lenght)
                {
                    ListItem[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Count => _lenght;

        public int Capacity => _capacity;

        private void DoubleCapacityFromLenght() => _capacity = DoubleMultiply * _lenght;

        private void DefoultValue()
        {
            _capacity = 10;
            ListItem = new T[_capacity];
        }

        private void Resiz(T[] array)
        {
            DoubleCapacityFromLenght();
            ListItem = new T[_capacity];
            array.CopyTo(ListItem, 0);
        }

        public ArrayList()
        {
            DefoultValue();
        }

        public ArrayList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (array.Length > 0)
            {
                _lenght = array.Length;

                if (_lenght >= _capacity)
                {
                    DoubleCapacityFromLenght();
                    ListItem = new T[_capacity];
                }

                array.CopyTo(ListItem, 0);
            }
            else
            {
                ListItem = Array.Empty<T>();
            }
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            if (capacity == 0)
            {
                _capacity = 0;
                ListItem = Array.Empty<T>();
            }
            if (_capacity != capacity)
            {
                ListItem = new T[capacity];
                _capacity = capacity;
                _lenght = 0;
            }
        }

        public void Add(T item)
        {
            if (_capacity == 0)
            {
                DefoultValue();
            }

            _lenght++;

            if (_lenght >= _capacity)
            {
                Resiz(ListItem);
            }

            ListItem[_lenght - 1] = item;
        }

        public bool Contain(T item) => _lenght != 0 && IndexOf(item) >= 0;

        public int IndexOf(T item) => Array.IndexOf(ListItem, item, 0, _lenght);

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < _lenght)
            {
                _lenght--;
                Array.Copy(ListItem, index + 1, ListItem, index, _lenght - index);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public void Clear()
        {
            ListItem = new T[0];
            _capacity = 0;
            _lenght = 0;
        }

        public IEnumerator<T> GetEnumerator() => new ArrayEnumerator<T>(ListItem);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class ArrayEnumerator<T> : IEnumerator<T>
        {
            private readonly T[] _itemArray;

            private int _index;

            public int Index => _index;

            public ArrayEnumerator(T[]? array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array), "Array not null.");
                }
                _itemArray = array;
                _index = -1;
            }

            object IEnumerator.Current => Index;

            T IEnumerator<T>.Current => _itemArray[Index];


            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_index + 1 >= _itemArray.Length)
                {
                    return false;
                }
                _index++;
                return true;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
