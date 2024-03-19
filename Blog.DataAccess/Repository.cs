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
        public void Delete(int id)
        {
            T entity = _dbSet.SingleOrDefault(x => x.Id == id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.SaveChanges();
        }
    }
}
