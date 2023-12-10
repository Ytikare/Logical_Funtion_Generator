namespace Data_Structures
{
    public class Stack<T>
    {
        private T[] values;

        private int index = -1;

        public int Coutn => values.Length;

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
                return default(T);
            }
            return values[index];
        }

        public T Pop()
        {
            if (index == -1)
            {
                return default(T);
            }

            index -= 1;

            return values[index + 1];
        }

        public void Push(T value)
        {
            index++;

            if (index == values.Length)
            {
                ExpandValues();
            }

            this.values[index] = value;
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
