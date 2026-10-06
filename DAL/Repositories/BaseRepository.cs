using BL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public T AddItem(T item)
        {
            _context.Set<T>().Add(item);

            return item;
        }

        public async Task<T> AddItemAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);

            return item;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);

            return items;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            return items;
        }

        public void Attach(T item)
        {
            _context.Attach(item);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            _context.Set<T>().RemoveRange(items);
        }

        public T Find(Expression<Func<T, bool>> criteria, List<string> includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, List<string> includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query.Where(match).ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match, List<string> includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return await query.Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match, List<string> includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Update(T item)
        {
            _context.Set<T>().Update(item);
            return item;
        }
    }
}
