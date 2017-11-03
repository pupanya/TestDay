using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestDay.Front.Services
{
    public interface IFakeDepartmentRepository
    {
        void Add(IDepartment department);
        void Delete(IDepartment department);
        IDepartment Get(string id);
        List<IDepartment> Get(int take, int skip, Expression<Func<IDepartment, bool>> whereFunc = null, string searchString = null);
    }
}