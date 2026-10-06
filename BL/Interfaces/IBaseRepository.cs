using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> match, List<string> includes = null);
        Task<T> FindAsync(Expression<Func<T, bool>> match, List<string> includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, List<string> includes);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match, List<string> includes);

        T AddItem(T item);
        Task<T> AddItemAsync(T item);

        IEnumerable<T> AddRange(IEnumerable<T> items);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items);

        T Update(T item);

        void Delete(T item);

        void DeleteRange(IEnumerable<T> items);

        void Attach(T item);
        int Count();
        Task<int> CountAsync();

        int Count(Expression<Func<T, bool>> criteria);
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);


    }
}
