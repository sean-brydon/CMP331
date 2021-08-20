using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMP332.MVVM.Models;

namespace CMP332.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        Task<bool> Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
        void AddOrUpdate(T t);
    }
}
