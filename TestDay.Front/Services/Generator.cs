using System;

namespace TestDay.Front.Services
{
    public interface Generator<out T>
    {
        T GetNext();
    }
}