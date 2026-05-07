using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repositories.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        // ميثود للبحث مع إمكانية عمل Include للـ Navigation Properties
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string[]? includes = null);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        // لإضافة Soft Delete بسهولة
        void DeleteById(int id);
    }
}
