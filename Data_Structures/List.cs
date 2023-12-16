using System.Collections;

namespace Data_Structures
{
    public class List<T> : IEnumerable<T>
    {
        private T[] data;
        private int index;

        public int Count => index;

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
            data[index++] = item;
        }

        public void Remove() 
        {
            data[index--] = default(T);
        }

        public void Clear() 
        {
            for (int i = 0; i < index; i++)
            {
                data[i] = default(T);
            }

            index = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
