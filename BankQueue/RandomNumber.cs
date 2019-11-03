using System;

namespace BankQueue
{
    class RandomNumber
    {
        private static readonly Random Random = new Random();

        private static readonly object SyncLock = new object();

        public static int GetRandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }
    }
}
