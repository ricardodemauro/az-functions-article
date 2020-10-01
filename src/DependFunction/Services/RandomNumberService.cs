using System;

namespace DependFunction.Services
{
    public interface IRandomNumber
    {
        int GetRandom();
    }

    public class RandomNumberService : IRandomNumber
    {
        static readonly Random _rand = new Random();

        public int GetRandom() => _rand.Next(0, 10);
    }
}
