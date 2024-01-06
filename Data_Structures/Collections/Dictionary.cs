using System.Collections;

namespace Data_Structures.Collections
{
    public class Dictionary<TKey, TValue> : IEnumerable<KeyValuePairNode<TKey, TValue>> where TKey : IEquatable<TKey>
    {
        private KeyValuePairNode<TKey, TValue>? First;
        private KeyValuePairNode<TKey, TValue>? Last;
        public int Count { get; private set; }

        public TValue? this[TKey key] => GetValue(key);

        public Dictionary()
        {
            Count = 0;
        }


        public bool ContainsKey(TKey check)
        {
            var temp = First;
            while (temp != null)
            {
                if (temp.Pair.Key.Equals(check))
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new InvalidOperationException("An element with specified key already exists!");
            }

            var temp = new KeyValuePairNode<TKey, TValue>(key, value);

            if (Count == 0)
            {
                First = Last = temp;
            }
            else
            {
                Last!.Next = temp;
                Last = temp;
            }
            Count++;
        }

        private TValue? GetValue(TKey key)
        {
            if (Count > 0)
            {
                KeyValuePairNode<TKey, TValue> temp = First!;

                while (true)
                {
                    if (temp.Pair.Key.Equals(key))
                    {
                        return temp.Pair.Value;
                    }

                    if (First == Last)
                    {
                        break;
                    }
                }
            }
            return default;
        }


        public TValue?[] ValuesToArray()
        {
            TValue?[] values = new TValue[Count];

            int i = 0;
            var temp = First;
            while (i < Count)
            {
                values[i] = First.Pair.Value;

                temp = temp.Next;
                i++;
            }
            return values;
        }

        public TKey?[] KeysToArray()
        {
            TKey?[] values = new TKey[Count];

            int i = 0;
            var temp = First;
            while (i < Count)
            {
                values[i] = First.Pair.Key;

                temp = temp.Next;
                i++;
            }
            return values;
        }

        public IEnumerator<KeyValuePairNode<TKey, TValue>> GetEnumerator()
        {
            KeyValuePairNode<TKey, TValue> temp;
            if (Count != 0)
            {
                temp = First!;
            }
            else
            {
                yield break;
            }

            while (true)
            {
                yield return temp;

                if (temp != Last)
                {
                    temp = temp.Next;
                }
                else
                {
                    yield break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
