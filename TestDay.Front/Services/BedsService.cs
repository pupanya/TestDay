using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestDay.Front.Controllers;

namespace TestDay.Front.Services
{
    public class BedsService : IBedsService
    {
        private readonly IFakeBedsRepository bedsRepository;

        public BedsService(IFakeBedsRepository bedsRepository)
        {
            this.bedsRepository = bedsRepository;
        }

        public Bed Get(string id) => bedsRepository.Get(id);

        public List<Bed> Get(string name, int take, int skip) => bedsRepository.Get(take, skip, null, name);

        public void Add(Bed bed)
        {
            bedsRepository.Add(bed);
        }
    }

    public interface IFakeBedsRepository
    {
        void Add(Bed bed);
        void Delete(Bed bed);
        Bed Get(string id);
        List<Bed> Get(int take, int skip, Expression<Func<Bed, bool>> whereFunc = null, string searchString = null);
    }

    public class FakeBedsRepository : IFakeBedsRepository
    {
        private readonly List<Bed> fakeBeds;

        public FakeBedsRepository()
        {
            fakeBeds = Enumerable.Range(1, 20).Select(i => new Bed
            {
                Id = Guid.NewGuid().ToString(),
                number = $"Number{i}",
                Department_id = i/3+1.ToString()
            }).ToList();
        }


        public void Add(Bed bed)
        {
            fakeBeds.Add(bed);
        }

        public void Delete(Bed bed)
        {
            fakeBeds.Remove(bed);
        }

        public Bed Get(string id) => fakeBeds.FirstOrDefault(p => p.Id == id);

        public List<Bed> Get(int take, int skip, Expression<Func<Bed, bool>> whereFunc = null, string searchString = null)
        {
            var pre = Prefilter(searchString, whereFunc);
            return fakeBeds.Where(pre.Compile()).Take(take).Skip(skip).ToList();
        }

        private static Expression<Func<Bed, bool>> Prefilter(string searchString, Expression<Func<Bed, bool>> whereFunc) => ((Expression<Func<Bed, bool>>)
                (p => string.IsNullOrEmpty(searchString) || p.number.Contains(searchString)))
            .AndIf(whereFunc ?? (p => true));
    }

}