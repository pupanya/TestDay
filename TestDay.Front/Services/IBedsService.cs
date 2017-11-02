using System.Collections.Generic;
using TestDay.Front.Controllers;

namespace TestDay.Front.Services
{
    public interface IBedsService
    {
        Bed Get(string id);
        List<Bed> Get(string name, int take, int skip);
        void Add(Bed bed);
    }
}