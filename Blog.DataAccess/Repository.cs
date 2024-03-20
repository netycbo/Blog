using Blog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly BlogstorageContext _context;
        private DbSet<T> _dbSet;

        public Repository(BlogstorageContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public Task Delete(int id)
        {
            T entity = _dbSet.SingleOrDefault(x => x.Id == id);
            _dbSet.Remove(entity);
           return _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbSet.AddAsync(entity);
           return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
           return _context.SaveChangesAsync();
        }
    }
}
