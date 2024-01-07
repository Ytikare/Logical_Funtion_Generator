using System.Collections;

namespace Data_Structures.Collections
{
    public class List<T> : IEnumerable<T>
    {
        private T[] data;
        private int lenght = -1;

        public int Count => lenght + 1;
        public T this[int index]
        {
            get => data[index];
        }

        public List()
        {
            data = new T[4];
        }

        public List(int n)
        {
            data = new T[n];
        }

        public void Add(T item)
        {
            if (lenght + 1 == data.Length)
            {
                DoubleDataStorageSize();
            }
            lenght++;
            data[lenght] = item;
        }

        public void Remove()
        {
            lenght--;
            data[lenght] = default;
        }

        public void Clear()
        {
            for (int i = 0; i < lenght; i++)
            {
                data[i] = default;
            }

            lenght = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < Count)
            {
                yield return data[i];
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()
        {
            T[] values = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                values[i] = data[i];
            }
            return values;
        }

        private void DoubleDataStorageSize() 
        {
            T[] temp = new T[data.Length * 2];

            for (int i = 0; i < data.Length; i++)
            {
                temp[i] = data[i];
            }

            this.data = temp;
        }
    }
}
