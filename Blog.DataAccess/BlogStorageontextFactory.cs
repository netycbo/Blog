using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blog.DataAccess
{
    public class BlogStorageontextFactory : IDesignTimeDbContextFactory<BlogstorageContext>
    {
        public BlogstorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogstorageContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5N54V80V\\SQLEXPRESS;Initial Catalog=BlogStorage;Integrated Security=True;Trust Server Certificate=True");
            return new BlogstorageContext(optionsBuilder.Options);
        }
    }
}
