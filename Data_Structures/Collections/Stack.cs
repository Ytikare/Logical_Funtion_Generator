namespace Data_Structures.Collections
{
    public class Stack<T>
    {
        private T[] values;

        private int index = -1;

        public int Count => index + 1;

        public Stack()
        {
            values = new T[4];
        }

        public Stack(int lenght)
        {
            values = new T[lenght];
        }

        public T Peek()
        {
            if (index == -1)
            {
                return default;
            }
            return values[index];
        }

        public T Pop()
        {
            if (index == -1)
            {
                return default;
            }

            var temp = values[index];

            values[index] = default;
            index--;

            return temp;
        }

        public void Push(T value)
        {
            index++;

            if (index == values.Length)
            {
                ExpandValues();
            }

            values[index] = value;
        }

        private void ExpandValues()
        {
            var newCollection = new T[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                newCollection[i] = values[i];
            }
        }
    }
}
