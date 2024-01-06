namespace Data_Structures
{
    public class KeyValuePairNode<TKey, TValue> where TKey : IEquatable<TKey>
    {
        public KeyValuePair<TKey, TValue> Pair = null!;
        
        public KeyValuePairNode<TKey, TValue>? Next;
        
        public KeyValuePairNode()
        {
            Pair = new KeyValuePair<TKey, TValue>();
        }

        public KeyValuePairNode(TKey key, TValue value)
        {
            Pair = new KeyValuePair<TKey, TValue> { Key = key, Value = value };

            Pair.Key = key;
            Pair.Value = value;
        }
    }
}
