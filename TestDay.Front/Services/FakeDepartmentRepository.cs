using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestDay.Front.Services
{
    public class FakeDepartmentRepository : IFakeDepartmentRepository
    {
         private readonly List<IDepartment> fakeDepartments;

        public FakeDepartmentRepository()
        {
            fakeDepartments = Enumerable.Range(1, 20).Select(i => new IDepartment
            {
                id = Guid.NewGuid().ToString(),
                Name = $"Name___{i}"
            }).ToList();
        }

        public void Add(IDepartment department)
        {
            fakeDepartments.Add(department);
        }

        public void Delete(IDepartment department)
        {
            fakeDepartments.Remove(department);
        }

        public IDepartment Get(string id) => fakeDepartments.FirstOrDefault(p => p.id == id);

        public List<IDepartment> Get(int take, int skip, Expression<Func<IDepartment, bool>> whereFunc = null, string searchString = null)
        {
            var pre = Prefilter(searchString, whereFunc);
            return fakeDepartments.Where(pre.Compile()).Take(take).Skip(skip).ToList();
        }

        private static Expression<Func<IDepartment, bool>> Prefilter(string searchString, Expression<Func<IDepartment, bool>> whereFunc) => ((Expression<Func<IDepartment, bool>>)
                (p => string.IsNullOrEmpty(searchString) || p.Name.Contains(searchString)))
            .AndIf(whereFunc ?? (p => true));
    }
}