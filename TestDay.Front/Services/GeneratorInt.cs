using System;
using System.Collections.Generic;

namespace TestDay.Front.Services
{
    public class GeneratorInt : Generator<int>
    {
        public int GetNext()
        {
            var random = new Random();
            var result = random.Next(int.MinValue, int.MaxValue);
            return result;
        }
    }
}