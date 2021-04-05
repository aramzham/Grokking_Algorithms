namespace CustomHashTable
{
    public class MyHashTable<TKey, TValue>
    {
        // load factor > 0.7 => resize by twice
        private int[] _baseArray = new int[4]; // we start by 4
        private int _occupiedSlotsCount;
        private float _loadFactor => (float)_occupiedSlotsCount / _baseArray.Length;
        private const float RESIZE_THRESHOLD = 0.7f;

        public void Add(TKey key, TValue value)
        {

        }

        //private int GetHash(TKey key)
        //{

        //}
    }
}