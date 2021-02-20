using NUnit.Framework;
using System;

namespace CacheOperations.Tests
{
    public class LruCacheTests
    {
        [Test]
        public void Get_CacheIsEmpty_ThrowsException()
        {
            LruCache<int, int> cache = new LruCache<int, int>(2);
            Assert.Throws<ArgumentNullException>(() => cache.Get(5));
        }

        [Test]
        public void Get_KeyDoesNotExistInCache_ThrowsExeption()
        {
            LruCache<int, int> cache = new LruCache<int, int>(2);
            cache.Add(1, 1);
            Assert.Throws<ArgumentNullException>(() => cache.Get(5));

        }

        [Test]
        public void Get_KeyExistsInCache_ReturnsValue()
        {
            LruCache<int, int> cache = new LruCache<int, int>(2);
            cache.Add(5, 1);
            Assert.AreEqual(cache.Get(5), 1);
        }

        [Test]
        public void GetAndAdd_IfMaxCapacityReached_RemovesCache()
        {
            LruCache<int, int> cache = new LruCache<int, int>(2);
            cache.Add(5, 1);
            cache.Add(4, 1);
            cache.Add(3, 1);
            Assert.Throws<ArgumentNullException>(() => cache.Get(5));
        }

        [Test]
        public void GetAndAdd_IfCacheDataUsedFrequently_DoesntRemoveCache()
        {
            LruCache<int, int> cache = new LruCache<int, int>(2);
            cache.Add(5, 1);
            cache.Add(4, 1);
            cache.Get(5);
            cache.Add(3, 1);
            Assert.AreEqual(cache.Get(5), 1);
            Assert.Throws<ArgumentNullException>(() => cache.Get(4));


        }

    }
}
