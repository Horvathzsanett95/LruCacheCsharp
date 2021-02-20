using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOperations
{
    public class LruCache<TKey, TValue>
    {
        private readonly int _maxCount;
        private LinkedList<KeyValuePair<TKey, TValue>> _cacheList = new LinkedList<KeyValuePair<TKey, TValue>>();
        private Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> _cacheMap = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
        public LruCache(int maxCount)
        {
            _maxCount = maxCount;
        }

        public void Add(TKey key, TValue value)
        {
            if (_cacheMap.Count >= _maxCount)
            {
                var nodeToRemove = _cacheList.First;
                _cacheList.RemoveFirst();
                _cacheMap.Remove(nodeToRemove.Value.Key);
            }
            var keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
            var node = new LinkedListNode<KeyValuePair<TKey, TValue>>(keyValuePair);
            _cacheList.AddLast(node);
            _cacheMap.Add(key, node);
        }

        public TValue Get(TKey key)
        {
            TValue value;

                LinkedListNode<KeyValuePair<TKey, TValue>> node;
                if (_cacheMap.TryGetValue(key, out node))
                {
                    value = node.Value.Value;
                    _cacheList.Remove(node);
                    _cacheList.AddLast(node);
                }
            else
            {
                throw new ArgumentNullException("The key does not exist!");
            }
            return value;
        }
    }


}