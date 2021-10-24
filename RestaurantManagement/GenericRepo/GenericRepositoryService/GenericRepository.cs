using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Data.Entity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;


namespace RestaurantManagement.GenericRepo.GenericRepositoryService
{

    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {

        protected AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }




        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = FindAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty).AsNoTracking();
            }

            return queryable;
        }


        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(match);
        }
        public T FindFirst(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().OrderByDescending(match).AsNoTracking().FirstOrDefault(match);
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).AsNoTracking().ToList();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).AsNoTracking().ToListAsync();
        }

        public int Add(T Instance)
        {
            _context.Set<T>().Add(Instance);
            return _context.SaveChanges();
             
        }

        public async Task<int> AddAsync(T Instance)
        {
            _context.Set<T>().Add(Instance);
           return await _context.SaveChangesAsync();

        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
           return await _context.SaveChangesAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int Update(T updated, int key)
        {
            if (updated == null)
                return 0;

            T existing = _context.Set<T>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.SaveChanges();
            }
            return key;
        }

        public async Task<int> UpdateAsync(T updated, int key)
        {
            if (updated == null)
                return 0;

            T existing = await _context.Set<T>().FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return key;
        }

        public bool Delete(T Instance)
        {
            _context.Set<T>().Remove(Instance);
            return 1 == _context.SaveChanges();
        }

        public async Task<bool> DeleteAsync(T Instance)
        {
            _context.Set<T>().Remove(Instance);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return 1 == await _context.SaveChangesAsync();
        }

        public int Count()
        {
            return _context.Set<T>().AsNoTracking().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().AsNoTracking().CountAsync();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().AsQueryable().Any(predicate);
        }

        public IEnumerable<T> FindListBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _context.Set<T>().Where(predicate).AsNoTracking();
            return query;
        }

        public async Task<IEnumerable<T>> FindListByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetWithIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll().AsQueryable();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        public async Task<IQueryable<T>> GetAllWithIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = (IQueryable<T>)await GetAllAsync();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        public IQueryable<T> GetAllFilterWithRelational(Expression<Func<T, bool>> predicate, string includeTable = "")
        {
            IQueryable<T> result = _context.Set<T>().Where(predicate);
            if (includeTable != "")
                result = result.Include(includeTable);

            return result;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
