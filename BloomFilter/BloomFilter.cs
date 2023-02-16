using System.Collections;
using System.Diagnostics;

namespace BloomFilter
{
    public delegate int HashFunction<T>(T input);

    public class BloomFilter<T>
    {

        private readonly HashFunction<T> _getHashPrimary;
        private readonly HashFunction<T> _getHashSecondary;
        private readonly int _hashFunctionCount;
        private readonly BitArray _hashBits;

        public BloomFilter(int capacity, float errorRate, HashFunction<T> primaryHashFunction, HashFunction<T> secondaryHashFunction)
        {
            var m = BestM(capacity, errorRate);
            var k = BestK(capacity, errorRate);
            Debug.WriteLine($"New BloomFilter (k = {k}; m = {m})");

            _hashBits = new BitArray(m);
            _hashFunctionCount = k;
            _getHashPrimary = primaryHashFunction ?? throw new ArgumentNullException(nameof(secondaryHashFunction));
            _getHashSecondary = secondaryHashFunction ?? throw new ArgumentNullException(nameof(secondaryHashFunction));
        }

        public void Add(T item)
        {
            int primaryHash = item.GetHashCode();
            int secondaryHash = _getHashSecondary(item);
            for (int i = 0; i < _hashFunctionCount; i++)
            {
                int hash = ComputeHashUsingDillingerManoliosMethod(primaryHash, secondaryHash, i);
                _hashBits[hash] = true;
            }
        }

        public bool MaybeContains(T item)
        {
            int primaryHash = _getHashPrimary(item);
            int secondaryHash = _getHashSecondary(item);
            for (int i = 0; i < _hashFunctionCount; i++)
            {
                int hash = ComputeHashUsingDillingerManoliosMethod(primaryHash, secondaryHash, i);
                if (_hashBits[hash] == false)
                    return false;
            }
            return true;
        }

        private int ComputeHashUsingDillingerManoliosMethod(int primaryHash, int secondaryHash, int i)
        {
            var resultingHash = (primaryHash + i * secondaryHash) % _hashBits.Count;
            return Math.Abs(resultingHash);
        }

        private static int BestM(int capacity, float errorRate)
          => (int)Math.Ceiling(capacity * Math.Log(errorRate, 1.0 / Math.Pow(2, Math.Log(2.0))));

        private static int BestK(int capacity, float errorRate)
          => (int)Math.Round(Math.Log(2.0) * BestM(capacity, errorRate) / capacity);
    }

}
