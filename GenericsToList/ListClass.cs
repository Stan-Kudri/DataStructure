using System.Collections;

namespace GenericsToList
{
    public class ListClass<T> : IEnumerable<T>
    {
        public T[]? ListItem { get; set; } = null;

        private int _capacity;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < ListItem.Length)
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
                if (index >= 0 && index < ListItem.Length)
                {
                    ListItem[index] = value;
                }
            }
        }

        public int Count => _capacity;

        public ListClass() { }

        public ListClass(T[]? array)
        {
            if (array != null)
            {
                _capacity = array.Length;
                if (_capacity != 0)
                {
                    ListItem = new T[array.Length];
                    array.CopyTo(ListItem, 0);
                }
            }
        }

        public ListClass(int capacity)
        {
            if (_capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            ListItem = new T[capacity];
            _capacity = capacity;
        }

        public void Add(T item)
        {
            if (ListItem == null)
            {
                ListItem = new T[] { item };
                _capacity = 1;
            }

            else
            {
                var array = new T[_capacity];
                ListItem.CopyTo(array, 0);

                _capacity++;
                ListItem = new T[_capacity];
                array.CopyTo(ListItem, 0);
                ListItem[_capacity - 1] = item;
            }
        }

        public bool Remove(T? item)
        {
            if (ListItem == null)
            {
                throw new ArgumentException("Array null");
            }

            var hasItem = false;
            var array = new T[_capacity];
            for (var i = 0; i < _capacity; i++)
            {
                if (ListItem[i].Equals(item))
                {
                    _capacity--;
                    hasItem = true;
                }

                array[i] = hasItem ? ListItem[i + 1] : ListItem[i];
            }

            if (hasItem)
            {
                ListItem = new T[_capacity];
                Array.Copy(array, ListItem, _capacity);
            }
            return hasItem;
        }

        public void RemoveAt(int index)
        {
            if (ListItem == null)
            {
                throw new ArgumentException("Array null");
            }

            if (index < _capacity)
            {
                var indexItemList = 0;
                var array = new T[_capacity - 1];
                for (var i = 0; i < _capacity; i++)
                {
                    if (i != index)
                    {
                        array[indexItemList] = ListItem[i];
                        indexItemList++;
                    }
                }
                _capacity--;
                ListItem = new T[_capacity];
                array.CopyTo(ListItem, 0);
            }
            else
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        public bool Contain(T item)
        {
            if (item == null)
            {
                throw new Exception("List null.");
            }

            foreach (var element in ListItem)
            {
                if (item.Equals(element))
                    return true;
            }

            return false;
        }

        public void Clear() => ListItem = new T[0];

        public IEnumerator<T> GetEnumerator() => new ArrayEnumerator<T>(ListItem);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    public class ArrayEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _itemArray;

        private int _index;

        public int Index => _index;

        public ArrayEnumerator(T[]? array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Array not null.");
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
