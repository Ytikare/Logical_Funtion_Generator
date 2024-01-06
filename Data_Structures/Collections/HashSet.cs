namespace Data_Structures.Collections
{
    public class HashSet<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private KeyValuePairNode<TKey, TValue>[] collection;

        public HashSet(int size)
        {
            collection = new KeyValuePairNode<TKey, TValue>[size];
        }

        public KeyValuePairNode<TKey, TValue>? this[int position]
        {
            get => collection[position];
        }


        public bool Add(int position, TKey key, TValue value)
        {
            if (ChekcIfItemExistsExists(position, key))
            {
                throw new InvalidOperationException("Item with specified name is already defined!");
            }

            var list = collection[position];

            if (list == null)
            {
                collection[position] = new KeyValuePairNode<TKey, TValue>()
                {
                    Pair = new KeyValuePair<TKey, TValue>(key, value),
                    Next = null
                };
            }
            else
            {
                var temp = list;

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = new KeyValuePairNode<TKey, TValue>()
                {
                    Pair = new KeyValuePair<TKey, TValue>(key, value),
                    Next = null,
                };

            }
            return true;
        }

        public bool ChekcIfItemExistsExists(int hash, TKey name)
        {
            if (collection[hash] == null)
                return false;

            var temp = collection[hash];

            while (temp != null)
            {
                if (temp.Pair.Key.Equals(name))
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }
    }
}
