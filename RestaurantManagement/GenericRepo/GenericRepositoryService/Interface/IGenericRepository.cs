using RestaurantManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestaurantManagement.GenericRepo.GenericRepositoryService.Interface
{

    public interface IGenericRepository<T> where T : Base
    {
        IQueryable<T> FindAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int id);
        Task<T> GetAsync(int? id);
        T Find(Expression<Func<T, bool>> match);
        T FindFirst(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match);
        int Add(T Instance);
        Task<int> AddAsync(T Instance);
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        int Update(T updated, int key);
        Task<int> UpdateAsync(T updated, int key);
        bool Delete(T Instance);
        Task<bool> DeleteAsync(T Instance);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities);
        int Count();
        Task<int> CountAsync();
        bool Exists(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindListBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindListByAsyn(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetWithIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> GetAllWithIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAllFilterWithRelational(Expression<Func<T, bool>> predicate, string includeTable = "");
        void Save();
        Task<int> SaveAsync();

    }
}
