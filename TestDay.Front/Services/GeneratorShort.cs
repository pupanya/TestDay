using System;

namespace TestDay.Front.Services
{
    public class GeneratorShort : Generator<short>
    {
        public short GetNext()
        {
            var random = new Random();
            var result = (short) random.Next(-32768, 32767);
            return result;
        }
        
    }
}